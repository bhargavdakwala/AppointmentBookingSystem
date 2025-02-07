using AppointmentBookingSystem.Application.DTOs;

namespace AppointmentBookingSystem.Application.Interfaces
{
	public interface IAppointmentService
	{
		Task<List<AvailableSlotDto>> GetAvailableSlotsAsync(AppointmentQueryDto query);
	}
}
