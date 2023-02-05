﻿using ApiTask.Bll.Models;
using ApiTask.Bll.Services;
using ApiTask.Dal.Contexts;
using ApiTask.Dal.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiTaskFromFurdak.Controllers;

[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status200OK)]
[Produces("application/json")]
public sealed class ProductsController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly IProductsService _productsService;

    public ProductsController(IMapper mapper, IProductsService productsService)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
    }

    [HttpGet("Products")]
    public async Task<IActionResult> GetProductsAsync()
    {
        return Ok(await _productsService.GetAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductAsync([Required] int id)
    {
        return Ok(await _productsService.FindProductAsync(new ProductForSearchDto { Id = id }));
    }

    [HttpGet]
    public async Task<IActionResult> GetProductByCategoryAsync([Required] string category)
    {
        return Ok(await _productsService.FindProductsAsync(new ProductForSearchDto { Category = category }));
    }

    [HttpPost("{id:int}/Quantity")]
    public async Task<IActionResult> ChangeProductQuantiyAsync([Required] int id, [Required][FromBody] int quantity)
    {
        return Ok(await _productsService.ChangeProductQuantityAsync(id, quantity));
    }

    [HttpPost]
    public async Task<IActionResult> AddProductAsync([Required][FromBody] ProductForInsertAndUpdateDto product)
    {
        return Ok(await _productsService.AddAsync(_mapper.Map<Product>(product)));
    }

    [HttpPost("{id:int}/Attribute")]
    public async Task<IActionResult> ChangeProductAttributesAsync([Required] int id, [Required][FromBody] List<ProductAttribute> productAttributes)
    {
        return Ok(await _productsService.ChangeProductAttributesAsync(id, productAttributes));
    }

    [HttpPatch("{id:int}/Attribute")]
    public async Task<IActionResult> AddProductAttributesAsync([Required] int id, [Required][FromBody] List<ProductAttribute> productAttributes)
    {
        return Ok(await _productsService.AddProductAttributesAsync(id, productAttributes));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> RemoveProductAsync([Required] int id)
    {
        await _productsService.RemoveAsync(id);

        return NoContent();
    }
}
