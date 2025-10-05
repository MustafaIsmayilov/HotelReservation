using FluentValidation;
using HotelReservation.Application.DTOs.RoomDto;

namespace HotelReservation.Application.Validations.RoomDtoValidations;

public class RoomGetDtoValidator : AbstractValidator<RoomGetDto>
{
    public RoomGetDtoValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty().WithMessage("Room ID cannot be empty.");

        RuleFor(r => r.Number)
            .NotEmpty().WithMessage("Room number cannot be empty.")
            .MaximumLength(20).WithMessage("Room number cannot exceed 20 characters.");

        RuleFor(r => r.Capacity)
            .GreaterThan(0).WithMessage("Capacity must be greater than zero.");
    }
}
