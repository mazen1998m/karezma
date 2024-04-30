using App.Application.Orders;
using App.Domain.Orders;
using App.Domain.Orders.Dtos;

namespace App.web.Controllers;

public class OrderController : ShareController
{
    public IOderService _service { get; }
    public OrderController(IOderService service)
    {
        _service = service;
    }


    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _service.SoftDeleteByIdAsync<DetailsOrderDto>(id));


    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpPut]
    public async Task<IActionResult> Update(UpdateOrderDto dto)
        => Ok(await _service.UpdateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> Find([FromQuery] OrderFilter filter)
        => Ok(await _service.FindAsync<ListOrderDto>(filter));



}
