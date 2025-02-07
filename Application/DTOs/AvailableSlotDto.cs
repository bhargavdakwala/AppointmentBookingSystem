namespace AppointmentBookingSystem.Application.DTOs
{
	/// <summary>
	/// Represents an available appointment slot.
	/// </summary>
	public class AvailableSlotDto
	{
		/// <summary>
		/// Gets or sets the count of available slots for the specified time.
		/// </summary>
		public int available_count { get; set; }
		/// <summary>
		/// Gets or sets the start date and time of the available slot.
		/// </summary>
		public DateTime start_date { get; set; }
	}
}
