using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class Contato : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
