using FiledCoding.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledCoding.Data
{
	public class PaymentContext : DbContext
	{
		public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
		{
		}

		public DbSet<PaymentRecord> PaymentRecords { get; set; }
	}
}
