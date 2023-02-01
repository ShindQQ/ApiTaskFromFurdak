using ApiTask.Bll.Services;
using ApiTaskCodeFirst.Bll.Models.ForInsert;
using ApiTaskCodeFirst.Dal.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiTaskFromFurdak.Controllers;

[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status200OK)]
public sealed class ProductsController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly IProductsService _productsService;

    public ProductsController(IMapper mapper, IProductsService productsService)
    {
        _mapper = mapper;
        _productsService = productsService;
    }

    [HttpPost]
    public async Task<IActionResult> AddProductAsync(ProductForInsert product)
    {
        return Ok(await _productsService.AddProductAsync(_mapper.Map<Product>(product)));
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveProductAsync(Product product)
    {
        await _productsService.RemovedProductAsync(product);

        return NoContent();
    }
}
