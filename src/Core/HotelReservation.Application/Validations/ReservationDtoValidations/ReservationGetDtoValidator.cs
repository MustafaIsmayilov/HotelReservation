using FluentValidation;
using HotelReservation.Application.DTOs.ReservationDto;
using HotelReservation.Application.Validations.PaymentDtoValidations;

namespace HotelReservation.Application.Validations.ReservationDtoValidations;

public class ReservationGetDtoValidator : AbstractValidator<ReservationGetDto>
{
    public ReservationGetDtoValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty().WithMessage("Reservation ID cannot be empty.");

        RuleFor(r => r.StartDate)
            .NotEmpty().WithMessage("Start date cannot be empty.")
            .LessThan(r => r.EndDate).WithMessage("Start date must be before end date.");

        RuleFor(r => r.EndDate)
            .NotEmpty().WithMessage("End date cannot be empty.")
            .GreaterThan(r => r.StartDate).WithMessage("End date must be after start date.");

        RuleForEach(r => r.Rooms)
            .SetValidator(new ReservationCreateDtoValidator());

        RuleForEach(r => r.Payments)
            .SetValidator(new PaymentGetDtoValidator());
    }
}
