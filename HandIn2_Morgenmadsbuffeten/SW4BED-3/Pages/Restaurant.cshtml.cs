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
	    private ResturantRepository Rr = new ResturantRepository();

        public int RoomNumber { get; set; }
        public int NrAdults { get; set; }
        public int NrChildren { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult>  OnUpdateAsync()
        {

	     
        }
    }
}
