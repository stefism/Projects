using Calendar.App.ErrMessages;
using System;
using System.ComponentModel.DataAnnotations;

namespace Calendar.App.ViewModels
{
    public class GetReservedDaysInputModel
    {
        [Range(1900, 2100, ErrorMessage = ErrorMessages.InvalidYear)]
        public int Year { get; set; }

        [Range(1, 12, ErrorMessage = ErrorMessages.InvalidMonth)]
        public int Month { get; set; }
    }
}
