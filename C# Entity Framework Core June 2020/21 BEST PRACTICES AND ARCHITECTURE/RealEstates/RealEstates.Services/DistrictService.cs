using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Contracts;
using RealEstates.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RealEstates.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly RealEstateDbContext dbContext;

        public DistrictService(RealEstateDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<DistrictViewModel> GetTopDistrictsByAveragePrice(int count = 10)
        {
            var districts = dbContext.Districts
                .Select(MapToDistrictViewModel())
                .OrderByDescending(d => d.AveragePrice)
                .Take(count).ToList();

            return districts;
        }
       
        public IEnumerable<DistrictViewModel> GetTopDistrictsByNumberOfProperties(int count = 10)
        {
            var districts = dbContext.Districts
                .Select(MapToDistrictViewModel())
                .OrderByDescending(d => d.PropertiesCount)
                .Take(count).ToList();

            return districts;
        }

        private static Expression<Func<District, DistrictViewModel>> MapToDistrictViewModel()
        {
            return d => new DistrictViewModel
            {
                Name = d.Name,
                MaxPrice = d.Properties.Max(p => p.Price),
                MinPrice = d.Properties.Min(p => p.Price),
                AveragePrice = d.Properties.Average(p => p.Price),
                PropertiesCount = d.Properties.Count()
            };
        }
    }
}
