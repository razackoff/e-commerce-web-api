using MediatR;

namespace Market.Application.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<ProductListVm>
    {
        public Guid UserId { get; set; }
    }
}
