using System;
using MediatR;

namespace Market.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQuery : IRequest<ProductDetailsVm>
    {
        public Guid Id { get; set; }

    }
}
