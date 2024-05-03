using App.Application.Files;
using App.Domain.Products;
using App.Domain.Products.Dtos;

namespace App.Dashboard.Controllers;

public class ProductController : BaseController
{
    public IService<Product> _service { get; }
    public IFileService _fileService { get; }

    public ProductController(IService<Product> service, IFileService fileService)
    {
        _service = service;
        _fileService = fileService;
    }


    [HttpGet]
    public async Task<IActionResult> Index(ProductFilter filter, bool? mes)
    {


        ViewBag.Pageindex = filter.PageIndex;
        ViewBag.Action = mes == null ? false : mes;
        var data = await _service.FindAsync<ListProductDto>(filter);
        return View(data);


    }


    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var data = await _service.GetByIdAsync<DetailsProductDto>(id);

        //var file = _fileService.GetFileBase64(data.Response.Image, "Product-img");
        return View(data);
    }


    [HttpGet]
    public IActionResult Create() => View(new Result<CreateProductDto>());


    [HttpPost]
    public async Task<IActionResult> Create(Result<CreateProductDto> dto)
    {

        var response = await _service.CreateAsync(dto.Response);
        return response.IsSuccess
            ? RedirectToAction("Index", new { mes = true }) : View(response);

    }

    [HttpGet]
    public async Task<IActionResult> Update(int id) => View(await _service.GetByIdAsync<UpdateProductDto>(id));


    [HttpPost]
    public async Task<IActionResult> Update(UpdateProductDto dto)
    {
        var response = await _service.UpdateAsync(dto);
        return response.IsSuccess
                 ? RedirectToAction("Index", new { mes = true })
                   : View(response.To(dto));
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _service.SoftDeleteByIdAsync<DetailsProductDto>(id);
        return response.IsSuccess
                  ? RedirectToAction("Index", new { mes = true })
                    : RedirectToAction("Index");

    }


}

