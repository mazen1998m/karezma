using App.Dashboard.Models;
using System.Diagnostics;

namespace App.Dashboard.Controllers;


public class HomeController : BaseController
{

    public HomeController()
    {

    }

    [HttpGet]
    public IActionResult Index(bool? mes)
    {
        ViewBag.Action = mes == null ? false : mes;
        return View();
    }


    [HttpGet]
    public IActionResult ComingSoon()
    {
        return View();
    }


    [HttpGet]
    public IActionResult LogisticsServices()
    {
        return View();
    }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}