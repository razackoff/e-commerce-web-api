using Market.Application.Common.Exceptions;
using Market.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Market.Domain;

namespace Market.Application.Users.Commands.DeleteCommand
{
    public class DeleteUserCommandHandler
        : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserDbContext dbContext;

        public DeleteUserCommandHandler(IUserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteUserCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await dbContext.Users
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            dbContext.Users.Remove(entity);
            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
