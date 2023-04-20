using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SW4BED_3.Data;
using SW4BED_3.Models;

namespace SW4BED_3.Pages
{
    public class KitchenModel : PageModel
    {
        private readonly DataDB _context;
        public DateTime Date { get; set; } = DateTime.Today;

        public KitchenModel(DataDB context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(DateTime? date)
        {
            // Use the given date, or default to today
            date ??= Date;

            // Retrieve the data for the given date
            var reservations = await _context.Reservations
                .Where(r => r.Date == date)
                .ToListAsync();

            // Calculate the expected and actual number of guests
            var expectedTotal = reservations.Sum(r => r.AdultsReservations + r.KidsReservations);
            var expectedAdults = reservations.Sum(r => r.AdultsReservations);
            var expectedKids = reservations.Sum(r => r.KidsReservations);
            var actualAdults = reservations.Sum(r => r.AdultsCheckIn);
            var actualKids = reservations.Sum(r => r.KidsCheckIn);
            var remainingAdults = expectedAdults - actualAdults;
            var remainingKids = expectedKids - actualKids;

            // Pass the data to the view
            ViewData["Date"] = date.Value.ToShortDateString();
            ViewData["ExpectedTotal"] = expectedTotal;
            ViewData["ExpectedAdults"] = expectedAdults;
            ViewData["ExpectedKids"] = expectedKids;
            ViewData["ActualAdults"] = actualAdults;
            ViewData["ActualKids"] = actualKids;
            ViewData["RemainingAdults"] = remainingAdults;
            ViewData["RemainingKids"] = remainingKids;

            return Page();
        }
    }
}
