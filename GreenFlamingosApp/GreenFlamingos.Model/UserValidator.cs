using FluentValidation;
using GreenFlamingos.Model.Users;

namespace GreenFlamingos.Model
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u)
               .Must(u => u.Password == u.RepeatedPassword)
               .WithMessage("CHUUUUUUUUUUUUJ CI W DUPE BOLEK");
        }

    }
}
