using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SW4BED_3.Models;
using SW4BED_3.Services;

namespace SW4BED_3.Pages
{
    [Authorize]
    [BindProperties]
    public class HotelModel : PageModel
    {
        private ResturantRepository _hotelRepository = new ResturantRepository();
        private readonly IServiceProvider _serviceProvider;

        public DateTime SelectedDate { get; set; } = DateTime.Today;
        public int RoomNumber { get; set; }
        public int AdultsReservations { get; set; }
        public int KidsReservations { get; set; }
        private List<Reservations> _checkedInRooms;
        public List<Reservations> CheckedInRooms
        {
            get => _checkedInRooms;
            set
            {
                _checkedInRooms = value;
                TotalAdults = value?.Sum(room => room.AdultsCheckIn) ?? 0;
                TotalKids = value?.Sum(room => room.KidsCheckIn ?? 0) ?? 0;
            }
        }

        public int TotalAdults { get; set; }
        public int TotalKids { get; set; }

        public HotelModel(IServiceProvider serviceProvider, ResturantRepository resturantRepository)
        {
            _serviceProvider = serviceProvider;
            _hotelRepository = resturantRepository;
        }

        public async Task OnGetAsync()
        {
            CheckedInRooms = await _hotelRepository.GetCheckedInRoomsAsync(_serviceProvider, SelectedDate);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _hotelRepository.AddOrUpdateBreakfastReservation(_serviceProvider, SelectedDate, RoomNumber, AdultsReservations, KidsReservations);
                ViewData["ServerResponse"] = "Reservation saved or updated successfully.";
            }
            catch (Exception e)
            {
                ViewData["ServerResponse"] = $"Error: {e.Message}";
            }

            try
            {
                CheckedInRooms = await _hotelRepository.GetCheckedInRoomsAsync(_serviceProvider, SelectedDate);
            }
            catch (Exception e)
            {
                ViewData["ServerResponse"] += $"\nError fetching checked-in rooms: {e.Message}";
            }

            return Page();
        }
    }
}
