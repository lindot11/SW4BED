using Assignment_4_HearthStoneAPI.Models;
using Assignment_4_HearthStoneAPI.Models.DTO;
using Assignment_4_HearthStoneAPI.Models.ParamModels;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.Linq;
using Amazon.Runtime.Internal.Transform;
using AutoMapper;

namespace Assignment_4_HearthStoneAPI.Services
{
    public class HearthStoneService
	{

		private readonly IMongoCollection<Card> _cards;
		private readonly IMongoCollection<MetaDataModel> _metaDatCollection;
		private IDictionary<int, string> _mapSets;
		private IDictionary<int, string> _mapRarity;
		private IDictionary<int, string> _mapClass;
		private IDictionary<int, string> _mapcardType;


		public HearthStoneService(MongoService mongoClient)
		{
			_cards = mongoClient.CardCollection;
			_metaDatCollection = mongoClient.MetaDataCollection;

			_mapSets = new Dictionary<int, string>();
			_mapRarity = new Dictionary<int, string>();
			_mapClass = new Dictionary<int, string>();
			_mapcardType = new Dictionary<int, string>();

			CreateMaps();
		}

		

		public async Task<List<CardDTO>> GetCards(CardParams args)
		{
			var filter = Builders<Card>.Filter.Empty;
			int limit = 0;
			int skip = 0;
			
			if (args.Artist != null)
			{
				var artistFilter = Builders<Card>.Filter.Eq(x=>x.Artist, args.Artist);
				filter &= artistFilter;
			}
			if (args.ClassId is not null)
			{
				var classIdFilter = Builders<Card>.Filter.Eq(x=>x.ClassId, args.ClassId);
				filter &= classIdFilter;
			}

			if (args.SetId is not null)
			{
				var setIdFilter = Builders<Card>.Filter.Eq(x=>x.SetId, args.SetId);
				filter &= setIdFilter;
			}
			if (args.RarityId is not null)
			{
				var rarityIdFilter = Builders<Card>.Filter.Eq(x => x.RarityId, args.RarityId);
				filter &= rarityIdFilter;
			}
			if (args.Page != null & args.Page > 0)
			{
				limit = 100;
				skip = (int)(args.Page - 1)*100;
			}

			var res = await _cards.Find(filter).Skip(skip).Limit(limit).ToListAsync();

			
			return CardMapper(res);
		}


		public async Task<List<Set>> GetSets()
		{
			var filter = Builders<MetaDataModel>.Filter.Empty;
			var res = await _metaDatCollection.Find(filter).FirstOrDefaultAsync();

			return res.Set;
		}

		public async Task<List<Class>> GetClasses()
		{
			var filter = Builders<MetaDataModel>.Filter.Empty;
			var res = await _metaDatCollection.Find(filter).FirstOrDefaultAsync();

			return res.Class;
		}

		public async Task<List<Rarity>> GetRarities()
		{
			var filter = Builders<MetaDataModel>.Filter.Empty;
			var res = await _metaDatCollection.Find(filter).FirstOrDefaultAsync();

			return res.Rarity;
		}

		public async Task<List<CardType>> GetCardTypes()
		{
			var filter = Builders<MetaDataModel>.Filter.Empty;
			var res = await _metaDatCollection.Find(filter).FirstOrDefaultAsync();

			return res.CardType;
		}

		public List<CardDTO> CardMapper(List<Card> cards)
		{
			var list = new List<CardDTO>();

			foreach (var c in cards)
			{
				
				list.Add(new CardDTO()
				{
					Id = c.Id,
					Name = c.Name,
					Class = _mapClass.ContainsKey(c.ClassId) ?_mapClass[c.ClassId] : "unknown",
					Type =  _mapcardType.ContainsKey(c.TypeId) ? _mapcardType[c.TypeId] : "unknown",
					Set = _mapSets.ContainsKey(c.SetId) ? _mapSets[c.SetId] : "unknown",
					SpellSchoolId = c.SpellSchoolId,
					Rarity = _mapRarity.ContainsKey(c.RarityId) ? _mapRarity[c.RarityId] : "unknown",
					Health = c.Health,
					Attack = c.Attack,
					ManaCost = c.ManaCost,
					Artist = c.Artist,
					Text = c.Text,
					FlavorText = c.FlavorText,
				});
			}

			return list;

		}

		private async void CreateMaps()
		{
			var filter = Builders<MetaDataModel>.Filter.Empty;
			var res = await _metaDatCollection.Find(filter).FirstOrDefaultAsync();

			foreach (var s in res.Set)
			{
				_mapSets.Add(s.Id,s.Name);
			}

			foreach (var t in res.CardType)
			{
				_mapcardType.Add(t.Id, t.Name);
			}

			foreach (var c in res.Class)
			{
				_mapClass.Add(c.Id, c.Name);
			}

			foreach (var r in res.Rarity)
			{
				_mapRarity.Add(r.Id, r.Name);
			}


		}


	}

   
}
