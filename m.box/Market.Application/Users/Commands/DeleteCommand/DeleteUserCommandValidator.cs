using FluentValidation;

namespace Market.Application.Users.Commands.DeleteCommand
{
    internal class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(deleteUserCommand =>
                deleteUserCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
