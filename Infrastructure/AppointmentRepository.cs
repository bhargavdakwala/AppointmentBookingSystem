using AppointmentBookingSystem.Domain.Entities;
using AppointmentBookingSystem.Domain.Entities.SalesManager;
using AppointmentBookingSystem.Domain.Entities.Slot;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Linq;

namespace AppointmentBookingSystem.Infrastructure;

public class AppointmentRepository : IAppointmentRepository
{
	private readonly ApplicationDbContext _context;

	public AppointmentRepository(ApplicationDbContext context)
	{
		_context = context;
	}
	/// <summary>
	/// Language:  Currently we have 2 possible languages: German, English  (like ["English", "German"])
	/// Product(s) :  to discuss. Currently we have 2 possible products: SolarPanels, Heatpumps ["SolarPanels", "Heatpumps"]) 
	/// Internal customer rating. Currently we have 3 possible ratings: Gold, Silver, Bronze. like "Gold"

	/// </summary>
	/// <param name="languages"></param>
	/// <param name="products"></param>
	/// <param name="rating"></param>
	/// <returns></returns>
	public async Task<List<SalesManager>> GetSalesManagersAsync(List<string> languages, List<string> products, string rating)
	{

		var query = @"SELECT *  FROM sales_managers 
					WHERE languages && @languages::varchar[]  
					AND products && @products::varchar[]     
					AND @rating = ANY(customer_ratings)";

		var sales = await _context.sales_managers
			.FromSqlRaw(query,
				new NpgsqlParameter("@languages", languages.ToArray()),
				new NpgsqlParameter("@products", products.ToArray()),
				new NpgsqlParameter("@rating", rating))
			.ToListAsync();

		return sales;
	}


	/// <summary>
	/// Line : Comments
	/// 50 : Convert input date to UTC
	/// 53 : Query to get all the slots on the given date for the given sales managers
	/// 55 : Compare the UTC date
	/// 60 : Adjust the slots' times if necessary (depending on your database time zone setup)
	/// 61 : Convert the start_date from its local time zone to UTC (if needed)
	/// 62 : Ensure everything is in UTC
	/// 71 : Now check for overlapping slots and remove any overlapping ones
	/// 73 : Check for overlap
	/// 83 : Return available slots that do not have any overlaps
	/// </summary>
	/// <param name="salesManagerIds"></param>
	/// <param name="date"></param>
	/// <returns></returns>
	public async Task<List<Slot>> GetAvailableSlotsAsync(List<int> salesManagerIds, DateTime date)
	{
		DateTime dateInUtc = DateTime.SpecifyKind(date, DateTimeKind.Utc);
		var slots = await _context.slots
			.Where(s => salesManagerIds.Contains(s.sales_manager_id) &&
						s.start_date.Date == dateInUtc.Date &&
						!s.booked)
			.ToListAsync();

		var adjustedSlots = slots.Select(slot =>
		{

			slot.start_date = slot.start_date.ToUniversalTime();
			return slot;
		}).ToList();

		var availableSlots = new List<Slot>();

		foreach (var slot in adjustedSlots)
		{
			bool hasOverlap = availableSlots.Any(existingSlot =>
				(existingSlot.start_date < slot.end_date && existingSlot.end_date > slot.start_date));

			if (!hasOverlap)
			{
				availableSlots.Add(slot);
			}
		}
		return availableSlots;
	}
}
