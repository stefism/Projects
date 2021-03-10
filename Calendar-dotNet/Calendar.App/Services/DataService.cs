using AutoMapper;
using Calendar.App.Data;
using Calendar.App.ViewModels;
using Funeral.App.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.App.Services
{
    public class DataService : IDataService
    {
        private readonly IMapper mapper;
        private readonly IPriceService priceService;
        private readonly IEFRepository<Date> dateRepository;
        private readonly IEFRepository<Price> pricePepository;

        public DataService(
            IMapper mapper,
            IPriceService priceService,
            IEFRepository<Date> dateRepository,
            IEFRepository<Price> pricePepository)
        {
            this.mapper = mapper;
            this.priceService = priceService;
            this.dateRepository = dateRepository;
            this.pricePepository = pricePepository;
        }

        public async Task ReleaseReservation(string reservationId)
        {
            var reservation = await dateRepository.All()
                .Where(r => r.Id == reservationId).FirstOrDefaultAsync();

            dateRepository.Delete(reservation);

            await dateRepository.SaveChangesAsync();
        }

        public async Task<ICollection<UserReservationViewModel>> ShowUserReservations(string userId)
        {
            var resevrations = await dateRepository.All()
                .Where(r => r.UserId == userId)
                .Select(d => new UserReservationViewModel
                {
                    Username = d.User.UserName,
                    ReservationDateId = d.Id,
                    ReservedDate = d.ReservedDate,
                    Price = d.Price.ToString(),
                }).OrderBy(p => p.ReservedDate)
                .ToListAsync();

            return resevrations;
        }

        public async Task<ICollection<ReservationViewModel>> ShowAllReservations()
        {
            var reservations = await mapper
                .ProjectTo<ReservationViewModel>(dateRepository.All())
                .OrderBy(p => p.ReservedDate)
                .ToListAsync();

            return reservations;
        }

        public async Task AddAvailableDate(DateTime date, bool isNonWorkDay, string userId)
        {
            var actualPrice = await priceService.ReturnActualPrice(isNonWorkDay);

            var availableDate = new Date
            {
                ReservedDate = date,
                Price = actualPrice,
                UserId = userId,
                IsNonWorkDay = isNonWorkDay,
            };

            await dateRepository.AddAsync(availableDate);
            await dateRepository.SaveChangesAsync();
        }

        public bool IsNonWorkDay(DateTime date)
        {
            var day = date.DayOfWeek;
            bool IsNonWorkDay = false;

            if (day == DayOfWeek.Sunday || day == DayOfWeek.Saturday)
            {
                IsNonWorkDay = true;
            }

            return IsNonWorkDay;
        }

        public async Task<ICollection<ReservationViewModel>> GetReservedDates(int year, int month)
        {
            var dates = await mapper
                .ProjectTo<ReservationViewModel>(dateRepository.All())
                .Where(x => x.ReservedDate.HasValue &&
                              x.ReservedDate.Value.Year == year &&
                              x.ReservedDate.Value.Month == month)
                .ToListAsync();

            return dates;
        }

        public async Task ChangePrices(decimal workday, decimal weekends)
        {
            var prices = await pricePepository.All().FirstOrDefaultAsync();

            if (prices == null)
            {
                prices = new Price
                {
                    WorkDay = workday,
                    NonWorkDay = weekends,
                };

                await pricePepository.AddAsync(prices);
            }
            else
            {
                prices.WorkDay = workday;
                prices.NonWorkDay = weekends;
            }

            await pricePepository.SaveChangesAsync();
        }
    }
}
