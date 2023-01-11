using FluentValidation;

namespace Market.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(createProductCommand =>
                createProductCommand.Name).NotEmpty().MaximumLength(100);
        }
    }
}
 