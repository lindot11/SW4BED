using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Assignment_4_HearthStoneAPI.Models.DTO
{
	public class CardDTO
	{
		[BsonId]
		public int Id { get; set; }
		public String Name { get; set; }
		public String Class { get; set; }
		[JsonPropertyName("cardTypeId")]
		public String Type { get; set; }
		public String Set { get; set; }
		public int? SpellSchoolId { get; set; }
		public String Rarity { get; set; }
		public int? Health { get; set; }
		public int? Attack { get; set; }
		public int ManaCost { get; set; }
		[JsonPropertyName("artistName")]
		public String Artist { get; set; }
		public String Text { get; set; }
		public String FlavorText { get; set; }
	}
}
