using Microsoft.EntityFrameworkCore;
using SW4BED_3.Data;
using SW4BED_3.Models;

namespace SW4BED_3.Services
{
	public class ResturantRepository
	{
		public static void ReservationCheckIn(IServiceProvider serviceProvider, int roomNumber, int adults, int kids)
		{
			using (var context = new DataDB(serviceProvider.GetRequiredService<DbContextOptions<DataDB>>()))
			{
				if (context == null || context.Rooms == null)
				{
					throw new ArgumentNullException("Null DataDb");
				}

				var entity = context.Reservations.FirstOrDefault(c => c.RoomNumber == roomNumber);


				if (entity == null)
				{
					throw new ArgumentNullException("Null RoomNumber");
				}

				entity.AdultsCheckIn += adults;
				entity.KidsCheckIn += kids;

				if (entity.AdultsCheckIn > entity.AdultsReservations
				    && entity.KidsCheckIn > entity.KidsReservations)
				{
					throw new ArgumentOutOfRangeException("Range of checkins out of rang");
				}

				
				context.Reservations.Update(entity);
				context.SaveChanges();

			}
		}
	}
}
