using App.Domain.Representatives;
using App.Domain.Representatives.Dtos;

namespace App.Dashboard.Controllers;

public class OrderController : BaseController
{
    public IService<Representative> _service { get; }

    public OrderController(IService<Representative> service)
    {
        _service = service;
    }


    [HttpGet]
    public async Task<IActionResult> Index(RepresentativeFilter filter, bool? mes)
    {


        ViewBag.Pageindex = filter.PageIndex;
        ViewBag.Action = mes == null ? false : mes;
        var data = await _service.FindAsync<RepresentativeListDto>(filter);
        return View(data);


    }


    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {

        return View(await _service.GetByIdAsync<RepresentativeDetailsDto>(1));

    }

    [HttpPost]
    public async Task<IActionResult> ChangeStatus(int id)
    {

        return View(await _service.GetByIdAsync<RepresentativeDetailsDto>(id));

    }




}

