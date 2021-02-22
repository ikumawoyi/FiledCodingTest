using System;
using Xunit;
using FiledCoding.Services;
using FiledCoding.Entities;
using FiledCoding.Enums;
using FiledCoding.Attributes;

namespace FiledCodingTests
{
	public class PaymentGateway
	{
		[Fact]
		public string Card_IsValid()
		{
			var payment = new PaymentRecord
			{
				CreditCardNumber = "8648736940"
			};
			string strRegex = @"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$";
			Assert.Matches(strRegex, "8648736940");
			return payment.CreditCardNumber;
		}


		[Fact]
		public string HolderName_IsValid()
		{
			var payment = new PaymentRecord
			{
				CardHolder = " "
			};
			string strRegex = @"^[A-TVWZ]?$";
			Assert.Matches(strRegex, "");
			return payment.CardHolder;
		}

	}
}
