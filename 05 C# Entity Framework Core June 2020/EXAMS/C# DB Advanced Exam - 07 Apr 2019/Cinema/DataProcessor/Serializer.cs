namespace Cinema.DataProcessor
{
    using System;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .ToArray()
                .Where(x => x.Rating >= rating &&
                                        x.Projections.Where(p => p.Tickets.Any()).Any())
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.Projections.SelectMany(projection => projection.Tickets.Select(ticket => ticket.Price)).Sum())
                .Select(movie => new 
                {
                    MovieName = movie.Title,
                    Rating = $"{movie.Rating:F2}",
                    TotalIncomes = $"{movie.Projections.SelectMany(projection => projection.Tickets.Select(ticket => ticket.Price)).Sum():F2}",
                    Customers = movie.Projections
                                        .SelectMany(projection => projection.Tickets)
                                        .Select(ticket => new
                                            {
                                                FirstName = ticket.Customer.FirstName,
                                                LastName = ticket.Customer.LastName,
                                                Balance = $"{ticket.Customer.Balance:F2}"
                                            })
                                            .OrderByDescending(x => x.Balance)
                                            .ThenBy(x => x.FirstName)
                                            .ThenBy(x => x.LastName)
                                            .ToArray()
                })
                .Take(10)
                .ToArray();

            #region movies_me
            var movies2 = context.Movies
                .ToArray()
                .Where(m => m.Rating >= rating)
                
                .OrderByDescending(m => m.Rating)
                .ThenByDescending(m => m.Projections.Select(p => p.Tickets.Sum(t => t.Price)).Sum())
                .Select(m => new
                {
                    MovieName = m.Title,

                    Rating = m.Rating.ToString("F2"),

                    TotalIncomes = m.Projections
                    .Select(p => p.Tickets.Sum(t => t.Price)).Sum().ToString("F2"),
                    
                    Customers = m.Projections
                    
                    .SelectMany(p => p.Tickets
                        .OrderByDescending(t => t.Customer.Balance)
                        .ThenBy(t => t.Customer.FirstName)
                        .ThenBy(t => t.Customer.LastName)
                        
                        .Select(t => new 
                    {
                        FirstName = t.Customer.FirstName,
                        LastName = t.Customer.LastName,
                        Balance = t.Customer.Balance.ToString("F2")
                    })
                        //.OrderByDescending(t => t.Balance)
                        //.ThenBy(t => t.FirstName)
                        //.ThenBy(t => t.LastName))
                        .ToArray())
                })
                    //.OrderByDescending(m => m.Rating)
                    //.ThenByDescending(m => m.TotalIncomes)
                .Take(10)
                .ToArray();
            #endregion

            string json = JsonConvert.SerializeObject(movies, Formatting.Indented);

            return json;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            throw new NotImplementedException();
        }
    }
}