using FluentValidation;
using HotelReservation.Application.DTOs.CustomerDto;

namespace HotelReservation.Application.Validations.CustomerDtoValidations;

public class CustomerGetDtoValidator : AbstractValidator<CustomerGetDto>
{
    public CustomerGetDtoValidator()
    {
        RuleFor(c => c.FullName)
            .NotEmpty().WithMessage("Full name cannot be empty.")
            .MaximumLength(100).WithMessage("Full name cannot exceed 100 characters.");

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Email cannot be empty.")
            .EmailAddress().WithMessage("Email must be a valid email address.");

        RuleFor(c => c.Phone)
            .NotEmpty().WithMessage("Phone cannot be empty.")
            .Matches(@"^\+?[0-9]{7,15}$")
            .WithMessage("Phone number must be in a valid format (+ and 7-15 digits).");
    }
}
