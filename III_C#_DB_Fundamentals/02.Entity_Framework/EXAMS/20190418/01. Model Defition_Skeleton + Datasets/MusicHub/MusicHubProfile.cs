namespace MusicHub
{
    using AutoMapper;
    using Data.Models;
    using DataProcessor.ImportDtos;

    public class MusicHubProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public MusicHubProfile()
        {
            CreateMap<ImportWriterDto, Writer>();
        }
    }
}
