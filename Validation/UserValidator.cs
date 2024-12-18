using FluentValidation;
using Validation.Models;

namespace Validation.Validation;

public class UserValidator : AbstractValidator<CreateUserModel>
{
    public UserValidator()
    {

        RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("E-mail inválido");
        RuleFor(x => x.Password).Length(10);
        RuleFor(x => x.Username).NotEmpty().WithMessage("Informe o nome do usuário"); ;
        RuleFor(x => x.Salary).InclusiveBetween(1420, 5000);
    }
}