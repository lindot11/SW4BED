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
									new Reservations { RoomNumber = 2, AdultsReservations = 2, KidsReservations = 2, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 17) },
									new Reservations { RoomNumber = 3, AdultsReservations = 2, KidsReservations = 2, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 17) },
									new Reservations { RoomNumber = 4, AdultsReservations = 2, KidsReservations = 2, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 17) },
									new Reservations { RoomNumber = 5, AdultsReservations = 2, KidsReservations = 2, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 17) },
									new Reservations { RoomNumber = 1, AdultsReservations = 1, KidsReservations = 2, AdultsCheckIn = 1, KidsCheckIn = 2, Date = new DateTime(2023, 4, 18) },
									new Reservations { RoomNumber = 2, AdultsReservations = 2, KidsReservations = 0, AdultsCheckIn = 2, KidsCheckIn = 0, Date = new DateTime(2023, 4, 18) },
									new Reservations { RoomNumber = 3, AdultsReservations = 1, KidsReservations = 1, AdultsCheckIn = 1, KidsCheckIn = 1, Date = new DateTime(2023, 4, 18) },
									new Reservations { RoomNumber = 4, AdultsReservations = 2, KidsReservations = 3, AdultsCheckIn = 2, KidsCheckIn = 3, Date = new DateTime(2023, 4, 18) },
									new Reservations { RoomNumber = 5, AdultsReservations = 1, KidsReservations = 2, AdultsCheckIn = 1, KidsCheckIn = 2, Date = new DateTime(2023, 4, 18) },
									new Reservations { RoomNumber = 6, AdultsReservations = 2, KidsReservations = 0, AdultsCheckIn = 2, KidsCheckIn = 0, Date = new DateTime(2023, 4, 18) },
									new Reservations { RoomNumber = 1, AdultsReservations = 2, KidsReservations = 3, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 19) },
									new Reservations { RoomNumber = 2, AdultsReservations = 2, KidsReservations = 1, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 19) },
									new Reservations { RoomNumber = 3, AdultsReservations = 1, KidsReservations = 1, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 19) },
									new Reservations { RoomNumber = 4, AdultsReservations = 2, KidsReservations = 4, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 19) },
									new Reservations { RoomNumber = 5, AdultsReservations = 1, KidsReservations = 0, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 19) },
									new Reservations { RoomNumber = 6, AdultsReservations = 1, KidsReservations = 2, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 19) },
									new Reservations { RoomNumber = 1, AdultsReservations = 2, KidsReservations = 2, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 20) },
									new Reservations { RoomNumber = 2, AdultsReservations = 1, KidsReservations = 4, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 20) },
									new Reservations { RoomNumber = 3, AdultsReservations = 1, KidsReservations = 2, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 20) },
									new Reservations { RoomNumber = 4, AdultsReservations = 2, KidsReservations = 1, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 20) },
									new Reservations { RoomNumber = 5, AdultsReservations = 2, KidsReservations = 2, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 20) },
									new Reservations { RoomNumber = 6, AdultsReservations = 1, KidsReservations = 1, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 20) },
									new Reservations { RoomNumber = 1, AdultsReservations = 1, KidsReservations = 3, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 21) },
									new Reservations { RoomNumber = 2, AdultsReservations = 1, KidsReservations = 1, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 21) },
									new Reservations { RoomNumber = 3, AdultsReservations = 2, KidsReservations = 0, AdultsCheckIn = 2, KidsCheckIn = 0, Date = new DateTime(2023, 4, 21) },
									new Reservations { RoomNumber = 4, AdultsReservations = 1, KidsReservations = 3, AdultsCheckIn = 0, KidsCheckIn = 3, Date = new DateTime(2023, 4, 21) },
									new Reservations { RoomNumber = 5, AdultsReservations = 1, KidsReservations = 0, AdultsCheckIn = 1, KidsCheckIn = 0, Date = new DateTime(2023, 4, 21) },
									new Reservations { RoomNumber = 6, AdultsReservations = 2, KidsReservations = 4, AdultsCheckIn = 2, KidsCheckIn = 4, Date = new DateTime(2023, 4, 21) },
									new Reservations { RoomNumber = 1, AdultsReservations = 1, KidsReservations = 3, AdultsCheckIn = 1, KidsCheckIn = 3, Date = new DateTime(2023, 4, 22) },
									new Reservations { RoomNumber = 2, AdultsReservations = 2, KidsReservations = 1, AdultsCheckIn = 2, KidsCheckIn = 1, Date = new DateTime(2023, 4, 22) },
									new Reservations { RoomNumber = 3, AdultsReservations = 1, KidsReservations = 0, AdultsCheckIn = 1, KidsCheckIn = 0, Date = new DateTime(2023, 4, 22) },
									new Reservations { RoomNumber = 4, AdultsReservations = 1, KidsReservations = 1, AdultsCheckIn = 1, KidsCheckIn = 1, Date = new DateTime(2023, 4, 22) },
									new Reservations { RoomNumber = 5, AdultsReservations = 2, KidsReservations = 2, AdultsCheckIn = 2, KidsCheckIn = 2, Date = new DateTime(2023, 4, 22) },
									new Reservations { RoomNumber = 6, AdultsReservations = 2, KidsReservations = 4, AdultsCheckIn = 2, KidsCheckIn = 4, Date = new DateTime(2023, 4, 22) },
									new Reservations { RoomNumber = 1, AdultsReservations = 2, KidsReservations = 3, AdultsCheckIn = 2, KidsCheckIn = 3, Date = new DateTime(2023, 4, 23) },
									new Reservations { RoomNumber = 2, AdultsReservations = 2, KidsReservations = 0, AdultsCheckIn = 2, KidsCheckIn = 0, Date = new DateTime(2023, 4, 23) },
									new Reservations { RoomNumber = 3, AdultsReservations = 1, KidsReservations = 2, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 23) },
									new Reservations { RoomNumber = 4, AdultsReservations = 2, KidsReservations = 0, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 23) },
									new Reservations { RoomNumber = 5, AdultsReservations = 1, KidsReservations = 1, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 23) },
									new Reservations { RoomNumber = 6, AdultsReservations = 2, KidsReservations = 2, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 23) },
									new Reservations { RoomNumber = 1, AdultsReservations = 2, KidsReservations = 0, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 24) },
									new Reservations { RoomNumber = 2, AdultsReservations = 1, KidsReservations = 4, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 24) },
									new Reservations { RoomNumber = 3, AdultsReservations = 1, KidsReservations = 2, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 24) },
									new Reservations { RoomNumber = 4, AdultsReservations = 2, KidsReservations = 1, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 24) },
									new Reservations { RoomNumber = 5, AdultsReservations = 2, KidsReservations = 3, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 24) },
									new Reservations { RoomNumber = 6, AdultsReservations = 2, KidsReservations = 1, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 24) },
									new Reservations { RoomNumber = 1, AdultsReservations = 1, KidsReservations = 4, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 25) },
									new Reservations { RoomNumber = 2, AdultsReservations = 1, KidsReservations = 2, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 25) },
									new Reservations { RoomNumber = 3, AdultsReservations = 2, KidsReservations = 2, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 25) },
									new Reservations { RoomNumber = 4, AdultsReservations = 2, KidsReservations = 4, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 25) },
									new Reservations { RoomNumber = 5, AdultsReservations = 1, KidsReservations = 0, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 26) },
									new Reservations { RoomNumber = 6, AdultsReservations = 1, KidsReservations = 1, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 26) },
									new Reservations { RoomNumber = 1, AdultsReservations = 2, KidsReservations = 1, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 27) },
									new Reservations { RoomNumber = 2, AdultsReservations = 1, KidsReservations = 3, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 27) },
									new Reservations { RoomNumber = 3, AdultsReservations = 1, KidsReservations = 2, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 27) },
									new Reservations { RoomNumber = 4, AdultsReservations = 2, KidsReservations = 0, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 27) },
									new Reservations { RoomNumber = 5, AdultsReservations = 1, KidsReservations = 1, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 27) },
									new Reservations { RoomNumber = 6, AdultsReservations = 1, KidsReservations = 0, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 27) },
									new Reservations { RoomNumber = 1, AdultsReservations = 2, KidsReservations = 0, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 28) },
									new Reservations { RoomNumber = 2, AdultsReservations = 1, KidsReservations = 4, AdultsCheckIn = 0, KidsCheckIn = 0, Date = new DateTime(2023, 4, 28) });

				context.SaveChanges();

			}
		}
	}
}