using AppointmentBookingSystem.Domain.Entities;
using AppointmentBookingSystem.Domain.Entities.SalesManager;
using AppointmentBookingSystem.Domain.Entities.Slot;

namespace AppointmentBookingSystem.Infrastructure;

public interface IAppointmentRepository
{
	Task<List<SalesManager>> GetSalesManagersAsync(List<string> language, List<string> products, string rating);
	Task<List<Slot>> GetAvailableSlotsAsync(List<int> salesManagerIds, DateTime date);
}
