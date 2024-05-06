using App.Application.Representatives;
using App.Domain.Representatives;
using App.Domain.Representatives.Dtos;
using App.Domain.Users.Auths;

namespace App.Dashboard.Controllers;

public class RepresentativeController : BaseController
{
    public IRepresentativeService _service { get; }

    public RepresentativeController(IRepresentativeService service)
    {
        _service = service;
    }


    [HttpGet]
    public async Task<IActionResult> Index(RepresentativeFilter filter, bool? mes)
    {


        ViewBag.Pageindex = filter.PageIndex;
        ViewBag.Action = mes == null ? false : mes;
        var data = await _service.FindAsync<ListRepresentativeDto>(filter);
        return View(data);


    }


    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {

        return View(await _service.GetByIdAsync<DetailsRepresentativeDto>(id));

    }

    [HttpGet]
    public IActionResult Create() => View(new Result<CreateRepresentativeDto>());


    [HttpPost]
    public async Task<IActionResult> Create(Result<CreateRepresentativeDto> dto)
    {

        var response = await _service.CreateAsync(dto.Response);
        return response.IsSuccess
            ? RedirectToAction("Index", new { mes = true }) : View(response);

    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var dto = await _service.GetByIdAsync<UpdateRepresentativeDto>(id);
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateRepresentativeDto dto)
    {
        var response = await _service.UpdateAsync(dto);
        return response.IsSuccess
                 ? RedirectToAction("Index", new { mes = true })
                   : View(response.To(dto));
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _service.SoftDeleteByIdAsync<DetailsRepresentativeDto>(id);
        return response.IsSuccess
                  ? RedirectToAction("Index", new { mes = true })
                    : RedirectToAction("Index");

    }

    [HttpGet]
    public IActionResult ResetPassword(int id) => View(new Result<ResetPassword>() { Response = new ResetPassword() { Id = id } });

    [HttpPost]
    public async Task<IActionResult> ResetPassword(Result<ResetPassword> resetPassword)
    {
        var response = await _service.ResetPassword(resetPassword.Response);
        if (response.IsSuccess)
            return RedirectToAction("Index");
        return View(response);
    }

    [HttpGet]
    public async Task<IActionResult> CommisionReport(int id)
    {
        var x = await _service.GetByIdAsync<CommisionReportDto>(id);
        return View(x);
    }


    [HttpGet]
    public async Task<IActionResult> Pay(int id)
    {
        var response = await _service.Pay(id);
        return response
            ? RedirectToAction("Index", new { mes = true })
                  : RedirectToAction("CommisionReport", new { Id = id });

    }

}

