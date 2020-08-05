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
            //
        {
            var sb = new StringBuilder();

            var writersDtos = JsonConvert
                .DeserializeObject<ImportWriterDto[]>(jsonString);

            List<Writer> writers = new List<Writer>();

            foreach (var writerDto in writersDtos)
            {
                if (!IsValid(writerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Writer writer = new Writer
                {
                    Name = writerDto.Name,
                    Pseudonym = writerDto.Pseudonym
                };

                writers.Add(writer);
                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var producerAlbumsDtos = JsonConvert
                .DeserializeObject<ImportProducerDto[]>(jsonString);

            List<Producer> producers = new List<Producer>();

            foreach (var producerDto in producerAlbumsDtos)
            {
                if (!IsValid(producerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                List<Album> validAlbums = new List<Album>();

                foreach (var albumDto in producerDto.Albums)
                {
                    bool isAlbumValid = true;

                    if (!IsValid(albumDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        isAlbumValid = false;
                        break;
                    }

                    DateTime albumReleaseDate;

                    bool isAlbumReleaseDateValid = DateTime
                        .TryParseExact(albumDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out albumReleaseDate);

                    if (!isAlbumReleaseDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        isAlbumValid = false;
                        break;
                    }

                    if (isAlbumValid)
                    {
                        var album = new Album
                        {
                            Name = albumDto.Name,
                            ReleaseDate = albumReleaseDate
                        };

                        validAlbums.Add(album);
                    }                   
                }

                Producer producer = new Producer
                {
                    Name = producerDto.Name,
                    Pseudonym = producerDto.Pseudonym,
                    PhoneNumber = producerDto.PhoneNumber,
                    Albums = validAlbums
                };

                producers.Add(producer);

                if (string.IsNullOrEmpty(producer.PhoneNumber))
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

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(ImportSongDto[]), new XmlRootAttribute("Songs"));

            using (var sr = new StringReader(xmlString))
            {
                var songsDtos = (ImportSongDto[])serializer.Deserialize(sr);

                List<Song> validSongs = new List<Song>();

                foreach (var songDto in songsDtos)
                {
                    if (!IsValid(songDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var album = context.Albums
                        .FirstOrDefault(a => a.Id == songDto.AlbumId);

                    var writer = context.Writers
                        .FirstOrDefault(w => w.Id == songDto.WriterId);

                    if (album == null || writer == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime createdOn;

                    bool isCreatedOnValid = DateTime
                        .TryParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out createdOn);

                    if (!isCreatedOnValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    TimeSpan duration;

                    bool isDurationValid = TimeSpan
                        .TryParseExact(songDto.Duration, "c", CultureInfo.InvariantCulture, out duration);

                    if (!isDurationValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    object genre; 
                    
                    bool isGenreValid = Enum.TryParse(typeof(Genre), songDto.Genre, false, out genre);

                    if (!isGenreValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    string genreToString = genre.ToString();

                    if (genreToString != "Blues" 
                        || genreToString != "Rap"
                        || genreToString != "PopMusic" 
                        || genreToString != "Rock"
                        || genreToString != "Jazz")
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Song song = new Song
                    {
                        Name = songDto.Name,                        
                        Duration = duration,
                        CreatedOn = createdOn,
                        Genre = (Genre)Enum.Parse(typeof(Genre), genreToString),
                        AlbumId = songDto.AlbumId,
                        WriterId = songDto.WriterId,
                        Price = songDto.Price
                    };

                    validSongs.Add(song);
                    sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
                }

                context.Songs.AddRange(validSongs);
                context.SaveChanges();

                return sb.ToString().TrimEnd();
            }
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(ImportPerformerDto[]), new XmlRootAttribute("Performers"));

            using (var sr = new StringReader(xmlString))
            {
                var performersDtos = (ImportPerformerDto[])serializer.Deserialize(sr);

                var validPerformers = new List<Performer>();
                var validSongPerformer = new List<SongPerformer>();

                foreach (var performerDto in performersDtos)
                {
                    if (IsValid(performerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                    }

                    List<int> songsDtoIds = performerDto
                        .PerformersSongs.Select(s => s.Id).ToList();

                    List<int> songsIdInDb = context.Songs
                        .Select(s => s.Id).ToList();                                        

                    foreach (var songDtoId in songsDtoIds)
                    {
                        if (!songsIdInDb.Contains(songDtoId))
                        {
                            sb.AppendLine(ErrorMessage);                            
                            break;
                        }

                        var song = context.Songs
                            .FirstOrDefault(s => s.Id == songDtoId);                        

                        var performer = new Performer
                        {
                            FirstName = performerDto.FirstName,
                            LastName = performerDto.LastName,
                            Age = performerDto.Age,
                            NetWorth = performerDto.NetWorth,                            
                        };

                        validPerformers.Add(performer);

                        var songPerformer = new SongPerformer
                        {
                            PerformerId = performer.Id,
                            SongId =song.Id
                        };

                        validSongPerformer.Add(songPerformer);

                        sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName, songsDtoIds.Count));
                    }                                 
                }

                context.Performers.AddRange(validPerformers);
                context.SongsPerformers.AddRange(validSongPerformer);
                
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