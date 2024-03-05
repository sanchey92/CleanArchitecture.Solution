using Application.Products.Dtos;
using Application.RequestFeatures;
using Application.Specifications;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entity;
using MediatR;

namespace Application.Products.Queries;

/// <summary>
/// Handler for retrieving a list of products based on the specified query.
/// </summary>
internal sealed class GetProductsListHandler 
    : IRequestHandler<GetProductsListQuery, PagedList<ProductToReturnDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetProductsListHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<PagedList<ProductToReturnDto>> Handle(GetProductsListQuery request,
        CancellationToken cancellationToken)
    {
        var specification = new ProductsWithTypesAndBrandsSpecification(request.Params!);
        var countSpecification = new ProductsWithFiltersForCountSpecification(request.Params!);
        var totalCount = await _unitOfWork.Repository<Product>().CountWithSpecificationAsync(countSpecification);
        var products = await _unitOfWork.Repository<Product>().GetListWithSpecificationAsync(specification);
        var items = _mapper.Map<IEnumerable<ProductToReturnDto>>(products);

        var result = new PagedList<ProductToReturnDto>(
            count: totalCount,
            currentPage: request.Params!.PageIndex,
            pageSize: request.Params.PageSize,
            items: items);

        return result;
    }
}
