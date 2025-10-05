using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Enums;

namespace HotelReservation.Application.Abstracts.Services;

public interface IPaymentService
{
    Task<Payment> CreatePaymentAsync(Guid reservationId, decimal amount, PaymentMethod method);
    Task<Payment?> GetPaymentAsync(Guid id);
}