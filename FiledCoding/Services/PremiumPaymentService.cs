using FiledCoding.Entities;
using FiledCoding.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledCoding.Services
{
	public class PremiumPaymentService : IPremiumPaymentService
	{
		public bool ProcessPayment(Payment payment)
		{
			return false;
		}
	}
}
