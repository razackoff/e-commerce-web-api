using FluentValidation;

namespace Market.Application.Products.Queries.GetProductDetails
{
    internal class GetProductDetailsQueryValidator : AbstractValidator<GetProductDetailsQuery>
    {
        public GetProductDetailsQueryValidator()
        {
            RuleFor(getProductDetailsQueryValidator =>
                getProductDetailsQueryValidator.Id).NotEqual(Guid.Empty);
        }
    }
}
