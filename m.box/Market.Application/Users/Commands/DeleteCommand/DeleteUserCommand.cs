using MediatR;

namespace Market.Application.Users.Commands.DeleteCommand
{
    public class DeleteUserCommand : IRequest
    {
        public Guid Id { get; set; }
    } 
}
