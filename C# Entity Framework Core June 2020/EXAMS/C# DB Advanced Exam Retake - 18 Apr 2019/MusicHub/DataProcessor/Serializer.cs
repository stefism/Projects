namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.DataProcessor.ExportDtos;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
            //OK - Identical!
        {
            #region albums
            var albums = context.Albums
                //.ToList() // // САМО ЗАРАДИ ЖЪЖА!
                .Where(a => a.Producer.Id == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price.ToString("F2"),
                        Writer = s.Writer.Name
                    }).OrderByDescending(s => s.SongName)
                       .ThenBy(s => s.Writer),
                    AlbumPrice = a.Songs.Sum(s => s.Price).ToString("F2")
                }).OrderByDescending(a => a.AlbumPrice)
                .ToList();
            #endregion

            string json = JsonConvert.SerializeObject(albums, Formatting.Indented);

            return json;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
            //
        {           
            var songs = context.SongsPerformers
                //.ToList() // САМО ЗАРАДИ ЖЪЖА!
                .Where(sp => sp.Song.Duration.TotalSeconds > duration)
                .Select(sp => new ExportSongDto
                {
                    SongName = sp.Song.Name,
                    Writer = sp.Song.Writer.Name,
                    Performer = sp.Performer.FirstName + " " + sp.Performer.LastName,
                    AlbumProducer = sp.Song.Album.Producer.Name,
                    Duration = sp.Song.Duration.ToString("c")
                }).OrderBy(s => s.SongName).ThenBy(s => s.Writer)
                .ThenBy(s => s.Performer)
                .ToList();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(List<ExportSongDto>), new XmlRootAttribute("Songs"));

            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            using (var sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, songs, nameSpaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}