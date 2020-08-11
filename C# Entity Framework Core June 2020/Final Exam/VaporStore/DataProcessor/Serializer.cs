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


			var users = context.Users	
				.ToArray()
				.Select(u => new ExportUserPurchases_UserDto
				{
					Username = u.Username,
					Purchases = u.Cards.Select(c => new ExportUserPurchases_PurchaseDto 
					{
						Card = c.Number,
						Cvc = c.Cvc,
						Date = c.Purchases.Select(p => p.Date.ToString("yyyy-MM-dd HH:mm")).FirstOrDefault(),
						Game = c.Purchases.Select(g => new ExportUserPurchases_GameDto 
						{
							Title = g.Game.Name,
							Genre = g.Game.Genre.Name,
							Price = g.Game.Price
						}).FirstOrDefault()
					}).OrderBy(p => p.Date)
					.ToArray()
				})
				//.OrderByDescending(u => u.Purchases.Select(p => p.Game.Price).Sum()).ThenBy(u => u.Username)
				.ToArray();

			return "123";
		}
	}
}