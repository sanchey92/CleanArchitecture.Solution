using AutoMapper;
using Domain.Abstractions;
using Domain.Entity;
using MediatR;

namespace Application.Products.Commands;

internal sealed class CreteProductHandler : IRequestHandler<CreateProductCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreteProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request.Dto);

        await _unitOfWork.Repository<Product>().AddAsync(product);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}