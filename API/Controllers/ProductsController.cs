using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IGenericRepository<Product> _productsRepo;
    private readonly IGenericRepository<ProductBrand> _productBrand;
    private readonly IGenericRepository<ProductType> _productTypeRepo;
    private readonly IMapper _mapper;

    public ProductsController(
            IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductBrand> productBrand,
            IGenericRepository<ProductType> productTypeRepo,
            IMapper mapper
        )
    {
        _productsRepo = productsRepo;
        _productBrand = productBrand;
        _productTypeRepo = productTypeRepo;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
    {
        var spec = new ProductsWIthTypesAndBrandsSpecification();
        
        var products = await _productsRepo.ListAsync(spec);

        return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
    {
        var spec = new ProductsWIthTypesAndBrandsSpecification(id);
        
        var product = await _productsRepo.GetEntityWithSpec(spec);

        return _mapper.Map<Product, ProductToReturnDto>(product);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
    {
        var result = await _productBrand.ListAllAsync();

        return Ok(result);
    }
    
    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
    {
        var result = await _productTypeRepo.ListAllAsync();

        return Ok(result);
    }
}