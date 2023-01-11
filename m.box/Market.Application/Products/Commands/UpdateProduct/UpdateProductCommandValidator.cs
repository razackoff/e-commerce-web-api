using FluentValidation;

namespace Market.Application.Products.Commands.UpdateProduct
{
    internal class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(updateProductCommand =>
                updateProductCommand.Name).NotEmpty().MaximumLength(100);
            RuleFor(updateProductCommand =>
                updateProductCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateProductCommand =>
                updateProductCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
