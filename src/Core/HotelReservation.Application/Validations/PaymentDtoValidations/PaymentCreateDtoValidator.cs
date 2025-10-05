using FluentValidation;
using HotelReservation.Application.DTOs.PaymentDto;

namespace HotelReservation.Application.Validations.PaymentDtoValidations;

public class PaymentCreateDtoValidator : AbstractValidator<PaymentCreateDto>
{
    public PaymentCreateDtoValidator()
    {
        RuleFor(p => p.ReservationId)
            .NotEmpty().WithMessage("Reservation ID cannot be empty.");

        RuleFor(p => p.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than zero.");

        RuleFor(p => p.Method)
            .IsInEnum().WithMessage("Payment method must be valid.");
    }
}
