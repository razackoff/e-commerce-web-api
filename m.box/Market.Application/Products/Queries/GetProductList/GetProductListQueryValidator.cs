using FluentValidation;

namespace Market.Application.Products.Queries.GetProductList
{
    internal class GetProductListQueryValidator : AbstractValidator<GetProductListQuery>
    {
        public GetProductListQueryValidator()
        {
        }
    }
}
