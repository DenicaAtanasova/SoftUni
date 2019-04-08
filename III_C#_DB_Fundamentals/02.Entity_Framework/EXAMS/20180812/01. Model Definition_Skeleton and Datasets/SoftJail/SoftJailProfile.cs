namespace SoftJail
{
    using AutoMapper;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ExportDto;
    using System.Globalization;
    using System.Linq;

    public class SoftJailProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public SoftJailProfile()
        {
            CreateMap<Officer, ExportOfficerDto>()
                .ForMember(
                    dest => dest.OfficerName,
                    opt => opt.MapFrom(src => src.FullName))
                .ForMember(
                    dest => dest.Department,
                    opt => opt.MapFrom(src => src.Department.Name)
                );

            CreateMap<Prisoner, ExportPrisonerDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.FullName))
                .ForMember(
                    dest => dest.CellNumber,
                    opt => opt.MapFrom(src => src.Cell.CellNumber))
                .ForMember(
                    dest => dest.Officers,
                    opt => opt.MapFrom(src => src.PrisonerOfficers
                        .Select(po => po.Officer)
                        .OrderBy(o => o.FullName)))
                .ForMember(
                    dest => dest.TotalOfficerSalary,
                    opt => opt.MapFrom(src => src.PrisonerOfficers
                        .Sum(o => o.Officer.Salary)));
        }
    }
}
