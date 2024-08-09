using App.Application.Barcodes;
using App.Domain.Barcodes.Dtos;

namespace App.Dashboard.Controllers;

public class BarcodeController : BaseController
{

    #region ctor
    private readonly IBarcodeService _service;

    public BarcodeController(IBarcodeService service)
    {
        _service = service;
    }

    #endregion


    [HttpGet]
    public async Task<IActionResult> Update()
    {
        var result = await _service.FirstOrDefaultAsync<UpdateBarcodeDto>();
        result.Response.NumberOfCodeAvailable = _service.CalulateAvailableCode(result.Response);
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateBarcodeDto dto)
    {
        var response = await _service.UpdateAsync(dto);
        return response.IsSuccess
            //redirect to Index in HomeController with a message
            ? RedirectToAction("Index", "Home", new { mes = true })
                   //? RedirectToAction("Index", new { mes = true })
                   : View(response.To(dto));

        //return View(response);
    }

    [HttpGet]
    //IsBarcodeMinimum
    public async Task<IActionResult> IsBarcodeMinimum()
    {
        var isBarcodeMinimum = await _service.IsBarcodeMinimum();
        return Ok(isBarcodeMinimum);
    }
}
