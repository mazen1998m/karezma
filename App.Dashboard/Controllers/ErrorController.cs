namespace App.Dashboard.Controllers;

public class ErrorController : Controller
{
    public IActionResult BadRequest()
    {
        return View();
    }
    public IActionResult InternalServerError()
    {
        return View();
    }
    public IActionResult NotFound()
    {
        return View();
    }
    [Route("PageNotFound")]
    public IActionResult PageNotFound()
    {
        string originalPath = "unknown";
        if (HttpContext.Items.ContainsKey("originalPath"))
        {
            originalPath = HttpContext.Items["originalPath"] as string;
        }
        return View();
    }
    public IActionResult Unutilized()
    {
        string originalPath = "unknown";
        if (HttpContext.Items.ContainsKey("originalPath"))
        {
            originalPath = HttpContext.Items["originalPath"] as string;
        }
        HttpContext.Session.Remove("token");
        return View();
    }

}
