using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Api.Models;

namespace ReservaHotel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private static List<Reservation> _reservations = new List<Reservation>();

        [HttpPost]
        public IActionResult MakeReservation([FromBody] 
            Room room,
            Reservation reservation)
        {
            if (room.IsAvailable == true)
            {

                _reservations.Add(reservation);
                return Ok(reservation);
            }
            return BadRequest();
        }
    }
}

