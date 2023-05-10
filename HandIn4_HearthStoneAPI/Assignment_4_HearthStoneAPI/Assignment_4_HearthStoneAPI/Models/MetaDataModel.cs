using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Assignment_4_HearthStoneAPI.Models
{
	public class MetaDataModel
	{
		[BsonId]
		public int Id { get; set; }

		[JsonPropertyName("Sets")]
		public List<Set> Set { get; set; }

		[JsonPropertyName("Rarities")]
		public List<Rarity> Rarity { get; set; }

		[JsonPropertyName("Classes")]
		public List<Class> Class { get; set; }

		[JsonPropertyName("Types")]
		public List<CardType> CardType { get; set; }



	}
}
