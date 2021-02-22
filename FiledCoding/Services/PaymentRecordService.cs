using AutoMapper;
using FiledCoding.Entities;
using FiledCoding.Enums;
using FiledCoding.Interfaces;
using FiledCoding.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledCoding.Services
{
	public class PaymentRecordService : IPaymentRecordService
	{
		private readonly IPaymentRecordRepository _paymentRecordRepository;

		public PaymentRecordService(IPaymentRecordRepository paymentRecordRepository)
		{
			_paymentRecordRepository = paymentRecordRepository;
		}
		public PaymentRecord AddPaymentRecord(PaymentRecord paymentRecord)
		{
			paymentRecord.CreatedOn = DateTime.Now;
			paymentRecord.PaymentState = PaymentState.Pending;
			_paymentRecordRepository.InsertPaymentRecord(paymentRecord);
			_paymentRecordRepository.SavePaymentRecord();
			return paymentRecord;
		}

		public PaymentRecord UpdatePaymentRecord(PaymentRecord paymentRecord)
		{
			paymentRecord.UpdatedOn = DateTime.Now;
			_paymentRecordRepository.UpdatePaymentRecord(paymentRecord);
			_paymentRecordRepository.SavePaymentRecord();
			return paymentRecord;

		}
	}
}
