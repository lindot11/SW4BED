using Microsoft.EntityFrameworkCore;
using SW4BED_3.Data;
using SW4BED_3.Models;

namespace SW4BED_3.Services
{
	public class ResturantRepository
	{
		public void ReservationCheckIn(IServiceProvider serviceProvider, int roomNumber, int adults, int kids)
		{
			using (var context = new DataDB(serviceProvider.GetRequiredService<DbContextOptions<DataDB>>()))
			{
				if (context == null || context.Rooms == null)
				{
					throw new Exception("NoDataBase");
				}

				var entity = context.Reservations.FirstOrDefault(c => c.RoomNumber == roomNumber);


				if (entity == null)
				{
					throw new Exception("NullRoomNumber");
				}

				entity.AdultsCheckIn += adults;
				entity.KidsCheckIn += kids;

				if (entity.AdultsCheckIn > entity.AdultsReservations || entity.KidsCheckIn > entity.KidsReservations)
				{
					var message = "BAD : ";
					message += "RoomNumber " + roomNumber + ", have ";
					message +=  entity.AdultsReservations + "  adult Reservations and " + (entity.AdultsCheckIn - adults)  + " adultcheckins";
					message += "     " + entity.KidsReservations + "  kids Reservations and " + (entity.KidsCheckIn - kids) + " kidcheckins";
					throw new Exception(message);
				}

				

				context.Reservations.Update(entity);
				context.SaveChanges();

			}
		}
	}
}
