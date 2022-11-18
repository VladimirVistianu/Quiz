using Microsoft.AspNetCore.Mvc;

namespace StefaniniQuiz.API.Controllers
{
    public class CandidateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
