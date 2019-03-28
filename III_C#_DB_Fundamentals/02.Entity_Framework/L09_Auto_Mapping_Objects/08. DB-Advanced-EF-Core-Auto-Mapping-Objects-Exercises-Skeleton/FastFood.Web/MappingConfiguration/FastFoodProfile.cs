namespace FastFood.Web.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Web.ViewModels.Categories;
    using FastFood.Web.ViewModels.Employees;
    using FastFood.Web.ViewModels.Items;
    using Models;

    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(
                    dest => dest.Name, 
                    opt => opt.MapFrom(src => src.PositionName)
                );

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(
                    dest => dest.Name, 
                    opt => opt.MapFrom(src => src.Name)
                );

            //Employees
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(
                    dest => dest.PositionId, 
                    opt => opt.MapFrom(src => src.Id)
                );

            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(
                    dest => dest.Position,
                    opt => opt.MapFrom(src => src.Position.Name)
                );

            //Category
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.CategoryName)
                );

            this.CreateMap<Category, CategoryAllViewModel>();

            //Item
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(
                    dest => dest.CategoryId,
                    opt => opt.MapFrom(src => src.Id)
                );

            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(
                    dest => dest.Category,
                    opt => opt.MapFrom(src => src.Category.Name)
                );
        }
    }
}
