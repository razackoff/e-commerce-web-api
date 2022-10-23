using Market.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Market.Application.Common.Exceptions;
using Market.Domain;
using static Market.Domain.User;

namespace Market.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler
        : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserDbContext dbContext;

        public UpdateUserCommandHandler(IUserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateUserCommand request,
            CancellationToken cancellationToken)
        {
            var entity = 
                await dbContext.Users.FirstOrDefaultAsync(user => 
                user.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            entity.PhoneNumber = request.PhoneNumber;
            entity.Password = request.Password;
            entity.FirstName = request.FirstName;
            entity.SecondName = request.SecondName;
            entity.DateOfBirth = request.DateOfBirth;
            entity.Region = request.Region;
            entity.Locality = request.Locality;
            entity.Gender = request.Gender;
            entity.Email = request.Email;
            entity.EditDate = DateTime.Now;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
