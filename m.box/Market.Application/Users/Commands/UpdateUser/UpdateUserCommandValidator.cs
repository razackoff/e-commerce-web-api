using FluentValidation;

namespace Market.Application.Users.Commands.UpdateUser
{
    internal class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(updateUserCommand =>
                updateUserCommand.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(updateUserCommand =>
                updateUserCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
