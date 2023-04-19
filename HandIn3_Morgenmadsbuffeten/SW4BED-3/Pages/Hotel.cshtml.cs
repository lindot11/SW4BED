using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SW4BED_3.Data;
using SW4BED_3.Models;

namespace SW4BED_3.Pages
{

    [Authorize("CanEnterHotelPage")]
    [BindProperties]
    public class HotelModel : PageModel
    {
        private readonly DataDB _context;

        public HotelModel(DataDB context)
        {
            _context = context;
            Console.WriteLine("HotelModel");
        }

        public DateTime SelectedDate { get; set; } = DateTime.Today;
        public List<Reservations> RoomReservations { get; set; }
        public int TotalAdultReservations { get; set; }
        public int TotalKidsReservations { get; set; }
        public int TotalAdultsCheckIn { get; set; }
        public int TotalKidsCheckIn { get; set; }

		
		public void OnGet()
        {
            LoadRoomReservations();
        }

		
		public void OnPost()
        {
            LoadRoomReservations();
        }

        private void LoadRoomReservations()
        {
            RoomReservations = _context.Rooms
                .Include(r => r.Reservations)
                .Select(r => new Reservations()
                {
                    RoomNumber = r.RoomNumber,
                    AdultsReservations = r.Reservations
                        .Where(res => res.Date == SelectedDate)
                        .Sum(res => res.AdultsReservations),
                    KidsReservations = r.Reservations
                        .Where(res => res.Date == SelectedDate)
                        .Sum(res => res.KidsReservations),
                    AdultsCheckIn = r.Reservations
                        .Where(res => res.Date == SelectedDate)
                        .Sum(res => res.AdultsCheckIn),
                    KidsCheckIn = r.Reservations
                        .Where(res => res.Date == SelectedDate)
                        .Sum(res => res.KidsCheckIn ?? 0)

                })
                .ToList();
            TotalAdultReservations = RoomReservations.Sum(r => r.AdultsReservations);
            TotalKidsReservations = RoomReservations.Sum(r => r.KidsReservations);
            TotalAdultsCheckIn = RoomReservations.Sum(r => r.AdultsCheckIn);
            TotalKidsCheckIn = RoomReservations.Sum(r => r.KidsCheckIn ?? 0);
        }

        public async Task<IActionResult> OnPostUpdateReservation(int roomNumber, int adultsReservations, int kidsReservations, int adultsCheckIn, int? kidsCheckIn)
        {
	        var reservation = await _context.Reservations
		        .FirstOrDefaultAsync(r => r.RoomNumber == roomNumber);
            if (reservation == null)
            {
	            return NotFound();

            }
            reservation.AdultsReservations = adultsReservations;
            reservation.KidsReservations = kidsReservations;
            reservation.AdultsCheckIn = adultsCheckIn;
            reservation.KidsCheckIn = kidsCheckIn;

            await _context.SaveChangesAsync();

            return RedirectToPage("Hotel");
        }

        public class RoomReservationViewModel
        {
            public int RoomNumber { get; set; }
            public int AdultsReservations { get; set; }
            public int KidsReservations { get; set; }
            public int AdultsCheckIn { get; set; }
            public int? KidsCheckIn { get; set; }
        }





    }
}

