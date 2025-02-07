namespace AppointmentBookingSystem.Domain.Entities.SalesManager
{
	public class SalesManager
	{
		public int id { get; set; }
		public string? name { get; set; }
		public string[]? languages { get; set; }  
		public string[]? products { get; set; }   
		public string[]? customer_ratings { get; set; }
	}
}
