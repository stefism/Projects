using System;
using System.Globalization;

namespace EgnHelper
{
    public class EgnInformation
    {
        public EgnInformation(string placeOfBirth, DateTime dateOfBirth, Sex sex)
        {
            PlaceOfBirth = placeOfBirth;
            DateOfBirth = dateOfBirth;
            Sex = sex;
        }

        public string PlaceOfBirth { get; }
        public DateTime DateOfBirth { get; }
        public Sex Sex { get; }

        public override string ToString()
        {
            string sexAsText = Sex switch
            {
                Sex.Male => "мъж",
                Sex.Female => "жена",
            };

            string sufix = Sex switch
            {
                Sex.Male => "роден",
                Sex.Female => "родена",
            };

            return $"ЕГН на {sexAsText}, {sufix} на {DateOfBirth.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("bg-BG"))} г. в регион {PlaceOfBirth}";
        }
    }
}