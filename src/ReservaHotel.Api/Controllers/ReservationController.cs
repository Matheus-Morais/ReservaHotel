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
        private Room _room = new Room { RoomId = 1, IsAvailable = true, NumberRoom = 201 };

        [HttpPost]
        public IActionResult CreateReservation([FromBody] Reservation reservation)
        {
            if(reservation == null) return BadRequest();

            if (_room.IsAvailable)
            {
                _reservations.Add(reservation);
                _room.IsAvailable = false;
                return Ok(reservation);
            }
            else return BadRequest();
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

