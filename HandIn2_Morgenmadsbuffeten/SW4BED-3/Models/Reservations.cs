using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SW4BED_3.Models
{
    public class Reservations 
    {
	    //Table Elements
		public int ReservationId { get; set; }

        [ForeignKey("Rooms")]
        public int RoomNumber { get; set; }

        public int AdultsReservations { get; set; }

        public int KidsReservations { get; set; }

        public int AdultsCheckIn { get; set; }

        public int? KidsCheckIn { get; set; }

        public DateTime Date { get; set; }

        //Relations
        public Rooms Rooms { get; set; }

	}
}
