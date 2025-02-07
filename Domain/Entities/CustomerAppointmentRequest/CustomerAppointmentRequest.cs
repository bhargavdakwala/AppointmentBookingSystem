namespace AppointmentBookingSystem.Domain.Entities.CustomerAppointmentRequest
{
	public class CustomerAppointmentRequest
	{
		public string Language { get; set; }
		public List<string> Products { get; set; }
		public string CustomerRating { get; set; }
		public DateTime RequestedSlotStartTime { get; set; }
		public DateTime RequestedSlotEndTime { get; set; }
	}
}
