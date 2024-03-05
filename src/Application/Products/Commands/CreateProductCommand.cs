using Application.Products.Dtos;
using MediatR;

namespace Application.Products.Commands;

public sealed class CreateProductCommand : IRequest<Unit>
{
    public CreateProductCommand(CreateProductDto? dto)
    {
        Dto = dto;
    }

    public CreateProductDto? Dto { get; init; }
}