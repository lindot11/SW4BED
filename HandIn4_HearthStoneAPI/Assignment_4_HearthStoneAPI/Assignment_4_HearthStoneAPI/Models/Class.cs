using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Assignment_4_HearthStoneAPI.Models
{
	public class Class
	{
		[BsonId]
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
	}
}
