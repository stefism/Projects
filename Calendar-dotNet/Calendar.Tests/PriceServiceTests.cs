using AutoMapper;
using Calendar.App.Data;
using Calendar.App.Services;
using Calendar.Tests.Common;
using Funeral.App.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Calendar.Tests
{
    public class PriceServiceTests
    {
        private readonly IMapper mapper;

        public PriceServiceTests()
        {
            mapper = AutoMapperTestConfig.ConfigureMapper();
        }

        [Theory]
        [InlineData(true, 10)]
        [InlineData(false, 5)]
        public async Task TestReturnActualPriceMethod(bool isNonWorkDay, decimal result)
        {
            var virtualDbContext = InMemoryContextHelpers.GetCleanInMemoryDbContext();
            var dateRepository = new EFRepository<Date>(virtualDbContext);
            var priceRepository = new EFRepository<Price>(virtualDbContext);
            var priceService = new PriceService(dateRepository, priceRepository);

            var prices = await priceRepository.All().FirstOrDefaultAsync();
            Assert.Null(prices);
            var dataService = new DataService(mapper, priceService, dateRepository, priceRepository);

            var price = await priceService.ReturnActualPrice(isNonWorkDay);
            Assert.Equal(0, price);

            await dataService.ChangePrices(5, 10);

            price = await priceService.ReturnActualPrice(isNonWorkDay);
            Assert.Equal(result, price);
        }

        [Fact]
        public async Task TestReturnPricesMethod()
        {
            var virtualDbContext = InMemoryContextHelpers.GetCleanInMemoryDbContext();
            var dateRepository = new EFRepository<Date>(virtualDbContext);
            var priceRepository = new EFRepository<Price>(virtualDbContext);
            var priceService = new PriceService(dateRepository, priceRepository);

            var dataService = new DataService(mapper, priceService, dateRepository, priceRepository);

            await dataService.ChangePrices(5, 10);

            await dataService.AddAvailableDate(DateTime.Now, true, "User Id 1");
            await dataService.AddAvailableDate(DateTime.Now.AddDays(1), false, "User Id 2");
            await dateRepository.SaveChangesAsync();

            var prices = await priceService.ReturnPrices();

            Assert.Equal(5, prices.WorkDay);
            Assert.Equal(10, prices.NonWorkDay);
            Assert.Equal("15", prices.TotalAmount.ToString());
        }

        [Fact]
        public async Task TestReturnPricesMethodIfPricessIsNull()
        {
            var virtualDbContext = InMemoryContextHelpers.GetCleanInMemoryDbContext();
            var dateRepository = new EFRepository<Date>(virtualDbContext);
            var priceRepository = new EFRepository<Price>(virtualDbContext);
            var priceService = new PriceService(dateRepository, priceRepository);

            var dataService = new DataService(mapper, priceService, dateRepository, priceRepository);

            //await dataService.ChangePrices(5, 10);

            await dataService.AddAvailableDate(DateTime.Now, true, "User Id 1");
            await dataService.AddAvailableDate(DateTime.Now.AddDays(1), false, "User Id 2");
            await dateRepository.SaveChangesAsync();

            var prices = await priceService.ReturnPrices();

            Assert.Equal(0, prices.WorkDay);
            Assert.Equal(0, prices.NonWorkDay);
            Assert.Equal("0.00", prices.TotalAmount.ToString());
        }
    }
}
