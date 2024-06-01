using App.Application.Orders;
using App.Domain.Orders;
using App.Domain.Orders.MobileDto;

namespace App.Dashboard.Controllers.Api;

public class MobileOrderController : ShareController
{
    #region ctor
    public IOderService _service { get; }
    public MobileOrderController(IOderService service)
    {
        _service = service;
    }
    #endregion


    [HttpPost]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _service.SoftDeleteByIdAsync<DetailsOrderDto>(id));


    [HttpPost]
    public async Task<IActionResult> Create(Domain.Orders.Dtos.CreateOrderDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpPost]
    public async Task<IActionResult> Update(Domain.Orders.Dtos.UpdateOrderDto dto)
        => Ok(await _service.UpdateOrderAsync(dto));

    [HttpGet]
    public async Task<IActionResult> Find([FromQuery] OrderFilter filter)
    {
        var result = await _service.FindAsync<ListOrderDto>(filter);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
        => Ok(await _service.GetByIdAsync<DetailsOrderDto>(id));

    [HttpGet]
    public async Task<IActionResult> Update(int id)
       => Ok(await _service.GetByIdAsync<Domain.Orders.Dtos.UpdateOrderDto>(id));




}
