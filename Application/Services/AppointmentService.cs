using AppointmentBookingSystem.Application.DTOs;
using AppointmentBookingSystem.Application.Interfaces;
using AppointmentBookingSystem.Domain.Entities.SalesManager;
using AppointmentBookingSystem.Domain.Entities.Slot;
using AppointmentBookingSystem.Infrastructure;

namespace AppointmentBookingSystem.Application.Services;
public class AppointmentService : IAppointmentService
{
	private readonly IAppointmentRepository _appointmentRepository;

	public AppointmentService(IAppointmentRepository appointmentRepository)
	{
		_appointmentRepository = appointmentRepository ?? throw new ArgumentNullException(nameof(appointmentRepository));
	}

	public async Task<List<AvailableSlotDto>> GetAvailableSlotsAsync(AppointmentQueryDto appointmentQuery)
	{
		var salesManagers = await GetMatchingSalesManagersAsync(appointmentQuery);
		var slots = await GetAvailableSlotsForManagersAsync(salesManagers, appointmentQuery.Date);

		return GroupAndCountSlots(slots);
	}

	private async Task<List<SalesManager>> GetMatchingSalesManagersAsync(AppointmentQueryDto appointmentQuery)
	{
		var salesManagers = await _appointmentRepository.GetSalesManagersAsync(
			appointmentQuery.language,
			appointmentQuery.products,
			appointmentQuery.rating
		);

		if (salesManagers == null || !salesManagers.Any())
		{
			throw new InvalidOperationException("No sales managers found for the provided criteria.");
		}

		return salesManagers;
	}

	private async Task<List<Slot>> GetAvailableSlotsForManagersAsync(List<SalesManager> salesManagers, DateTime date)
	{
		var slotIds = salesManagers.Select(sm => sm.id).ToList();
		var availableSlots = await _appointmentRepository.GetAvailableSlotsAsync(slotIds, date);

		if (availableSlots == null || !availableSlots.Any())
		{
			throw new InvalidOperationException("No available slots found for the given date.");
		}

		return availableSlots;
	}

	private List<AvailableSlotDto> GroupAndCountSlots(List<Slot> slots)
	{
		return slots.GroupBy(slot => slot.start_date)
			.Select(group => new AvailableSlotDto
			{
				start_date = group.Key,
				available_count = group.Count()
			})
			.ToList();
	}
}
