using AutoMapper;
using Market.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Market.Application.Common.Exceptions;
using Market.Domain;


namespace Market.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler
        : IRequestHandler<GetProductDetailsQuery, ProductDetailsVm> 
    {
        private readonly IProductDbContext dbContext;
        private readonly IMapper mapper;

        public GetProductDetailsQueryHandler(IProductDbContext dbContext, 
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ProductDetailsVm> Handle(GetProductDetailsQuery request,  
            CancellationToken cancellationToken) 
        {
            var entity = await dbContext.Products
                .FirstOrDefaultAsync(user =>
                user.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            return mapper.Map<ProductDetailsVm>(entity); 
        }
    }
}
