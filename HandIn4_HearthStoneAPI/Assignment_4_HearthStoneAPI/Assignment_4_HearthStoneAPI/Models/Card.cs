using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;


namespace Assignment_4_HearthStoneAPI.Models
{
	public class Card
	{
		[BsonId]
		public int Id { get; set; }
		public String Name { get; set; }
		public int ClassId { get; set; }
		[JsonPropertyName("cardTypeId")]
		public int TypeId { get; set; }
		[JsonPropertyName("cardSetId")]
		public int SetId { get; set; }
		public int? SpellSchoolId { get; set; }
		public int RarityId { get; set; }
		public int? Health { get; set; }
		public int? Attack { get; set; }
		public int ManaCost { get; set; }
		[JsonPropertyName("artistName")]
		public String Artist { get; set; }
		public String Text { get; set; }
		public String FlavorText { get; set; }
	}
}
