namespace AppointmentBookingSystem.Application.DTOs
{
	public class AppointmentQueryDto
	{
		/// <summary>
		/// The date for the appointment query.
		/// </summary>
		public DateTime Date { get; set; }
		/// <summary>
		/// List of products the customer wants to discuss. currently we have 3 products
		/// </summary
		public List<string> products { get; set; }
		/// <summary>
		/// List of languages spoken by the customer.(e.g., Germand und English).
		/// </summary>
		public List<string> language { get; set; }
		/// <summary>
		/// The rating of the customer (e.g., Gold, Silver, Bronze).
		/// </summary>
		public string rating { get; set; }  // Single string for rating
	}
}
