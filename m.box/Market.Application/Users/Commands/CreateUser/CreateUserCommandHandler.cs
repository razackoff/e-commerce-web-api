using System;
using MediatR;
using Market.Domain;
using Market.Application.Interfaces;

namespace Market.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler 
        : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserDbContext _dbContext;

        public CreateUserCommandHandler(IUserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = request.Id,
                PhoneNumber = request.PhoneNumber,
                Password = request.Password,
                FirstName = request.FirstName,
                SecondName = request.SecondName,
                DateOfBirth = request.DateOfBirth,
                Region = request.Region,
                Locality = request.Locality,
                Gender = request.Gender,
                Email = request.Email,
                CreationDate = DateTime.Now
            };

            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
