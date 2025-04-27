using Microsoft.AspNetCore.Mvc;
using MongoPaginationApi.Services;

namespace MongoPaginationApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _service;

    public ProductsController(ProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts(
        [FromQuery] string? category,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var (products, totalItems) = await _service.GetProductsAsync(category, page, pageSize);
        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        return Ok(new
        {
            metadata = new
            {
                page,
                pageSize,
                totalItems,
                totalPages
            },
            data = products
        });
    }
}
