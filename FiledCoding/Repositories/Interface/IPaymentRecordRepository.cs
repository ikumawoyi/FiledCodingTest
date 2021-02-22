using FiledCoding.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledCoding.Repositories.Interface
{
	public interface IPaymentRecordRepository
	{
        IEnumerable<PaymentRecord> GetRecords();
        PaymentRecord GetRecordByID(int id);
        PaymentRecord InsertPaymentRecord(PaymentRecord paymentRecord);
        PaymentRecord UpdatePaymentRecord(PaymentRecord paymentRecord);
        void SavePaymentRecord();
    }
}
