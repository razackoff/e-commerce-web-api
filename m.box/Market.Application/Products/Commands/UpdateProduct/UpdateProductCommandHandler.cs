using Market.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Market.Application.Common.Exceptions;
using Market.Domain;

namespace Market.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductDbContext dbContext;
        
        public UpdateProductCommandHandler(IProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            var entity = 
                await dbContext.Products.FirstOrDefaultAsync(products => 
                products.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            entity.UserId = request.UserId;
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Price = request.Price;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
