using Microsoft.AspNetCore.Mvc;

namespace teamProject.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
