using System.ComponentModel.DataAnnotations;

namespace ModelManagement.Data
{
	public class JobUpdateDto
	{
		public long JobId { get; set; }

		public DateTime StartDate { get; set; }

		public int Days { get; set; }

		[MaxLength(128)]
		public string? Location { get; set; }

		[MaxLength(2000)]
		public string? Comments { get; set; }
	}
}

