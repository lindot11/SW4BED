﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelManagement.Data
{
	public class NewExpense
	{
		public long JobId { get; set; }
		public long ModelId { get; set; }

		[Column(TypeName = "date")]
		public DateTime Date { get; set; }
		public string? Text { get; set; }

		[Column(TypeName = "decimal(9,2)")]
		public decimal amount { get; set; }
	}
}
