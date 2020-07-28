using RealEstates.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstates.Services.Contracts
{
    public interface IPropertiesService
    {
        void Create(string district, int size, int? year, int price, string propertyType, string buildingType, int? floor, int? maxFloors);

        void UpdateTags(int propertyId);

        IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int maxSize);

        IEnumerable<PropertyViewModel> SearchByPrice(int minPrice, int maxPrice);
    }
}
