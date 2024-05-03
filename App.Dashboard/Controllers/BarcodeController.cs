using App.Domain.Barcodes;
using App.Domain.Barcodes.Dtos;

namespace App.Dashboard.Controllers;

public class BarcodeController : BaseController
{

    #region ctor
    private readonly IService<Barcode> _service;

    public BarcodeController(IService<Barcode> service)
    {
        _service = service;
    }

    #endregion


    [HttpGet]
    public async Task<IActionResult> Update()
    {
        return View(await _service.FirstOrDefaultAsync<UpdateBarcodeDto>());
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

}
