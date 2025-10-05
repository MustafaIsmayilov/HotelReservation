using FluentValidation;
using HotelReservation.Application.DTOs.ReservationDto;

namespace HotelReservation.Application.Validations.ReservationDtoValidations;

public class ReservationCreateDtoValidator : AbstractValidator<ReservationCreateDto>
{
    public ReservationCreateDtoValidator()
    {
        RuleFor(r => r.StartDate)
            .NotEmpty().WithMessage("Start date cannot be empty.")
            .LessThan(r => r.EndDate).WithMessage("Start date must be before end date.");

        RuleFor(r => r.EndDate)
            .NotEmpty().WithMessage("End date cannot be empty.")
            .GreaterThan(r => r.StartDate).WithMessage("End date must be after start date.");

        RuleFor(r => r.RoomIds)
            .NotEmpty().WithMessage("At least one room must be selected.");
    }
}
