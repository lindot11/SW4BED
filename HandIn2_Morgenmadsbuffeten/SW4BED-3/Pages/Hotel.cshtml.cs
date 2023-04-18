using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SW4BED_3.Pages
{
	
	[Authorize("CanEnterHotelPage")]
	[BindProperties]
	public class HotelModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        [DataType(DataType.Date)]
		public  DateTime  DateTime{ get; set; }
       
		public void OnPost()
        {
	        @ViewData["Date"] = $"{DateTime}";
        }

    }
}
