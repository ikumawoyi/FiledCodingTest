using FiledCoding.Data;
using FiledCoding.Entities;
using FiledCoding.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledCoding.Repositories.Repository
{
	public class PaymentRecordRepository : IPaymentRecordRepository
	{
		private readonly PaymentContext context;

		public PaymentRecordRepository(PaymentContext context)
		{
			this.context = context;
		}
        public IEnumerable<PaymentRecord> GetRecords()
        {
            return context.PaymentRecords.ToList();
        }

        public PaymentRecord GetRecordByID(int id)
        {
            return context.PaymentRecords.Find(id);
        }
        
        public PaymentRecord UpdatePaymentRecord(PaymentRecord paymentRecord)
        {
            context.Entry(paymentRecord).State = EntityState.Modified;
            return paymentRecord;
        }

        public void SavePaymentRecord()
        {
            context.SaveChanges();
        }

		public PaymentRecord InsertPaymentRecord(PaymentRecord paymentRecord)
		{
            context.PaymentRecords.Add(paymentRecord);
            return paymentRecord;
        }
	}
}
