using RealEstates.Services.Contracts;
using RealEstates.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstates.Services
{
    public class DistrictService : IDistrictService
    {
        public IEnumerable<DistrictViewModel> GetTopDistrictsByAveragePrice(int count = 10)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DistrictViewModel> GetTopDistrictsByNumberOfProperties(int count = 10)
        {
            throw new NotImplementedException();
        }
    }
}
