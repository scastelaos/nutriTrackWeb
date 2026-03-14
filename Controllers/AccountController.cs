using Microsoft.AspNetCore.Mvc;

namespace nutriTrackWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login() // Aqui eu troquei Index por Login pq vamos abrir a pagina de login 
        {
            return View();
        }
    }
}
