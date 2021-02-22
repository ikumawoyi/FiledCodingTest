using FiledCoding.Entities;
using FiledCoding.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledCoding.Services
{
	public class CheapPaymentGatewayService : ICheapPaymentGateway
	{
		public bool ProcessPayment(Payment payment)
		{
			return false;
		}
	}
}
