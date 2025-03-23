using DotReact.Application.Features.Products.Commands;
using FluentValidation;

namespace DotReact.Application.Features.Validations.ProductValidations;
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün ismi boş geçilemez");
    }
}
