using App.Domain.Products;
using App.Domain.Products.Dtos;

namespace App.web.Controllers;

public class ApiProductController : ShareController
{
    public IService<Product> _service { get; }
    public ApiProductController(IService<Product> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Find([FromQuery] ProductFilter filter)
        => Ok(await _service.FindAsync<ListProductDto>(filter));

}
