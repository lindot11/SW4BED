using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using SW4BED_3.Data;
using SW4BED_3.Models;

namespace SW4BED_3.Seed
{
	public static class SeedData
	{

		public static void SeedRooms(IServiceProvider serviceProvider)
		{
			using (var context = new DataDB(serviceProvider.GetRequiredService<DbContextOptions<DataDB>>()))
			{
				if (context == null || context.Rooms == null)
				{
					throw new ArgumentNullException("Null DataDb");
				}

				if (context.Rooms.Any())
				{
					return;
				}

				context.Rooms.AddRange(
					new Rooms { RoomNumber = 1, Adults = 2, Kids = 2 },
					new Rooms { RoomNumber = 2, Adults = 2, Kids = 2 },
					new Rooms { RoomNumber = 3, Adults = 2, Kids = 2 },
					new Rooms { RoomNumber = 4, Adults = 2, Kids = 2 },
					new Rooms { RoomNumber = 5, Adults = 2, Kids = 2 },
					new Rooms { RoomNumber = 6, Adults = 2, Kids = 2 });
				
				context.SaveChanges();

			}
		}

		public static void SeedReservations(IServiceProvider serviceProvider)
		{
			using (var context = new DataDB(serviceProvider.GetRequiredService<DbContextOptions<DataDB>>()))
			{
				if (context == null || context.Reservations == null)
				{
					throw new ArgumentNullException("Null DataDb");
				}

				if (context.Reservations.Any())
				{
					return;
				}

				context.Reservations.AddRange(
					new Reservations { RoomNumber = 1, AdultsReservations = 2, KidsReservations = 2, AdultsCheckIn = 2, KidsCheckIn = 2, Date = new DateTime(2023, 4, 17) },
					new Reservations { RoomNumber = 2, AdultsReservations = 2, KidsReservations = 2, AdultsCheckIn = 2, KidsCheckIn = 2, Date = new DateTime(2023, 4, 17) },
					new Reservations { RoomNumber = 3, AdultsReservations = 2, KidsReservations = 2, AdultsCheckIn = 2, KidsCheckIn = 2, Date = new DateTime(2023, 4, 17) },
					new Reservations { RoomNumber = 4, AdultsReservations = 2, KidsReservations = 2, AdultsCheckIn = 2, KidsCheckIn = 2, Date = new DateTime(2023, 4, 17) },
					new Reservations { RoomNumber = 5, AdultsReservations = 2, KidsReservations = 2, AdultsCheckIn = 2, KidsCheckIn = 2, Date = new DateTime(2023, 4, 17) });

				context.SaveChanges();

			}
		}
	}
}
