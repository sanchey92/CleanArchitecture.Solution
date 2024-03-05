using Application.Products.Validators;
using FluentValidation;

namespace Application.Products.Commands;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Dto).SetValidator(new CreateProductDtoValidator()!);
    }
}