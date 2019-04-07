namespace VaporStore
{
    using AutoMapper;
    using System;
    using System.Globalization;
    using System.Linq;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Export;

    public class VaporStoreProfile : Profile
	{
		// Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
		public VaporStoreProfile()
		{
            CreateMap<Game, ExportJsonGameDto>()
                .ForMember(
                    dest => dest.Developer,
                    opt => opt.MapFrom(src => src.Developer.Name))
                .ForMember(
                    dest => dest.Tags,
                    opt => opt.MapFrom(src => string.Join(", ", src.GameTags.Select(gt => gt.Tag.Name))))
                .ForMember(
                    dest => dest.Players,
                    opt => opt.MapFrom(src => src.Purchases.Count));

            CreateMap<Genre, ExportJsonGenreDto>()
                 .ForMember(
                    dest => dest.TotalPlayers,
                    opt => opt.MapFrom(src => src.Games.Sum(x => x.Purchases.Count)))
                .ForMember(dto => dto.Games,
                    opt => opt.MapFrom(src =>
                        src.Games
                            .Where(g => g.Purchases.Any())
                            .OrderByDescending(g => g.Purchases.Count)
                            .ThenBy(g => g.Id)));
        }
    }
}