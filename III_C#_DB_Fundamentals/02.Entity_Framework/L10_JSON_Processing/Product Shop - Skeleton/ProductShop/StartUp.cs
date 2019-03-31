namespace ProductShop
{
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    using Data;
    using Models;
    using System;
    using ProductShop.Dtos.Export;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new ProductShopContext())
            {
                //var path = "../../../Datasets/{0}.json";

                //var jsonString = File.ReadAllText(string.Format(path, "users"));
                //var result = ImportUsers(context, jsonString);

                //var jsonString = File.ReadAllText(string.Format(path, "products"));
                //var result = ImportProducts(context, jsonString);

                //var jsonString = File.ReadAllText(string.Format(path, "categories"));
                //var result = ImportCategories(context, jsonString);

                //var jsonString = File.ReadAllText(string.Format(path, "categories-products"));
                //var result = ImportCategoryProducts(context, jsonString);

                //var result = GetProductsInRange(context);

                //var result = GetSoldProducts(context);

                //var result = GetCategoriesByProductsCount(context);

                var result = GetUsersWithProducts(context);
                Console.WriteLine(result);
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {         
            var users = JsonConvert.DeserializeObject<User[]>(inputJson)
                .Where(u => u.LastName != null || u.LastName.Length >= 3)
                .ToArray();

            context.Users.AddRange(users);
            var addedUsersCount = context.SaveChanges();

            return $"Successfully imported {addedUsersCount}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson)
                .Where(p => p.Name != null && p.Name.Trim().Length >= 3)
                .ToArray();

            context.Products.AddRange(products);
            var addedProductsCount = context.SaveChanges();

            return $"Successfully imported {addedProductsCount}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null && c.Name.Trim().Length >= 3 && c.Name.Trim().Length <= 15)
                .ToArray();

            context.Categories.AddRange(categories);
            var addedCategoriesCount = context.SaveChanges();

            return $"Successfully imported {addedCategoriesCount}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            var addedCategoryProductsCount = context.SaveChanges();

            return $"Successfully imported {addedCategoryProductsCount}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => 
                    new ProductDto
                    {
                        Name = p.Name,
                        Price = p.Price,
                        Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                    })
                .OrderBy(x => x.Price)
                .ToArray();

            var jsonString = JsonConvert.SerializeObject(products);
            return jsonString;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(s => s.ProductsSold.Any(sp => sp.BuyerId != null && sp.BuyerId != s.Id))
                .Select(s =>
                    new SellerDto()
                    {
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        ProductsSold = s.ProductsSold
                        .Select(sp =>
                            new SoldProductDto()
                            {
                                Name = sp.Name,
                                Price = sp.Price,
                                BuyerFirstName = sp.Buyer.FirstName,
                                BuyerLastName = sp.Buyer.LastName
                            })
                        .ToList()
                    })
                .OrderBy(s => s.LastName)
                .ThenBy(s => s.FirstName)
                .ToArray();

            var jsonString = JsonConvert.SerializeObject(users);
            return jsonString;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c =>
                    new CategoryDto
                    {
                        Name = c.Name,
                        ProductsCount = c.CategoryProducts.Count,
                        TotalPrices = c.CategoryProducts
                            .Select(cp => cp.Product.Price).Sum()
                    })
                .OrderByDescending(c => c.ProductsCount)
                .ToArray();

            var jsonString = JsonConvert.SerializeObject(categories);
            return jsonString;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId != null))
                .OrderByDescending(u => u.ProductsSold.Count(ps => ps.BuyerId != null))
                .Select(u =>
                    new
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age,
                        SoldProducts = new
                        {
                            Count = u.ProductsSold
                            .Count(ps => ps.BuyerId != null),
                            Products = u.ProductsSold
                            .Where(ps => ps.BuyerId != null)
                            .Select(ps =>
                                new 
                                {
                                    Name = ps.Name,
                                    Price = ps.Price
                                })
                            .ToArray()
                        }
                    })
                    .ToArray();

            var usersWithProducts = new
            {
                UsersCount = users.Length,
                Users = users
            };

            var contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonString = JsonConvert.SerializeObject(
                usersWithProducts,
                new JsonSerializerSettings
                {
                    ContractResolver = contractResolver,
                    NullValueHandling = NullValueHandling.Ignore
                });

            return jsonString;
        }
    }
}