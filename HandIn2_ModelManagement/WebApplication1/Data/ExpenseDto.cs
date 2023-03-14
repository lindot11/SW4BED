using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelManagement.Data
{
	public class ExpenseDto
	{
		public long ExpenseId { get; set; }

		[Column(TypeName = "decimal(9,2)")]
		public decimal amount { get; set; }
	}
}
