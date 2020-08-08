namespace VaporStore.DataProcessor
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
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {

            //var sb = new StringBuilder();

            //var gamesDtos = JsonConvert
            //	.DeserializeObject<ImportGamesDto[]>(jsonString);

            //var validGames = new List<Game>();

            //var validDev = new List<Developer>();
            //var validGenres = new List<Genre>();
            //var validTags = new List<Tag>();

            //         foreach (var gameDto in gamesDtos)
            //         {
            //             if (!IsValid(gameDto))
            //             {
            //		sb.AppendLine("Invalid Data");
            //		continue;
            //             }

            //             if (gameDto.Tags.Count() == 0)
            //             {
            //		sb.AppendLine("Invalid Data");
            //		continue;
            //	}



            //	var game = new Game
            //	{
            //		Name = gameDto.Name,
            //		Price = gameDto.Price,
            //		ReleaseDate = DateTime
            //			.ParseExact(gameDto.ReleaseDate,
            //			"yyyy-MM-dd", CultureInfo.InvariantCulture,
            //			DateTimeStyles.None)
            //	};

            //	//Developer add
            //             if (!validDev.Any(d => d.Name == gameDto.Developer))
            //             {
            //                 var dev = new Developer
            //                 {
            //                     Name = gameDto.Developer
            //                 };

            //                 validDev.Add(dev);

            //                 game.Developer.Name = gameDto.Developer;
            //             }
            //             else
            //             {
            //		var dev = validDev.FirstOrDefault(d => d.Name == gameDto.Developer);
            //		game.Developer.Name = dev.Name;
            //	}

            //             //Genres add
            //             if (!validGenres.Any(g => g.Name == gameDto.Genre))
            //             {
            //		var genre = new Genre
            //		{
            //			Name = gameDto.Genre
            //		};

            //		validGenres.Add(genre);
            //		game.Genre.Name = genre.Name;
            //             }
            //             else
            //             {
            //		var genre = validGenres.FirstOrDefault(g => g.Name == gameDto.Genre);
            //		game.Genre.Name = genre.Name;
            //             }

            //             //Tags add
            //             foreach (var tagDto in gameDto.Tags)
            //             {
            //                 if (!validTags.Any(t => t.Name == tagDto.Name))
            //                 {
            //			var tag = new Tag
            //			{
            //				Name = tagDto.Name
            //			};

            //			validTags.Add(tag);

            //			////// TODO: .....
            //                 }
            //             }
            //         }

            return "123";
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var usersDtos = JsonConvert
                .DeserializeObject<ImportUsersAndCardsDto[]>(jsonString);

            var validUsers = new List<User>();

            foreach (var userDto in usersDtos)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isCardValid = true;

                foreach (var card in userDto.Cards)
                {
                    if (!IsValid(card))
                    {
                        sb.AppendLine("Invalid Data");
                        isCardValid = false;
                        break;
                    }
                }

                if (!isCardValid)
                {
                    continue;
                }

                var user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age,
                    Cards = userDto.Cards
                };

                validUsers.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return sb.ToString().TrimEnd(); ;
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(ImportPurchasesDto[]), new XmlRootAttribute("Purchases"));

            using (var sr = new StringReader(xmlString))
            {
                var purcDto = (ImportPurchasesDto[])serializer.Deserialize(sr);

                List<Purchase> validPurch = new List<Purchase>();

                foreach (var purch in purcDto)
                {
                    if (!IsValid(purch))
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    var purchace = new Purchase
                    {
                        Game = new Game 
                        { 
                            Name = purch.Title
                        },
                        Type = (PurchaseType)Enum.Parse(typeof(PurchaseType), purch.Type),
                        ProductKey = purch.Key,
                        Date = DateTime
                        .ParseExact(purch.Date,
                        "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture,
                        DateTimeStyles.None),
                        Card = new Card
                        {
                            Number = purch.Card
                        }
                    };

                    validPurch.Add(purchace);
                    sb.AppendLine($"Imported {purchace.Game.Name} for {purchace.Card.User.Username}");
                }

                context.Purchases.AddRange(validPurch);
                context.SaveChanges();

                return sb.ToString().TrimEnd();
            }            
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}