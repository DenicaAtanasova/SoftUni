using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //Import
            CreateMap<ImportUserDto, User>();

            CreateMap<ImportProductDto, Product>();

            CreateMap<ImportCategoryDto, Category>();

            CreateMap<ImportCategoryProductDto, CategoryProduct>();

            //Export
            CreateMap<Product, ExportProductInRangeDto>()
                .ForMember(
                    dest => dest.Buyer,
                    opt => opt.MapFrom(src => src.Buyer.FirstName + " " + src.Buyer.LastName));

            CreateMap<User, ExportSellerDto>();

            CreateMap<Product, ExportSoldProductDto>();

            CreateMap<Category, ExportCategoryByProductsCountDto>()
                .ForMember(
                    dest => dest.Count,
                    opt => opt.MapFrom(src => src.CategoryProducts.Count))
                .ForMember(
                    dest => dest.TotalRevenue,
                    opt => opt.MapFrom(src => src.CategoryProducts
                        .Select(cp => cp.Product.Price).Sum()))
                .ForMember(
                    dest => dest.AveragePrice,
                    opt => opt.MapFrom(src => src.CategoryProducts
                        .Average(cp => cp.Product.Price)));
        }
    }
}
