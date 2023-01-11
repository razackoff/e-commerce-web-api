using FluentValidation;

namespace Market.Application.Products.Commands.DeleteProduct
{
    internal class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(deleteProductCommand =>
                deleteProductCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
