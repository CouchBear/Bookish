using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;
using Bookish.Services;

namespace Bookish.Controllers;

public class MemberController : Controller
{
    private readonly ILogger<MemberController> _logger;
    private readonly IMemberService _myService;

    public MemberController(ILogger<MemberController> logger, IMemberService myService)
    {
        _logger = logger;
        _myService = myService;
    }

    
    public IActionResult Index()
    {

        return View(_myService.Index());
    }

    public IActionResult Add()
    {
        return View("Views/Member/Add.cshtml");
    }

    [HttpPost]
    public IActionResult Add(MemberRequestModel model)

    {if (!ModelState.IsValid)
        { return RedirectToAction("Index"); 
        }
        _myService.Add(model);
        return Redirect("~/Member/Index");

    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
