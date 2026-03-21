using Microsoft.AspNetCore.Mvc;
using nutriTrackWeb.Models;

namespace nutriTrackWeb.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Portal(LoginViewModel model)
        {
            return View(model);
        }
    }
}
