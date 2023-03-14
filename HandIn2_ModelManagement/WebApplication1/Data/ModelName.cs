using System.ComponentModel.DataAnnotations;

namespace ModelManagement.Data
{
	public class ModelName
	{
		public long ModelId { get; }

		[MaxLength(64)]
		public string? FirstName { get; set; }

		[MaxLength(32)]
		public string? LastName { get; set; }

	}
}
