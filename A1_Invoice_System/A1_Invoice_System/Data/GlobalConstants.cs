namespace A1_Invoice_System.Data
{
	internal static class GlobalConstants
	{
		internal static decimal SmsRateTo50Sms = 0.18m;

		internal static decimal SmsRateTo50_100Sms = 0.16m;

		internal static decimal SmsRateToOver100Sms = 0.11m;

		internal static decimal MmsRateTo50Sms = 0.25m;

		internal static decimal MmsRateTo50_100Sms = 0.23m;

		internal static decimal MmsRateToOver100Sms = 0.18m;

		internal static decimal ExrtaMinuteRateToA1 = 0.03m;

		internal static decimal ExrtaMinuteRateToOther = 0.09m;

		internal static decimal ExrtaMinuteRateInRoaming = 0.15m;

		internal static decimal ExrtaMButesRateInCountry = 0.02m;

		internal static decimal ExrtaMButesRateInEu = 0.05m;

		internal static decimal ExrtaMButesRateOutEu = 0.05m;

		internal static string InvalidValue = "Невалидна стойност! ";

		internal static string MonthRate = "Месечна такса: ";

		internal static string SendSms = "Брой изпратени SMS-и: ";

		internal static string SendMms = "Брой изпратени MMS-и: ";

		internal static string ExtraMinutesToA1 = "Минути към А1 извън включените в пакета: ";

		internal static string ExtraMinutesToTelenor = "Минути към Теленор извън включените в пакета: ";

		internal static string ExtraMinutesToVivacom = "Минути към Виваком извън включените в пакета: ";

		internal static string MinutesInRoaming = "Минути в роуминг: ";

		internal static string ExtraNationalMbutes = "Използвани МБ в страната извън включените в пакета: ";

		internal static string ExtraMbutesInEu = "Използвани МБ в ЕС извън включените в пакета: ";

		internal static string ExtraMbutesOutEu = "Използвани МБ ИЗВЪН ЕС извън включените в пакета: ";

		internal static string OtherCharges = "Други такси: ";

		internal static string Discounts = "Отстъпки: ";
	}
}
