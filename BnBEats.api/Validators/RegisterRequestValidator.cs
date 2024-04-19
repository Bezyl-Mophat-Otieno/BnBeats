namespace BnBEats.api;

using System.Data;
using BnBEats.contracts.Authentications;
using FluentValidation;


public class RegisterRequestValidator:AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty()
            .EmailAddress()
            .AfterSunrise();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        RuleFor(x => x.FirstName).NotEmpty().Length(2, 50).ChildRules(
            x => x.RuleFor(y => y).Matches("^[a-zA-Z]*$").WithMessage("First name must contain only letters")
         );
        RuleFor(x => x.LastName).NotEmpty().ChildRules(
            x => x.RuleFor(y => y).Matches("^[a-zA-Z]*$").WithMessage("Last name must contain only letters")
        );
        

    }

}
