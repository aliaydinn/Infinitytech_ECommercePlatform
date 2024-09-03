using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Controllers
{
    public class AboutUsController : Controller
    {
        public async  Task<IActionResult> Index()
        {
            return View();
        }
    }
}
