using App.Application.Orders;
using App.Domain.Constants.Enums;
using App.Domain.Orders;
using App.Domain.Orders.Dtos;

namespace App.Dashboard.Controllers;

public class OrderController : BaseController
{
    public IOderService _service { get; }

    public OrderController(IOderService service)
    {
        _service = service;
    }


    [HttpGet]
    public async Task<IActionResult> Index(OrderFilter filter, bool? mes)
    {


        ViewBag.Pageindex = filter.PageIndex;
        ViewBag.Action = mes == null ? false : mes;
        var data = await _service.FindAsync<ListOrderDto>(filter);
        return View(data);


    }


    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var data = await _service.GetByIdAsync<DetailsOrderDto>(id);
        return View(data);

    }

    [HttpPost]
    public async Task<IActionResult> ChangeStatus(int id, OrderStatus status)
    {

        return Ok(await _service.ChangeStatus(id, status));

    }




}

