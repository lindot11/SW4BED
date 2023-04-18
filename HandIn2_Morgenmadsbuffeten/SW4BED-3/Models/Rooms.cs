


using System.ComponentModel.DataAnnotations.Schema;

namespace SW4BED_3.Models
{
    public class Rooms
    {
		//Table Elements
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int RoomNumber { get; set; }
		
		public int Adults { get; set; }

        public int Kids { get; set; }


        //Relations
		public ICollection<Reservations> Reservations { get;}
    }
}