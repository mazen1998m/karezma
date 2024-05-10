using App.Application.Orders;
using App.Domain.Orders;
using App.Domain.Orders.MobileDto;

namespace App.Dashboard.Controllers.Api;

public class OrderController : ShareController
{
    #region ctor
    public IOderService _service { get; }
    public OrderController(IOderService service)
    {
        _service = service;
    }
    #endregion


    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _service.SoftDeleteByIdAsync<DetailsOrderDto>(id));


    [HttpPost]
    public async Task<IActionResult> Create(Domain.Orders.Dtos.CreateOrderDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpPut]
    public async Task<IActionResult> Update(Domain.Orders.Dtos.UpdateOrderDto dto)
        => Ok(await _service.UpdateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> Find([FromQuery] OrderFilter filter)
        => Ok(await _service.FindAsync<ListOrderDto>(filter));



}
