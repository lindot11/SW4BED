using Microsoft.EntityFrameworkCore;
using SW4BED_3.Data;
using SW4BED_3.Models;

namespace SW4BED_3.Services
{
	public class ResturantRepository
	{
		public async Task ReservationCheckIn(IServiceProvider serviceProvider, int roomNumber, int adults, int kids)
		{
			await using (var context = new DataDB(serviceProvider.GetRequiredService<DbContextOptions<DataDB>>()))
			{
				if (context == null || context.Rooms == null)
				{
					throw new Exception("NoDataBase");
				}

				var entity = context.Reservations.FirstOrDefault(c => c.RoomNumber == roomNumber && c.Date == DateTime.Today);


				if (entity == null)
				{
					throw new Exception("RoomNumber do not exist or there is no reservation Today");
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

        public async Task AddOrUpdateBreakfastReservation(IServiceProvider serviceProvider, DateTime date, int roomNumber, int adultsReservations, int kidsReservations)
        {
            using (var context = new DataDB(serviceProvider.GetRequiredService<DbContextOptions<DataDB>>()))
            {
                var existingReservation = context.Reservations
                    .FirstOrDefault(r => r.RoomNumber == roomNumber && r.Date.Date == date.Date);

                if (existingReservation != null)
                {
                    existingReservation.AdultsReservations = adultsReservations;
                    existingReservation.KidsReservations = kidsReservations;
                }
                else
                {
                    var newReservation = new Reservations
                    {
                        RoomNumber = roomNumber,
                        AdultsReservations = adultsReservations,
                        KidsReservations = kidsReservations,
                        AdultsCheckIn = 0,
                        KidsCheckIn = 0,
                        Date = date
                    };
                    context.Reservations.Add(newReservation);
                }

                context.SaveChanges();
            }
        }

        public async Task<List<Reservations>> GetCheckedInRoomsAsync(IServiceProvider serviceProvider, DateTime date)
        {
            using var context = new DataDB(serviceProvider.GetRequiredService<DbContextOptions<DataDB>>());
            return await context.Reservations
                .Where(r => r.Date == date && (r.AdultsCheckIn > 0 || r.KidsCheckIn > 0))
                .ToListAsync();
        }


    }
}
