namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter 
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone 
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong 
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersDto = JsonConvert.DeserializeObject<ImportWriterDto[]>(jsonString);

            var sb = new StringBuilder();

            var writers = new List<Writer>();

            foreach (var dto in writersDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = AutoMapper.Mapper.Map<Writer>(dto);

                writers.Add(writer);

                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersDto = JsonConvert.DeserializeObject<ImportProducerDto[]>(jsonString);

            var producers = new List<Producer>();
            var sb = new StringBuilder();

            foreach (var dto in producersDto)
            {
                if (!IsValid(dto) || !dto.Albums.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var producer = new Producer
                {
                    Name = dto.Name,
                    PhoneNumber = dto.PhoneNumber,
                    Pseudonym = dto.Pseudonym
                };

                foreach (var albumDto in dto.Albums)
                {
                    var album = new Album
                    {
                        Name = albumDto.Name,
                        ReleaseDate = DateTime.ParseExact(albumDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    };

                    producer.Albums.Add(album);
                }

                producers.Add(producer);
                if (producer.PhoneNumber == null)
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count));
                }
                else
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count));
                }
                
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportSongDto[]), new XmlRootAttribute("Songs"));

            var sb = new StringBuilder();
            var songs = new List<Song>();

            var songsDto = (ImportSongDto[])serializer.Deserialize(new StringReader(xmlString));

            foreach (var dto in songsDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var album = context.Albums.Find(dto.AlbumId);
                var writer = context.Writers.Find(dto.WriterId);

                if (album == null || writer == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = new Song
                {
                    Name = dto.Name,
                    Duration = TimeSpan.Parse(dto.Duration),
                    CreatedOn = DateTime.ParseExact(dto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre = Enum.Parse<Genre>(dto.Genre),
                    AlbumId = dto.AlbumId,
                    WriterId = dto.WriterId,
                    Price = dto.Price,                    
                };

                songs.Add(song);
                sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportPerformerDto[]), new XmlRootAttribute("Performers"));

            var sb = new StringBuilder();
            var performers = new List<Performer>();

            var performersDto = (ImportPerformerDto[])serializer.Deserialize(new StringReader(xmlString));
            var songIds = context.Songs.Select(s => s.Id);

            foreach (var dto in performersDto)
            {
                var isSongIdValid = dto.PerformersSongs.All(s => songIds.Contains(s.Id));
                if (!IsValid(dto) || !isSongIdValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var performer = new Performer
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                    NetWorth = dto.NetWorth
                };

                foreach (var songDto in dto.PerformersSongs)
                {
                    var song = GetSong(context, songDto.Id);

                    performer.PerformerSongs.Add(new SongPerformer
                    {
                        Song = song
                    });
                }

                performers.Add(performer);
                sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName, performer.PerformerSongs.Count));
            }

            context.Performers.AddRange(performers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        private static Song GetSong(MusicHubDbContext context, int songId)
        {
            var song = context
                .Songs
                .FirstOrDefault(s => s.Id == songId);

            //if (song == null)
            //{
            //    song = new Song
            //    {
                    
            //        Name = gameDtoTags
            //    };

            //    context.Tags.Add(tag);
            //    context.SaveChanges();
            //}

            return song;
        }

        public static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResults, true);

            return isValid;
        }
    }
}