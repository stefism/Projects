using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class ImportTasksDto
    {
        [XmlElement("Name")]
        [Required, MinLength(2), MaxLength(40)]
        public string Name { get; set; }
        //•	Name - text with length [2, 40] (required)

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        [Required]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        [Required, Range(0, 3)]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType")]
        [Required, Range(0, 4)]
        public int LabelType { get; set; }
    }
}
