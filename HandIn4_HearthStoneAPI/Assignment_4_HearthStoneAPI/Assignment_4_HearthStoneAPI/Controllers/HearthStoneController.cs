using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment_4_HearthStoneAPI.Services;
using Assignment_4_HearthStoneAPI.Models;
using Assignment_4_HearthStoneAPI.Models.DTO;
using Assignment_4_HearthStoneAPI.Models.ParamModels;

namespace Assignment_4_HearthStoneAPI.Controllers
{
	[ApiController]
	public class HearthStoneController : ControllerBase
	{

		private readonly HearthStoneService _services;
		private readonly ILogger _logger;

		public HearthStoneController(HearthStoneService services, ILogger<HearthStoneController> logger)
		{
			_logger = logger;
			_services = services;
		}
		
		// GET: cards
	
		[HttpGet]
		[Route("cards/{page:int?}/{setid:int?}/{artist?}/{classid:int?}/{rarityid:int?}")]
		public Task<List<CardDTO>> Get([FromQuery] int ? page, [FromQuery] int? setid, [FromQuery] string? artist, [FromQuery] int? classid, [FromQuery] int? rarityid)
		{
			_logger.LogInformation("Get on: cards {id}" , artist);
			var parms = new CardParams();
			
			parms.Page = page;
			parms.SetId = setid;
			parms.Artist = artist;
			parms.ClassId = classid;
			parms.RarityId = rarityid;
			

			
			return _services.GetCards(parms);
		}


		
		// GET: Set
		[Route("sets/")]
		[HttpGet]
		public Task<List<Set>> GetSets()
		{
			_logger.LogInformation("Get on: sets");
			return _services.GetSets();
		}

		// GET: CardTypes
		[Route("types/")]
		[HttpGet]
		public Task<List<CardType>> GetCardType()
		{
			_logger.LogInformation("Get on: types");
			return _services.GetCardTypes();
		}

		// GET: Classes
		[Route("classes/")]
		[HttpGet]
		public Task<List<Class>> GetClass()
		{
			_logger.LogInformation("Get on: classes");
			return _services.GetClasses();
		}

		// GET: Rarities
		[Route("rarities/")]
		[HttpGet]
		public Task<List<Rarity>> GetRarity()
		{
			_logger.LogInformation("Get on: rarities");
			return _services.GetRarities();
		}


	}
}
