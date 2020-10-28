﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Song")]
    public class ImportSongDto
    {
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        public string Duration { get; set; }

        public string CreatedOn { get; set; }

        public string Genre { get; set; }

        public int? AlbumId { get; set; }

        public int WriterId { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }
    }
}
