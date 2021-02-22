using AutoMapper;
using FiledCoding.Data;
using FiledCoding.Entities;
using FiledCoding.Enums;
using FiledCoding.Interfaces;
using FiledCoding.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FiledCoding.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentController : ControllerBase
	{
		private readonly IPaymentGatewayService _paymentGatewayService;
		private readonly IPaymentRecordService _paymentRecordService;
		private readonly IMapper _mapper;

		public PaymentController(IPaymentGatewayService paymentGatewayService,
									IMapper mapper,
									IPaymentRecordService paymentRecordService)
		{
			_paymentGatewayService = paymentGatewayService;
			_paymentRecordService = paymentRecordService;
			_mapper = mapper;
		}
		[HttpPost]
		public IActionResult ProcessPayment(Payment payment)
		{
			try
			{
				var paymentRecord = _mapper.Map<PaymentRecord>(payment);
				if (!ModelState.IsValid)
				{
					return StatusCode((int)HttpStatusCode.BadRequest, string.Join(" | "," model is not valid."));
				}
				var newPayment = _paymentRecordService.AddPaymentRecord(paymentRecord);
				//Process payment
				//var paymentRecord = _paymentGatewayService.ProcessPayment(payment);
				var response = _paymentGatewayService.ProcessPayment(payment);
				newPayment.PaymentState = response ? PaymentState.Processed : PaymentState.Failed;
				var updatedpayment = _paymentRecordService.UpdatePaymentRecord(newPayment);
				return StatusCode((int)HttpStatusCode.OK, updatedpayment);
			}
			catch (Exception ex)
			{

				return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
			}
		}
	}
}
