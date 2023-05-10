namespace Assignment_4_HearthStoneAPI.Models
{
	public class MongodbHearthStoneSettings
	{
		public string ConnectionString { get; set; } = null!;
		public string DatabaseName { get; set; } = null!;
		public string CardCollectionName { get; set; } = null!;
		public string MetaDataCollectionName { get; set; } = null!;
		public string CardsSeedDataPath { get; set; } = null!;
		public string MetaDataSeedDataPath { get; set; } = null!; 
	}
}
