using Calendar.App.ErrMessages;
using System;
using System.ComponentModel.DataAnnotations;

namespace Calendar.App.ViewModels
{
    public class ChangePricesInputModel
    {
        [Range(0.00, double.MaxValue, ErrorMessage = ErrorMessages.InvalidPrice)]
        public decimal Workday { get; set; }

        [Range(0.00, double.MaxValue, ErrorMessage = ErrorMessages.InvalidPrice)]
        public decimal Weekends { get; set; }
    }
}
