using System;
using System.Collections.Generic;

namespace EgnHelper
{
    public class EgnInformationExtractor
    {
        private IEgnValidator egnValidator;

        private SortedDictionary<int, string> cities = new SortedDictionary<int, string>()
        {
            { 43, "Благоевград"},
            { 93, "Бургас"},
            { 139, "Варна"},
            { 169, "Велико Търново"},
            { 183, "Видин"},
            { 217, "Враца"},
            { 233, "Габрово"},
            { 281, "Кърджали"},
            { 301, "Кюстендил"},
            { 319, "Ловеч"},
            { 341, "Монтана"},
            { 377, "Пазарджик"},
            { 395, "Перник"},
            { 435, "Плевен"},
            { 501, "Пловдив"},
            { 527, "Разград"},
            { 555, "Русе"},
            { 575, "Силистра"},
            { 601, "Сливен"},
            { 623, "Смолян"},
            { 721, "София - град"},
            { 751, "София - окръг"},
            { 789, "Стара Загора"},
            { 821, "Добрич (Толбухин)"},
            { 843, "Търговище"},
            { 871, "Хасково"},
            { 903, "Шумен"},
            { 925, "Ямбол"},
            { 999, "Друг/Неизвестен"},
        };

        public EgnInformationExtractor(IEgnValidator egnValidator)
        {
            this.egnValidator = egnValidator;
        }
       
        public EgnInformation Extract(string egn)
        {
            egnValidator = new EgnValidator();

            if (!egnValidator.IsValid(egn))
            {
                throw new ArgumentException("Invalid EGN provided.", nameof(egn));
            }

            Sex sex = Sex.Unknown;

            if (int.Parse(egn[8].ToString()) % 2 == 0)
            {
                sex = Sex.Male;
            }
            else
            {
                sex = Sex.Female;
            }

            string placeOfBirth = string.Empty;
            int placeOfBirthCode = int.Parse(egn[6].ToString() + egn[7] + egn[8]);

            foreach (var city in cities)
            {
                if (placeOfBirthCode <= city.Key)
                {
                    placeOfBirth = city.Value;
                    break;
                }
            }

            int yearPart = int.Parse(egn.Substring(0, 2));
            int monthPart = int.Parse(egn.Substring(2, 2));
            int dayPart = int.Parse(egn.Substring(4, 2));

            int month = monthPart;
            int year = yearPart;

            if (monthPart >= 21 && monthPart <= 32)
            {
                month = monthPart - 20;
                year += 1800;
                // 1800 - 1899
            }
            else if (monthPart >= 41 && monthPart <= 52)
            {
                month = monthPart - 40;
                year += 2000;
                // 2000 - 2099
            }
            else if (monthPart >= 1 && monthPart <= 12)
            {
                year += 1900;
                // 1900 - 1999
            }

            var dateOfBirth = new DateTime(year, month, dayPart);

            return new EgnInformation(placeOfBirth, dateOfBirth, sex);
        }
    }
}