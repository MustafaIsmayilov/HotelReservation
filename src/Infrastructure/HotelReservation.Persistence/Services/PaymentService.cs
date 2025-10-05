using HotelReservation.Application.Abstracts.Repositories;
using HotelReservation.Application.Abstracts.Services;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Enums;

namespace HotelReservation.Persistence.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepo;
    private readonly IReservationRepository _reservationRepo;

    public PaymentService(IPaymentRepository paymentRepo, IReservationRepository reservationRepo)
    {
        _paymentRepo = paymentRepo;
        _reservationRepo = reservationRepo;
    }

    public async Task<Payment> CreatePaymentAsync(Guid reservationId, decimal amount, PaymentMethod method)
    {
        var reservation = await _reservationRepo.GetByIdAsync(reservationId);
        if (reservation == null)
            throw new KeyNotFoundException("Reservation not found");

        var payment = new Payment
        {
            ReservationId = reservationId,
            Amount = amount,
            Method = method,
            Status = PaymentStatus.Paid,
            PaymentDate = DateTime.UtcNow
        };

        await _paymentRepo.AddAsync(payment);
        return payment;
    }

    public async Task<Payment?> GetPaymentAsync(Guid id) =>
        await _paymentRepo.GetByIdAsync(id);
}

