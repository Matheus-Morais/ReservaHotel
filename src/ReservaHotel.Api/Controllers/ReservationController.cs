using Microsoft.AspNetCore.Mvc;

namespace ReservaHotel.Api.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
