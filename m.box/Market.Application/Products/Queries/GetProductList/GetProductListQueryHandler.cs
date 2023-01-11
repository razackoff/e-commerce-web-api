using AutoMapper;
using AutoMapper.QueryableExtensions;
using Market.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler
        : IRequestHandler<GetProductListQuery, ProductListVm>
    {
        private readonly IProductDbContext dbContext;
        private readonly IMapper mapper; 

        public GetProductListQueryHandler(IProductDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ProductListVm> Handle(GetProductListQuery request,
            CancellationToken cancellationToken)
        {
            var productsQuery = await dbContext.Products
                .Where(product => product.Id != Guid.Empty)
                .ProjectTo<ProductLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProductListVm { Products = productsQuery };
        }
    }
}
