namespace A1_Invoice_System.Data
{
	internal class InvoiceInputModel
	{
		internal decimal MonthRate { get; set; }

		internal int NumberOfSendSms { get; set; }

		internal int NumberOfSendMms { get; set; }

		internal int ExtraMinutesToA1 { get; set; }

		internal int ExtraMinutesToTelenor { get; set; }

		internal int ExtraMinutesToVivacom { get; set; }

		internal int ExtraMinutesInRoaming { get; set; }

		internal int ExtraNationalMbutes { get; set; }

		internal int ExtraMbutesInEu { get; set; }

		internal int ExtraMbutesOutEu { get; set; }

		internal decimal OtherCharges { get; set; }

		internal decimal Discounts { get; set; }
	}
}
