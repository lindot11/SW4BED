using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SW4BED_3.Data;
using SW4BED_3.Services;

namespace SW4BED_3.Pages
{
    [Authorize("CanEnterRestaurantPage")]
    [BindProperties]
    public class RestaurantModel : PageModel
    {
        private ResturantRepository resturantRepository = new ResturantRepository();
        private readonly IServiceProvider  _serviceProvider;

        public int RoomNumber { get; set; }
        public int NrAdults { get; set; }
        public int NrChildren { get; set; }


        public RestaurantModel(IServiceProvider serviceProvider)
        {
	        _serviceProvider = serviceProvider;
        }



        public async Task<IActionResult> OnPost()
        {
	        try
	        {
		        await this.resturantRepository.ReservationCheckIn(_serviceProvider, RoomNumber, NrAdults, NrChildren);
		        
		        @ViewData["ServerResponse"] = $"Success";

		        
			}
			catch (Exception e)
	        {
		        @ViewData["ServerResponse"] = $"{e.Message.ToString()}";
	        }

	        return Page();

		}
    }
}
 