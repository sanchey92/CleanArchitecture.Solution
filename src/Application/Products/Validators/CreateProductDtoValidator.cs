using Application.Products.Dtos;
using FluentValidation;

namespace Application.Products.Validators;

/// <summary>
/// Validator for the data required to create a product.
/// </summary>
public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateProductDtoValidator"/> class.
    /// </summary>
    public CreateProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().NotEmpty().WithMessage("Name is a required field!")
            .MaximumLength(50).WithMessage("Maximum length for Name is 50 characters.");

        RuleFor(x => x.Description)
            .NotNull().NotEmpty().WithMessage("Description is a required field!")
            .MaximumLength(100).WithMessage("Maximum length for Description is 100 characters.");
    }
}