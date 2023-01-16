using FluentValidation;
using GreenFlamingos.Model.Users;

namespace GreenFlamingos.Model
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
             RuleFor(u => u.Password)
            .NotEqual(u => u.RepeatedPassword)
            .WithMessage("Hasła muszą być takie same");
        }

    }
}
