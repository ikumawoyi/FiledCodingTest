using AutoMapper;
using FiledCoding.Attributes;
using FiledCoding.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FiledCoding.Entities
{
	public class PaymentRecord
	{
		public int Id { get; set; }
		[Required]
		[CreditCardValidator]
		public string CreditCardNumber { get; set; }
		[Required]
		public string CardHolder { get; set; }
		[Required]
		[DatesValidator]
		public DateTime ExpirationDate { get; set; }
		public DateTime? CreatedOn { get; set; }
		public DateTime? UpdatedOn { get; set; }
		public PaymentState PaymentState { get; set; }
		[StringLength(3, ErrorMessage = "The ThumbnailPhotoFileName value cannot exceed 3 characters.")]
		public string SecurityCode { get; set; }
		[Required]
		[AmountValidator]
		[Column(TypeName = "decimal(18,4)")]
		public decimal Amount { get; set; }
	}
}
