using Market.Application.Common.Exceptions;
using Market.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Market.Domain;

namespace Market.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler
        : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductDbContext dbContext;

        public DeleteProductCommandHandler(IProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteProductCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await dbContext.Products
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            dbContext.Products.Remove(entity);
            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
