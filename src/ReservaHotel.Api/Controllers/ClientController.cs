using Microsoft.AspNetCore.Mvc;

namespace ReservaHotel.Api.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
