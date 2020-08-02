using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    public class CarWithpartsCarDto
    {
        
        public string Make { get; set; }

        
        public string Model { get; set; }

        
        public long TraveledDistance { get; set; }

        
        public List<CarWithPartsPartDto> Parts { get; set; }
    }
}
