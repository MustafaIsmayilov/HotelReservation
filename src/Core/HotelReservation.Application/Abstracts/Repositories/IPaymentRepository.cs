using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Abstracts.Repositories;

public interface IPaymentRepository
{
    Task<Payment?> GetByIdAsync(Guid id);
    Task AddAsync(Payment payment);
    Task UpdateAsync(Payment payment);
}
