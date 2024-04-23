using App.Domain.Representatives;
using App.Domain.Representatives.Dtos;
using App.Domain.Users.Auths;

namespace App.Dashboard.Controllers;

public class ProductController : BaseController
{
    public IService<Representative> _service { get; }

    public ProductController(IService<Representative> service)
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

        return View(await _service.GetByIdAsync<RepresentativeDetailsDto>(id));

    }

    [HttpGet]
    public IActionResult Create() => View(new Result<RepresentativeCreateDto>());


    [HttpPost]
    public async Task<IActionResult> Create(RepresentativeCreateDto dto)
    {

        var response = await _service.CreateAsync(dto);
        return response.IsSuccess
            ? RedirectToAction("Index", new { mes = true }) : View(dto);

    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var dto = await _service.GetByIdAsync<RepresentativeUpdateDto>(id);
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(RepresentativeUpdateDto dto)
    {
        var response = await _service.UpdateAsync(dto);
        return response.IsSuccess
                 ? RedirectToAction("Index", new { mes = true })
                   : View(response.To(dto));
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _service.SoftDeleteByIdAsync<RepresentativeDetailsDto>(id);
        return response.IsSuccess
                  ? RedirectToAction("Index", new { mes = true })
                    : RedirectToAction("Index");

    }

    [HttpGet]
    public async Task<IActionResult> ResetPassword(/*int id*/)
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPassword Representative)
    {

        return HandelException(new());
    }

    [HttpGet]
    public async Task<IActionResult> CommisionReport(int id)
    {
        return View();
    }


    [HttpGet]
    public async Task<IActionResult> Pay(int id)
    {
        return View();
    }

}

