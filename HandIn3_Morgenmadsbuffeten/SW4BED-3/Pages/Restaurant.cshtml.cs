using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using SW4BED_3.Data;
using SW4BED_3.Hubs;
using SW4BED_3.Services;

namespace SW4BED_3.Pages
{
    [Authorize("CanEnterRestaurantPage")]
    [BindProperties]
    public class RestaurantModel : PageModel
    {
        private ResturantRepository resturantRepository = new ResturantRepository();
        private readonly IServiceProvider  _serviceProvider;
        private readonly IHubContext<ChatHub> _chatHubContext;

        public int RoomNumber { get; set; }
        public int NrAdults { get; set; }
        public int NrChildren { get; set; }


        public RestaurantModel(IServiceProvider serviceProvider, IHubContext<ChatHub> chatHubContext)
        {
            _serviceProvider = serviceProvider;
            _chatHubContext = chatHubContext;
        }



        public async Task<IActionResult> OnPost()
        {
	        try
	        {
		        await this.resturantRepository.ReservationCheckIn(_serviceProvider, RoomNumber, NrAdults, NrChildren);
		        
                await _chatHubContext.Clients.All.SendAsync("Update");


            }
            catch (Exception e)
	        {
		        @ViewData["ServerResponse"] = $"{e.Message.ToString()}";
	        }

	        return Page();
		}
    }
}
 