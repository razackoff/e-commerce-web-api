using AutoMapper;
using Market.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Market.Application.Common.Exceptions;
using Market.Domain;


namespace Market.Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler
        : IRequestHandler<GetUserDetailsQuery, UserDetailsVm> 
    {
        private readonly IUserDbContext dbContext;
        private readonly IMapper mapper;

        public GetUserDetailsQueryHandler(IUserDbContext dbContext, 
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request,  
            CancellationToken cancellationToken) 
        {
            var entity = await dbContext.Users
                .FirstOrDefaultAsync(user =>
                user.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            return mapper.Map<UserDetailsVm>(entity); 
        }
    }
}
