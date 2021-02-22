using FiledCoding.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledCoding.Interfaces
{
	public  interface IPaymentRecordService
	{
		PaymentRecord AddPaymentRecord(PaymentRecord paymentRecord);
		PaymentRecord UpdatePaymentRecord(PaymentRecord paymentRecord);
	}
}
