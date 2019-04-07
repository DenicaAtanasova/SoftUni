namespace VaporStore.DataProcessor
{
	using Data;
    using Newtonsoft.Json;
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            var gamesDto = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            var sb = new StringBuilder();

            var games = new List<Game>();

            foreach (var gameDto in gamesDto)
            {
                if (!isValid(gameDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var developer = GetDeveloper(context, gameDto.Developer);
                var genre = GetGenre(context, gameDto.Genre);

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = developer,
                    Genre = genre
                };

                foreach (var currentTag in gameDto.Tags)
                {
                    var tag = GetTag(context, currentTag);

                    game.GameTags.Add(new GameTag
                    {
                        Tag = tag
                    });
                }

                games.Add(game);

                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
		}

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            var usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            var sb = new StringBuilder();

            var users = new List<User>();
            foreach (var userDto in usersDto)
            {
                if (!isValid(userDto) || !userDto.Cards.All(isValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                foreach (var cardDto in userDto.Cards)
                {
                    user.Cards.Add(new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = Enum.Parse<CardType>(cardDto.Type)
                    });
                }

                users.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
		}

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            var serializer = new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));

            var sb = new StringBuilder();
            var purchases = new List<Purchase>();

            var purchasesDto = (ImportPurchaseDto[])serializer.Deserialize(new StringReader(xmlString));

            foreach (var purchaseDto in purchasesDto)
            {
                var card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card);
                var game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title);

                if (!isValid(purchaseDto) || card == null || game == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var purchase = new Purchase
                {
                    Type = Enum.Parse<PurchaseType>(purchaseDto.Type),
                    ProductKey = purchaseDto.Key,
                    Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Card = card,
                    Game = game
                };

                purchases.Add(purchase);
                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool isValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResults, true);

            return isValid;
        }

        private static Genre GetGenre(VaporStoreDbContext context, string gameDtoGenre)
        {
            var genre = context
                .Genres
                .FirstOrDefault(g => g.Name == gameDtoGenre);

            if (genre == null)
            {
                genre = new Genre
                {
                    Name = gameDtoGenre
                };

                context.Genres.Add(genre);
                context.SaveChanges();
            }

            return genre;
        }

        private static Developer GetDeveloper(VaporStoreDbContext context, string gameDtoDeveloper)
        {
            var developer = context
                .Developers
                .FirstOrDefault(d => d.Name == gameDtoDeveloper);

            if (developer == null)
            {
                developer = new Developer
                {
                    Name = gameDtoDeveloper
                };

                context.Developers.Add(developer);
                context.SaveChanges();
            }

            return developer;
        }

        private static Tag GetTag(VaporStoreDbContext context, string gameDtoTags)
        {
            var tag = context
                .Tags
                .FirstOrDefault(g => g.Name == gameDtoTags);

            if (tag == null)
            {
                tag = new Tag
                {
                    Name = gameDtoTags
                };

                context.Tags.Add(tag);
                context.SaveChanges();
            }

            return tag;
        }
    }
}