using Microsoft.AspNetCore.Mvc;

namespace StefaniniQuiz.API.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
