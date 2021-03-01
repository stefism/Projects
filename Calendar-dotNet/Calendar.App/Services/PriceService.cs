using Calendar.App.Data;
using Calendar.App.ViewModels;
using Funeral.App.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.App.Services
{
    public class PriceService : IPriceService
    {
        private readonly IEFRepository<Date> dateRepository;
        private readonly IEFRepository<Price> pricePepository;

        public PriceService(
            IEFRepository<Date> dateRepository,
            IEFRepository<Price> pricePepository)
        {
            this.dateRepository = dateRepository;
            this.pricePepository = pricePepository;
        }

        public async Task<decimal> ReturnActualPrice(bool isNonWorkDay)
        {
            var prices = await pricePepository.All().FirstOrDefaultAsync();
            decimal currentPrice;

            if (prices == null)
            {
                return 0.00m;
            }

            if (isNonWorkDay)
            {
                currentPrice = prices.NonWorkDay;
            }
            else
            {
                currentPrice = prices.WorkDay;
            }

            return currentPrice;
        }
    
        public async Task<PricesAndUserReservationsViewModel> ReturnPrices()
        {
            var prices = await pricePepository.All()
                .Select(p => new PricesAndUserReservationsViewModel
            {
                WorkDay = p.WorkDay,
                NonWorkDay = p.NonWorkDay,
                TotalAmount = TotalAmount(),
            }).FirstOrDefaultAsync();

            if (prices == null)
            {
                prices = new PricesAndUserReservationsViewModel
                {
                    WorkDay = 0,
                    NonWorkDay = 0,
                    TotalAmount = TotalAmount(),
                };
            }

            return prices;
        }

        private string TotalAmount()
        {
            var totalSum = dateRepository.All()
                .Select(d => d.Price).Sum();

            return totalSum.ToString();
        }
    }
}
