using AutoMapper;
using FiledCoding.Entities;
using FiledCoding.Enums;
using FiledCoding.Interfaces;
using FiledCoding.Repositories.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledCoding.Services
{
	public class PaymentGatewayService : IPaymentGatewayService
	{
		private readonly ILogger<PaymentGatewayService> _logger;
		//private readonly CheapPaymentGatewayService _cheapPaymentGatewayService;
		//private readonly ExpensivePaymentGatewayService _expensivePaymentGatewayService;
		//private readonly PremiumPaymentService _premiumPaymentService;

		public PaymentGatewayService(
			ILogger<PaymentGatewayService> logger
									//CheapPaymentGatewayService cheapPaymentGatewayService,
									//ExpensivePaymentGatewayService expensivePaymentGatewayService,
									//PremiumPaymentService premiumPaymentService
									)
		{
			_logger = logger;
			//_cheapPaymentGatewayService = cheapPaymentGatewayService;
			//_expensivePaymentGatewayService = expensivePaymentGatewayService;
			//_premiumPaymentService = premiumPaymentService;

		}

		private bool IsExpensivePaymentGatewayAvailable()
		{
			return false;
		}




		

		public bool ProcessPayment(Payment payment)
		{
			var status = false;
			//var payment = _mapper.Map<Payment>(paymentRecord);
			//_cheapPaymentGateway.AddPaymentRecord(paymentRecord);
			if (payment.Amount >= 0 && payment.Amount <= 20)
			{
				//status = _cheapPaymentGatewayService.ProcessPayment(payment);
				_logger.LogInformation("Used ICheapPaymentGateway");
			}
			else if(payment.Amount >= 21 && payment.Amount <= 500)
			{
				if (IsExpensivePaymentGatewayAvailable())
				{
					status = false;
					//status = _expensivePaymentGatewayService.ProcessPayment(payment);
					_logger.LogInformation("Used IExpensivePaymentGateway");
				}
				else
				{
					status = false;
					//status = _cheapPaymentGatewayService.ProcessPayment(payment);
					_logger.LogInformation("Used ICheapPaymentGateway");
				}
				
			}
			
			else if(payment.Amount > 500)
			{
				status = false;
				//status = _premiumPaymentService.ProcessPayment(payment);
				if (!status)
				{
					var number = 0;
					while (!status && number < 3)
					{
						status = false;
						//status = _premiumPaymentService.ProcessPayment(payment);
						_logger.LogInformation("Used PremiumPaymentService");
						number++;
					}
				}
				_logger.LogInformation("Used PremiumPaymentService");
				
			}
			// Check if the record exist in Db, if yes,
			// Call update method

			//paymentRecord.PaymentState = status ? PaymentState.Processed : PaymentState.Failed;
			return  status;
		}
	}
}
