namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.Linq;
    using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var genres = context.Genres
				.ToArray()
				.Select(gr => new
				{
					Id = gr.Id,
					Genre = gr.Name,
					Games = gr.Games.Select(gm => new
					{
						Id = gm.Id,
						Title = gm.Name,
						Developer = gm.Developer.Name,
						Tags = string.Join(", ", gm.GameTags.Select(t => t.Tag.Name)),
						Players = gm.Purchases.Count()
					}).Where(gm => gm.Players > 0)
						.OrderByDescending(g => g.Players).ThenBy(g => g.Id),
					TotalPlayers = gr.Games.Select(x => x.Purchases.Count()).Sum()
				}).ToArray()
				.OrderByDescending(g => g.TotalPlayers).ThenBy(g => g.Id)
				.Where(gr => genreNames.Any(n => n == gr.Genre))
				.ToArray();

			string json = JsonConvert.SerializeObject(genres, Formatting.Indented);

			return json;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
            #region users
            var users = context.Users	
				.ToArray()
				.Select(u => new ExportUserPurchases_UserDto
				{
					Username = u.Username,
					Purchases = u.Cards
					.SelectMany(c => c.Purchases)
					.Select(p => new ExportUserPurchases_PurchaseDto 
					{
						Card = p.Card.Number,
						Cvc = p.Card.Cvc,
						Date = p.Date.ToString("yyyy-MM-dd HH:mm"),
						Game = new ExportUserPurchases_GameDto
                        {
							Title = p.Game.Name,
							Genre = p.Game.Genre.Name,
							Price = p.Game.Price
                        }}).OrderBy(p => p.Date)
					.ToArray(),
					TotalSpent = u.Cards.SelectMany(c => c.Purchases.Select(p => p.Game.Price)).Sum()
				}).Where(u => u.Purchases.Count() > 0)
				.OrderByDescending(u => u.TotalSpent).ThenBy(u => u.Username)
				.ToArray();
            #endregion

            return "123";
		}
	}
}