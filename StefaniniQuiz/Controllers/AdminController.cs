using Microsoft.AspNetCore.Mvc;

namespace StefaniniQuiz.API.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
