namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
            //Ok!
        {
            var sb = new StringBuilder();

            var moviesDtos = JsonConvert
                .DeserializeObject<ImportMoviesDto[]>(jsonString);

            var validMovies = new List<Movie>();

            foreach (var movieDto in moviesDtos)
            {
                if (validMovies.Any(m => m.Title == movieDto.Title))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!IsValid(movieDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title = movieDto.Title,
                    Genre = (Genre)Enum.Parse(typeof(Genre), movieDto.Genre),
                    Duration = TimeSpan.Parse(movieDto.Duration),
                    Rating = movieDto.Rating,
                    Director = movieDto.Director
                };

                validMovies.Add(movie);
                sb.AppendLine($"Successfully imported {movie.Title} with genre {movie.Genre} and rating {movie.Rating:F2}!");                
            }

            context.Movies.AddRange(validMovies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
            //Ok!
        {
            var sb = new StringBuilder();

            var hallsDtos = JsonConvert.DeserializeObject<ImportHallDto[]>(jsonString);

            var validHalls = new List<Hall>();

            foreach (var hallDto in hallsDtos)
            {
                if (!IsValid(hallDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallDto.Name,
                    Is4Dx = hallDto.Is4Dx,
                    Is3D = hallDto.Is3D
                };

                validHalls.Add(hall);

                List<Seat> seats = new List<Seat>();

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    var seat = new Seat
                    {
                        Hall = hall
                    };

                    seats.Add(seat);
                }              
                
                context.Seats.AddRange(seats);
                //context.SaveChanges();

                if (hall.Is3D == true && hall.Is4Dx == false)
                {
                    sb.AppendLine($"Successfully imported {hall.Name}(3D) with {hallDto.Seats} seats!");
                }                
                else if (hall.Is3D == false && hall.Is4Dx == true)
                {
                    sb.AppendLine($"Successfully imported {hall.Name}(4Dx) with {hallDto.Seats} seats!");
                }
                else if (hall.Is3D == true && hall.Is4Dx == true)
                {
                    sb.AppendLine($"Successfully imported {hall.Name}(4Dx/3D) with {hallDto.Seats} seats!");
                }
                else
                {
                    sb.AppendLine($"Successfully imported {hall.Name}(Normal) with {hallDto.Seats} seats!");
                }
            }

            context.Halls.AddRange(validHalls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {

            return "";
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            return "";
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}