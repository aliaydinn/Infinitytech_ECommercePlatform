using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public async Task<IActionResult>Index()
        {
            return View();
        }
    }
}
