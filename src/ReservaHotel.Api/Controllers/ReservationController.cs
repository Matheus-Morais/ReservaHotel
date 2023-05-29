using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Api.Models;

namespace ReservaHotel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        [HttpPost]
        public IActionResult MakeReservation([FromBody] 
            Room room,
            Reservation reservation)
        {
            if (room.IsAvailable == true)
            {

            }
        }
    }
}
