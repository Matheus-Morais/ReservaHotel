using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Api.Models;
using ReservaHotel.Api.Controllers;

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

        [HttpDelete]

        public IActionResult DeleteReservation([FromQuery] int reservationId) 
        {
            var reservation = _reservations.FirstOrDefault(reservation => reservation.reservationId == reservationId);
            if (reservation == null) return NotFound();

            _reservations.Remove(reservation);
            return Ok(reservation.reservationId);// Falta adiconar clientId
        }

        //[HttpPut]

        //public IActionResult UpdateReservation() { }
    }
}

