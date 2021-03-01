using Calendar.App.ViewModels;
using System.Threading.Tasks;

namespace Calendar.App.Services
{
    public interface IPriceService
    {
        Task<PricesAndUserReservationsViewModel> ReturnPrices();

        Task<decimal> ReturnActualPrice(bool isNonWorkDay);
    }
}
