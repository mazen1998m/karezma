using App.Domain.Products;
using App.Domain.Products.MobileDto;

namespace App.Dashboard.Controllers.Api;

public class ProductController : ShareController
{
    #region ctor
    public IService<Product> _service { get; }
    public ProductController(IService<Product> service)
    {
        _service = service;
    }
    #endregion

    [HttpGet]
    public async Task<IActionResult> Find([FromQuery] ProductFilter filter)
        => Ok(await _service.FindAsync<ListProductDto>(filter));

}
