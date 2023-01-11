using System;
using MediatR;
using Market.Domain;
using Market.Application.Interfaces;

namespace Market.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler 
        : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductDbContext _dbContext;

        public CreateProductCommandHandler(IProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = new Product
            {
                UserId = request.UserId,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            await _dbContext.Products.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
