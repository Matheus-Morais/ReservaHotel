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

        [HttpGet]
        public IActionResult GetReservationById([FromQuery] int reservationId) 
        {
            var reservation = _reservations.FirstOrDefault(reservation => reservation.reservationId == reservationId);

            if (reservation == null) return NotFound();
            return Ok(reservation);
        }

    }
}

