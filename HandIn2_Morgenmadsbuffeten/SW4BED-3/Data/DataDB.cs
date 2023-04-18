using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SW4BED_3.Models;

namespace SW4BED_3.Data
{
	public class DataDB : DbContext
	{
		public DataDB(DbContextOptions<DataDB> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Rooms>().HasKey(r => r.RoomNumber);
			modelBuilder.Entity<Reservations>().HasKey(r => r.ReservationId);
		}

		public DbSet<Rooms> Rooms { get; set; }
		public DbSet<Reservations> Reservations { get; set; }

	}
}

