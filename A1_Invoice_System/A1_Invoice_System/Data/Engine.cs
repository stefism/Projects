using A1_Invoice_System.Contracts;
using System;

namespace A1_Invoice_System.Data
{
	internal class Engine : IEngine
	{
		public void Run()
		{
			InvoiceInputModel invoiceInputModel = new InvoiceInputModel();

			while(true)
			{
				Console.Write(GlobalConstants.MonthRate);
				invoiceInputModel.MonthRate = ValidateDecimalInput(GlobalConstants.MonthRate);

				Console.Write(GlobalConstants.SendSms);
				invoiceInputModel.NumberOfSendSms = ValidateIntInput(GlobalConstants.SendSms);

				Console.Write(GlobalConstants.SendMms);
				invoiceInputModel.NumberOfSendMms = ValidateIntInput(GlobalConstants.SendMms);

				Console.Write(GlobalConstants.ExtraMinutesToA1);
				invoiceInputModel.ExtraMinutesToA1 = ValidateIntInput(GlobalConstants.ExtraMinutesToA1);

				Console.Write(GlobalConstants.ExtraMinutesToTelenor);
				invoiceInputModel.ExtraMinutesToTelenor = ValidateIntInput(GlobalConstants.ExtraMinutesToTelenor);

				Console.Write(GlobalConstants.ExtraMinutesToVivacom);
				invoiceInputModel.ExtraMinutesToVivacom = ValidateIntInput(GlobalConstants.ExtraMinutesToVivacom);

				Console.Write(GlobalConstants.MinutesInRoaming);
				invoiceInputModel.ExtraMinutesInRoaming = ValidateIntInput(GlobalConstants.MinutesInRoaming);

				Console.Write(GlobalConstants.ExtraNationalMbutes);
				invoiceInputModel.ExtraNationalMbutes = ValidateIntInput(GlobalConstants.ExtraNationalMbutes);

				Console.Write(GlobalConstants.ExtraMbutesInEu);
				invoiceInputModel.ExtraMbutesInEu = ValidateIntInput(GlobalConstants.ExtraMbutesInEu);

				Console.Write(GlobalConstants.ExtraMbutesOutEu);
				invoiceInputModel.ExtraMbutesOutEu = ValidateIntInput(GlobalConstants.ExtraMbutesOutEu);

				Console.Write(GlobalConstants.OtherCharges);
				invoiceInputModel.OtherCharges = ValidateDecimalInput(GlobalConstants.OtherCharges);

				Console.Write(GlobalConstants.Discounts);
				invoiceInputModel.Discounts = ValidateDecimalInput(GlobalConstants.Discounts);

				decimal finalSum = CalculateFinalSum(invoiceInputModel);

				Console.WriteLine();
				Console.WriteLine(new string('-', 40));
				Console.WriteLine($"Общата сума по фактурата е {finalSum:F2} лв.");
				Console.WriteLine(new string('-', 40));
				Console.WriteLine();

				Console.Write("Желаете ли да продължите? (Y/N): ");

				string yesOrNo = Console.ReadLine();

				Console.WriteLine(yesOrNo);

				if(yesOrNo == "N" || yesOrNo == "n")
				{
					break;
				}
			}
		}

		private decimal CalculateFinalSum(InvoiceInputModel invoiceInputModel)
		{
			decimal monthRate = invoiceInputModel.MonthRate;

			decimal smsAmount = CalculateSmsAmount(invoiceInputModel.NumberOfSendSms);
			decimal mmsAmount = CalculateMmsAmount(invoiceInputModel.NumberOfSendMms);
			decimal extraMinutesToA1 = invoiceInputModel.ExtraMinutesToA1 * GlobalConstants.ExrtaMinuteRateToA1;
			decimal extraMinutesToVivacom = invoiceInputModel.ExtraMinutesToVivacom * GlobalConstants.ExrtaMinuteRateToOther;
			decimal extraMinutesToTelenor = invoiceInputModel.ExtraMinutesToTelenor * GlobalConstants.ExrtaMinuteRateToOther;
			decimal extraMinutesInRoaming = invoiceInputModel.ExtraMinutesInRoaming * GlobalConstants.ExrtaMinuteRateInRoaming;
			decimal extraNationalMbutes = invoiceInputModel.ExtraNationalMbutes * GlobalConstants.ExrtaMButesRateInCountry;
			decimal extraMbutesInEu = invoiceInputModel.ExtraMbutesInEu * GlobalConstants.ExrtaMButesRateInEu;
			decimal extraMbutesOutEu = invoiceInputModel.ExtraMbutesOutEu * GlobalConstants.ExrtaMButesRateOutEu;
			decimal otherCharges = invoiceInputModel.OtherCharges;

			decimal discounts = invoiceInputModel.Discounts;

			decimal finalSum = (monthRate + smsAmount + mmsAmount + extraMinutesToA1 + extraMinutesToVivacom + extraMinutesToTelenor + extraMinutesInRoaming + extraNationalMbutes + extraMbutesInEu + extraMbutesOutEu + otherCharges) - discounts;

			return finalSum;
		}

		private decimal CalculateMmsAmount(int mms) => mms switch
		{
			var _ when mms < 50 => mms * GlobalConstants.MmsRateTo50Sms,
			var _ when mms >= 50 && mms <= 100 => mms * GlobalConstants.MmsRateTo50_100Sms,
			var _ when mms > 100 => mms * GlobalConstants.MmsRateToOver100Sms,
		};

		private decimal CalculateSmsAmount(int sms) => sms switch
		{
			var _ when sms < 50 => sms * GlobalConstants.SmsRateTo50Sms,
			var _ when sms >= 50 && sms <= 100 => sms * GlobalConstants.SmsRateTo50_100Sms,
			var _ when sms > 100 => sms * GlobalConstants.SmsRateToOver100Sms,
		};

		private decimal ValidateDecimalInput(string errMessage)
		{
			bool isResultValid = decimal.TryParse(Console.ReadLine(), out decimal input);
			while(!isResultValid)
			{
				Console.Write(GlobalConstants.InvalidValue + errMessage);
				isResultValid = decimal.TryParse(Console.ReadLine(), out input);
			}

			return input;
		}

		private int ValidateIntInput(string errMessage)
		{
			bool isResultValid = int.TryParse(Console.ReadLine(), out int input);
			while(!isResultValid)
			{
				Console.Write(GlobalConstants.InvalidValue + errMessage);
				isResultValid = int.TryParse(Console.ReadLine(), out input);
			}

			return input;
		}
	}
}
