using Entities.Models;
using FluentValidation;
using Services.Abstract;

namespace Services.Validation
{
    public class StaffValidator : AbstractValidator<Staff>
    {

       
        public StaffValidator()
        {
           
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Name cannot be left blanke");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Surname cannot be left blank");
            RuleFor(x => x.Email)
                       .NotEmpty().WithMessage("Email cannot be left blank.")
                       .EmailAddress().WithMessage("Email format is invalid.");
                       

            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone cannot be left blank");
            RuleFor(x => x.Phone).MinimumLength(11).WithMessage("At least 11 characters must be entered");
            RuleFor(x => x.Phone).MaximumLength(11).WithMessage("A maximum of 11 characters must be entered");

        }
     

    }
}
