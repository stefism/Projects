using System;
using System.Collections.Generic;
using System.Text;

namespace _04_HotelReservation
{
    public class PriceCalculator
    {
        public Season Season { get; set; }

        public static double GetTotalPrice(double pricePerDay,
            int numberOfDays, Season season, Discount discount)
        {
            double totalPrice = 0;
            totalPrice = (pricePerDay * numberOfDays) * (double)season;

            if (discount != Discount.None)
            {
                double vipDiscount = totalPrice * (double)discount / 100;
                totalPrice -= vipDiscount;
            }

            return totalPrice;
        }
    }
}
