
namespace ProductShop
{
    using Data;
    using Dtos.Import;

    using System.Linq;
    using System.IO;
    using System.Xml.Serialization;
    using ProductShop.Models;
    using AutoMapper;
    using ProductShop.Dtos.Export;
    using System.Text;
    using System.Xml;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<ProductShopProfile>();
            });

            using (var context = new ProductShopContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //var usersImportPath = "../../../Datasets/users.xml";
                //var usersInputXml = File.ReadAllText(usersImportPath);
                //ImportUsers(context, usersInputXml);

                //var productsImportPath = "../../../Datasets/products.xml";
                //var productInputXml = File.ReadAllText(productsImportPath);
                //ImportProducts(context, productInputXml);

                //var categoriesImportPath = "../../../Datasets/categories.xml";
                //var categpryInputXml = File.ReadAllText(categoriesImportPath);
                //ImportCategories(context, categpryInputXml);

                //var categorieProductsImportPath = "../../../Datasets/categories-products.xml";
                //var categpryProductInputXml = File.ReadAllText(categorieProductsImportPath);

                //ImportCategoryProducts(context, categpryProductInputXml);

                //System.Console.WriteLine(GetCategoriesByProductsCount(context));

                //System.Console.WriteLine(GetSoldProducts(context));

                //System.Console.WriteLine(GetProductsInRange(context));

                System.Console.WriteLine(GetUsersWithProducts(context));

            }
        }

        //Import
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            using (var stringReader = new StringReader(inputXml))
            {
                var users = ((ImportUserDto[])serializer.Deserialize(stringReader))
                    .Select(Mapper.Map<User>)
                    .ToArray();

                context.Users.AddRange(users);
                var addedUsersCount = context.SaveChanges();

                return $"Successfully imported {addedUsersCount}";
            }
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            using (var stringReader = new StringReader(inputXml))
            {
                var products = ((ImportProductDto[])serializer.Deserialize(stringReader))
                    .Select(Mapper.Map<Product>)
                    .ToArray();

                context.Products.AddRange(products);
                var addedProductsCount = context.SaveChanges();

                return $"Successfully imported {addedProductsCount}";
            }
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            using (var stringReader = new StringReader(inputXml))
            {
                var categories = ((ImportCategoryDto[])serializer.Deserialize(stringReader))
                    .Where(c => c.Name != null)
                    .Select(Mapper.Map<Category>)
                    .ToArray();

                context.Categories.AddRange(categories);
                var addedCategoriesCount = context.SaveChanges();

                return $"Successfully imported {addedCategoriesCount}";
            }
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            using (var stringReader = new StringReader(inputXml))
            {
                var categoryIds = context.Categories
                    .Select(x => x.Id)
                    .ToArray();

                var productIds = context.Products
                    .Select(x => x.Id)
                    .ToArray();

                var categoryProducts = ((ImportCategoryProductDto[])serializer.Deserialize(stringReader))
                    .Where(cp => categoryIds.Contains(cp.CategoryId) && productIds.Contains(cp.ProductId))
                    .Select(Mapper.Map<CategoryProduct>)
                    .ToArray();

                context.CategoryProducts.AddRange(categoryProducts);
                var addedCategoryProductsCount = context.SaveChanges();

                return $"Successfully imported {addedCategoryProductsCount}";
            }
        }

        //Export
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ExportProductInRangeDto>()
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportProductInRangeDto[]), new XmlRootAttribute("Products"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            using(var stringWriter = new StringWriter(sb))
            {
                serializer.Serialize(stringWriter, products, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var selleres = context
                .Users
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId != null && ps.BuyerId != u.Id))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ProjectTo<ExportSellerDto>()
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportSellerDto[]), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            using (var stringWriter = new StringWriter(sb))
            {
                serializer.Serialize(stringWriter, selleres, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .ProjectTo<ExportCategoryByProductsCountDto>()
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportCategoryByProductsCountDto[]), new XmlRootAttribute("Categories"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            using (var stringWriter = new StringWriter(sb))
            {
                serializer.Serialize(stringWriter, categories, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count)
                .Select(u => new
                ExportUserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    ProductsSold = new
                    ExportSoldProductsCollectionDto
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                        .Select(ps => new ExportSoldProductDto
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            var usersWithProducts = new ExportUsersCollectionDto()
            {
                Count = context
                .Users
                .Count(u => u.ProductsSold.Any()),
                Users = users
            };

            var serializer = new XmlSerializer(typeof(ExportUsersCollectionDto), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            using (var stringWriter = new StringWriter(sb))
            {
                serializer.Serialize(stringWriter, usersWithProducts, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}