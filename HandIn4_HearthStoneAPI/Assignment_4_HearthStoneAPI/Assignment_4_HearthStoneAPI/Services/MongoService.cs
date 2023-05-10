using Assignment_4_HearthStoneAPI.Models;
using MongoDB.Driver;

using System.Text.Json;
using Microsoft.Extensions.Options;


namespace Assignment_4_HearthStoneAPI.Services
{
	public class MongoService
	{

		private readonly MongoClient _client;
		private readonly IMongoDatabase _db;
		private IMongoCollection<Card> _cardCollection;
		private IMongoCollection<MetaDataModel> _metaDataCollection;

		public MongoService(IOptions<MongodbHearthStoneSettings> settingsOptions)
		{
			_client = new MongoClient(settingsOptions.Value.ConnectionString);
			_db = _client.GetDatabase(settingsOptions.Value.DatabaseName);
			_cardCollection=  _db.GetCollection<Card>(settingsOptions.Value.CardCollectionName);
			_metaDataCollection = _db.GetCollection<MetaDataModel>(settingsOptions.Value.MetaDataCollectionName);

			if (_client.GetDatabase(settingsOptions.Value.DatabaseName).ListCollections().ToList().Count == 0)
			{
				var cardCollection = _db.GetCollection<Card>(settingsOptions.Value.CardCollectionName);
				
				
				using (var file = new StreamReader(settingsOptions.Value.CardsSeedDataPath))
				{
					var cards = JsonSerializer.Deserialize<List<Card>>(file.ReadToEnd(), new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true
					});
					cardCollection.InsertMany(cards);
				}

				

				var setsCollection = _db.GetCollection<MetaDataModel>(settingsOptions.Value.MetaDataCollectionName);

				using (var file = new StreamReader(settingsOptions.Value.MetaDataSeedDataPath))
				{

					var m = JsonSerializer.Deserialize<MetaDataModel>(file.ReadToEnd());
					setsCollection.InsertOne(m);
				}

					
					

				


			}
		}

		public MongoClient Client
		{
			get
			{
				return _client;
			}
		}

		public IMongoCollection<Card> CardCollection
		{
			get
			{
				return _cardCollection ;
			}
		}

		public IMongoCollection<MetaDataModel> MetaDataCollection
		{
			get
			{
				return _metaDataCollection;
			}
		}
	}
}
