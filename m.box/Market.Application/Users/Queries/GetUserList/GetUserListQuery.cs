using MediatR;
using static Market.Domain.User;

namespace Market.Application.Users.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<UserListVm>
    {
        
    }
}
