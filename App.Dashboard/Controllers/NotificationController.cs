using App.Domain.Notification;

namespace App.Dashboard.Controllers;

public class NotificationController : BaseController
{
    public IService<SystemNotification> _service { get; }

    public NotificationController(IService<SystemNotification> service)
    {
        _service = service;
    }


    [HttpGet]
    public async Task<IActionResult> List()
    {
        var notifications = (await _service.GetAllAsync()).Response;
        return Ok(new { notifications });


    }


    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _service.DeleteByIdAsync(id));

    }






}

