using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Contracts;
using RealEstates.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RealEstates.Services
{
    public class PropertiesService : IPropertiesService
    {
        private RealEstateDbContext dbContext;

        public PropertiesService(RealEstateDbContext db)
        {
            dbContext = db;
        }

        public void Create(string district, int size, int? year, int price, string propertyType, string buildingType, int? floor, int? maxFloors)
        {
            var property = new RealEstateProperty
            {
                Size = size,
                Price = price,
                Year = year < 1800 ? null : year,
                Floor = floor <= 0 ? null : floor,
                TotalNumberOfFloors = maxFloors <= 0 ? null : maxFloors
            };

            // Където може ползвай тернарни. Спестяват код и някой път правят кода по-четим. По-долу е същото без тернарни.

            //if (property.Year < 1800)
            //{
            //    property.Year = null;
            //} // Прави същото като горе тернарния оператор.

            //if (property.Floor <= 0)
            //{
            //    property.Floor = null;
            //}

            //if (property.TotalNumberOfFloors <= 0)
            //{
            //    property.TotalNumberOfFloors = null;
            //}

            var districtEntity = dbContext.Districts
                .FirstOrDefault(d => d.Name.Trim() == district.Trim());

            if (districtEntity == null)
            {
                districtEntity = new District
                {
                    Name = district
                };
            }

            property.District = districtEntity;

            var propertyTypeEntity = dbContext.PropertyTypes
                .FirstOrDefault(pt => pt.Name.Trim() == propertyType.Trim());

            if (propertyTypeEntity == null)
            {
                propertyTypeEntity = new PropertyType
                {
                    Name = propertyType
                };
            }

            property.PropertyType = propertyTypeEntity;

            var buildindTypeEntity = dbContext.BuildingTypes
                .FirstOrDefault(bt => bt.Name.Trim() == buildingType.Trim());

            if (buildindTypeEntity == null)
            {
                buildindTypeEntity = new BuildingType
                {
                    Name = buildingType
                };
            }

            property.BuildingType = buildindTypeEntity;

            dbContext.RealEstateProperties.Add(property);
            dbContext.SaveChanges();
            //Нещата, които са в други таблици, първо трябва да се провери дали ги има в другите таблици и ако ги няма, да се добавят. Ако ги има, се взимат от пак от другите таблици и се сетват на главното ентити, което вкарваме като запис в таблицата.

            UpdateTags(property.Id);
        }

        public IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int maxSize)
        {
            var properties = dbContext.RealEstateProperties
                .Where(p => p.Year >= minYear && p.Year <= maxYear
                && p.Size >= minSize && p.Size <= maxSize)
                .Select(MapToPropertyViewModel()).OrderBy(p => p.Price)
                .ToList();

            return properties;
        }        

        public IEnumerable<PropertyViewModel> SearchByPrice(int minPrice, int maxPrice)
        {
            var properties = dbContext.RealEstateProperties
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .Select(MapToPropertyViewModel()).OrderBy(p => p.Price)
                .ToList();

            return properties;
        }

        public void UpdateTags(int propertyId)
        {
            var property = dbContext.RealEstateProperties
                .FirstOrDefault(p => p.Id == propertyId);
            property.Tags.Clear();

            if (property.Year.HasValue && property.Year < 1990)
            {
                property.Tags.Add(new RealEstatePropertyTag 
                {
                    Tag = GetOrCreateTag("Стара сграда")
                });
            }

            if (property.Size > 120)
            {
                property.Tags.Add(new RealEstatePropertyTag
                {
                    Tag = GetOrCreateTag("Голям")
                });
            }

            if (property.Year > 2018 && property.TotalNumberOfFloors > 5)
            {
                property.Tags.Add(new RealEstatePropertyTag
                {
                    Tag = GetOrCreateTag("Има гаражи")
                });
            }

            if (property.Floor == property.TotalNumberOfFloors)
            {
                property.Tags.Add(new RealEstatePropertyTag
                {
                    Tag = GetOrCreateTag("Последен етаж")
                });
            }

            if (((double)property.Price / property.Size) < 800)
            {
                property.Tags.Add(new RealEstatePropertyTag
                {
                    Tag = GetOrCreateTag("Супер евтин")
                });
            }

            if (((double)property.Price / property.Size) > 2000)
            {
                property.Tags.Add(new RealEstatePropertyTag
                {
                    Tag = GetOrCreateTag("Бахти скъпото")
                });
            }

            dbContext.SaveChanges();
        }

        private Tag GetOrCreateTag(string tag)
        {
            Tag tagDb = dbContext.Tags
                .FirstOrDefault(t => t.Name == tag);

            if (tagDb == null)
            {
                tagDb = new Tag { Name = tag };
            }

            return tagDb;
        }

        private static Expression<Func<RealEstateProperty, PropertyViewModel>> MapToPropertyViewModel()
        {
            return p => new PropertyViewModel
            {
                Price = p.Price,
                Floor = (p.Floor ?? 0).ToString() + "/" + (p.TotalNumberOfFloors ?? 0).ToString(), // (p.Floor ?? 0) -> ако етажа е null, слага стойност нула, ако не е null му взима стойността. Ако няма .ToString() гърми с грешка странна.
                Size = p.Size,
                Year = p.Year,
                BuildingType = p.BuildingType.Name,
                District = p.District.Name,
                PropertyType = p.PropertyType.Name
            };
        }
    }
}
