using Microsoft.AspNetCore.Mvc;

namespace PlayGround.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
