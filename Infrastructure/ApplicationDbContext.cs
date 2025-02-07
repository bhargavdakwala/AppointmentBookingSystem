using AppointmentBookingSystem.Domain.Entities.SalesManager;
using AppointmentBookingSystem.Domain.Entities.Slot;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AppointmentBookingSystem.Infrastructure
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<SalesManager> sales_managers { get; set; }
		public DbSet<Slot> slots { get; set; }

	}
}
