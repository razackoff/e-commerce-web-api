using FluentValidation;

namespace Market.Application.Users.Queries.GetUserDetails
{
    internal class GetUserDetailsQueryValidator : AbstractValidator<GetUserDetailsQuery>
    {
        public GetUserDetailsQueryValidator()
        {
            RuleFor(getUserDetailsQueryValidator =>
                getUserDetailsQueryValidator.Id).NotEqual(Guid.Empty);
        }
    }
}
