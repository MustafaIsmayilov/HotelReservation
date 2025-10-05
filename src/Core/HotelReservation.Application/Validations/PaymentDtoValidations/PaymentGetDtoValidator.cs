using FluentValidation;
using HotelReservation.Application.DTOs.PaymentDto;

namespace HotelReservation.Application.Validations.PaymentDtoValidations;

public class PaymentGetDtoValidator : AbstractValidator<PaymentGetDto>
{
    public PaymentGetDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Payment ID cannot be empty.");

        RuleFor(p => p.ReservationId)
            .NotEmpty().WithMessage("Reservation ID cannot be empty.");

        RuleFor(p => p.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than zero.");

        RuleFor(p => p.Method)
            .IsInEnum().WithMessage("Payment method must be valid.");

        RuleFor(p => p.Status)
            .IsInEnum().WithMessage("Payment status must be valid.");

        RuleFor(p => p.PaymentDate)
            .NotEmpty().WithMessage("Payment date cannot be empty.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Payment date cannot be in the future.");
    }
}
