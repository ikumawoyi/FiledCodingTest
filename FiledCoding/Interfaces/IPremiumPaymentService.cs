using FiledCoding.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledCoding.Interfaces
{
	public interface IPremiumPaymentService
	{
		bool ProcessPayment(Payment payment);
	}
}
