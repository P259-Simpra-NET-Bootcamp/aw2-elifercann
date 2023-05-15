using Entities.Models;
using FluentValidation;

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
            RuleFor(x => x.Phone).MinimumLength(11).WithMessage("Phone at least 11 characters must be entered");
            RuleFor(x => x.Phone).MaximumLength(11).WithMessage("Phone  maximum of 11 characters must be entered");
          
            RuleFor(x => x.City).NotEmpty().WithMessage("City cannot be left blank");
            RuleFor(x => x.City).MaximumLength(40).WithMessage("City  maximum of 40 characters must be entered");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country cannot be left blank");
            RuleFor(x => x.Country).MaximumLength(40).WithMessage("Country  maximum of 40 characters must be entered");
            RuleFor(x => x.Province).NotEmpty().WithMessage("Province cannot be left blank");
            RuleFor(x => x.Province).MaximumLength(40).WithMessage("Province  maximum of 40 characters must be entered");
            RuleFor(x => x.AddressLine1).NotEmpty().WithMessage("Adress cannot be left blank");
            RuleFor(x => x.AddressLine1).MaximumLength(60).WithMessage("Adress  maximum of 40 characters must be entered");


        }
     

    }
}
