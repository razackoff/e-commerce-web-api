using FluentValidation;

namespace Market.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(createUserCommand =>
                createUserCommand.FirstName).NotEmpty().MaximumLength(100);
        }
    }
}
 