using FluentValidation;

namespace Market.Application.Users.Queries.GetUserList
{
    internal class GetUserListQueryValidator : AbstractValidator<GetUserListQuery>
    {
        public GetUserListQueryValidator()
        {
        }
    }
}
