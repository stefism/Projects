using AutoMapper;
using Calendar.App.Data;
using Calendar.App.Services;
using Calendar.Tests.Common;
using Funeral.App.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Calendar.Tests
{
    public class DataServiceTests
    {
        private readonly IMapper mapper;

        public DataServiceTests()
        {
            mapper = AutoMapperTestConfig.ConfigureMapper();
        }

        [Fact]
        public async Task TestReleaseReservationMethod()
        {
            //Assert
            var virtualDbContext = InMemoryContextHelpers.GetCleanInMemoryDbContext();
            var dateRepository = new EFRepository<Date>(virtualDbContext);
            var priceRepository = new EFRepository<Price>(virtualDbContext);
            var priceService = new PriceService(dateRepository, priceRepository);
            var dataService = new DataService(mapper, priceService, dateRepository, priceRepository);

            await dataService.AddAvailableDate(DateTime.Now, true, "User Id 1");
            await dataService.AddAvailableDate(DateTime.Now.AddDays(1), false, "User Id 2");
            await dateRepository.SaveChangesAsync();

            var textId = dateRepository.All()
                .Select(t => t.Id).FirstOrDefault();

            //Act
            await dataService.ReleaseReservation(textId);
            await dateRepository.SaveChangesAsync();

            //Assert
            var dbCount = dateRepository.All().Count();
            Assert.Equal(1, dbCount);
        }

        [Fact]
        public async Task TestShowUserReservationMethod()
        {
            var virtualDbContext = InMemoryContextHelpers.GetCleanInMemoryDbContext();
            var dateRepository = new EFRepository<Date>(virtualDbContext);
            var priceRepository = new EFRepository<Price>(virtualDbContext);
            var priceService = new PriceService(dateRepository, priceRepository);
            var dataService = new DataService(mapper, priceService, dateRepository, priceRepository);

            await dataService.AddAvailableDate(DateTime.Now, true, "User Id 1");
            await dataService.AddAvailableDate(DateTime.Now.AddDays(1), false, "User Id 2");
            await dateRepository.SaveChangesAsync();

            var reservations = await dataService.ShowUserReservations("User Id 1");

            var count = reservations.Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task TestShowAllReservationMethod()
        {
            var virtualDbContext = InMemoryContextHelpers.GetCleanInMemoryDbContext();
            var dateRepository = new EFRepository<Date>(virtualDbContext);
            var priceRepository = new EFRepository<Price>(virtualDbContext);
            var priceService = new PriceService(dateRepository, priceRepository);
            var dataService = new DataService(mapper, priceService, dateRepository, priceRepository);

            await dataService.AddAvailableDate(DateTime.Now, true, "User Id 1");
            await dataService.AddAvailableDate(DateTime.Now.AddDays(1), false, "User Id 2");
            await dateRepository.SaveChangesAsync();

            var reservations = await dataService.ShowAllReservations();

            var count = reservations.Count();

            Assert.Equal(2, count);
        }

        [Fact]
        public void TestIsNonWorkDayMethod()
        {
            var virtualDbContext = InMemoryContextHelpers.GetCleanInMemoryDbContext();
            var dateRepository = new EFRepository<Date>(virtualDbContext);
            var priceRepository = new EFRepository<Price>(virtualDbContext);
            var priceService = new PriceService(dateRepository, priceRepository);
            var dataService = new DataService(mapper, priceService, dateRepository, priceRepository);

            var workDay = new DateTime(2021, 02, 04);
            var nonWorkDay = new DateTime(2021, 01, 31);

            var isNoneWorkDay = dataService.IsNonWorkDay(workDay);
            Assert.False(isNoneWorkDay);

            isNoneWorkDay = dataService.IsNonWorkDay(nonWorkDay);
            Assert.True(isNoneWorkDay);
        }

        [Fact]
        public async Task TestGetReservedDatesMethod()
        {
            var virtualDbContext = InMemoryContextHelpers.GetCleanInMemoryDbContext();
            var dateRepository = new EFRepository<Date>(virtualDbContext);
            var priceRepository = new EFRepository<Price>(virtualDbContext);
            var priceService = new PriceService(dateRepository, priceRepository);
            var dataService = new DataService(mapper, priceService, dateRepository, priceRepository);

            await dataService.AddAvailableDate(new DateTime(2021, 02, 04), true, "User Id 1");
            await dataService.AddAvailableDate(new DateTime(2021, 01, 31), false, "User Id 2");
            await dateRepository.SaveChangesAsync();

            var dates = await dataService.GetReservedDates(2021, 01);

            var count = dates.Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task TestChangePrices()
        {
            var virtualDbContext = InMemoryContextHelpers.GetCleanInMemoryDbContext();
            var dateRepository = new EFRepository<Date>(virtualDbContext);
            var priceRepository = new EFRepository<Price>(virtualDbContext);
            var priceService = new PriceService(dateRepository, priceRepository);
            var dataService = new DataService(mapper, priceService, dateRepository, priceRepository);

            var prices = await priceRepository.All().FirstOrDefaultAsync();
            Assert.Null(prices);

            await dataService.ChangePrices(5, 10);

            prices = await priceRepository.All().FirstOrDefaultAsync();

            Assert.Equal(5, prices.WorkDay);
            Assert.Equal(10, prices.NonWorkDay);

            await dataService.ChangePrices(4, 7);

            prices = await priceRepository.All().FirstOrDefaultAsync();

            Assert.Equal(4, prices.WorkDay);
            Assert.Equal(7, prices.NonWorkDay);
        }
    }
}
