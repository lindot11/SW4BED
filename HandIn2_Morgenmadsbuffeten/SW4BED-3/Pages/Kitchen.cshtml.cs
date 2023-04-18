using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SW4BED_3.Pages
{
    [Authorize]
    public class KitchenModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
