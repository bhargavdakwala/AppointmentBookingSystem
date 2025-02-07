namespace AppointmentBookingSystem.Domain.Entities.Slot
{
	public class Slot
	{
		public int id { get; set; }
		public DateTime start_date { get; set; }
		public DateTime end_date { get; set; }
		public bool booked { get; set; }
		public int sales_manager_id { get; set; }
	}
}
