namespace Cinema
{
    using AutoMapper;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ExportDto;
    using Cinema.DataProcessor.ImportDto;
    using System;
    using System.Linq;

    public class CinemaProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public CinemaProfile()
        {
            CreateMap<ImportMovieDto, Movie>()
                .ForMember(
                    dest => dest.Duration,
                    opt => opt.MapFrom(src => TimeSpan.Parse(src.Duration))
                )
                .ForMember(
                    dest => dest.Genre,
                    opt => opt.MapFrom(src => Enum.Parse<Genre>(src.Genre))
                );

            CreateMap<Customer, ExportCustomerDto>()
                .ForMember(
                    dest => dest.Balance,
                    opt => opt.MapFrom(src => src.Balance.ToString("F2"))
                );

            CreateMap<Movie, ExportMovieDto>()
                .ForMember(
                    dest => dest.TotalIncomes,
                    opt => opt.MapFrom(src => src.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"))
                )
                .ForMember(
                    dest => dest.Rating,
                    opt => opt.MapFrom(src => src.Rating.ToString("F2"))
                )
                 .ForMember(
                    dest => dest.Customers,
                    opt => opt.MapFrom(src => src.Projections.SelectMany(p => p.Tickets.Select(t => t.Customer))
                    .OrderByDescending(c => c.Balance.ToString("F2"))
                    .ThenBy(c => c.FirstName)
                    .ThenBy(c => c.LastName)
                ));

            CreateMap<Customer, ExportCustomerWithSpendingsDto>()
                .ForMember(
                    dest => dest.SpentMoney,
                    opt => opt.MapFrom(src => src.Tickets.Sum(t => t.Price).ToString("F2"))
                )
                 .ForMember(
                    dest => dest.SpentTime,
                    opt => opt.MapFrom(src => TimeSpan.FromSeconds(src.Tickets.Sum(t => t.Projection.Movie.Duration.TotalSeconds))
                        .ToString(@"hh\:mm\:ss"))
                );
        }
    }
}