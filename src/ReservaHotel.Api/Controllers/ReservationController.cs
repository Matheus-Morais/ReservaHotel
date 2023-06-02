using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Api.Models;
using ReservaHotel.Api.Controllers;

namespace ReservaHotel.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ReservationController : ControllerBase
    {
        private static List<Reservation> _reservations = new List<Reservation>();
        private Room _room = new Room { RoomId = 1, IsAvailable = true, NumberRoom = 201 };

        [HttpPost]
        public IActionResult CreateReservation([FromBody] Reservation reservation)
        {
            if(reservation == null) return BadRequest();

            reservation.reservationId += 1;
            _reservations.Add(reservation);
            return Ok(reservation);
        }

        [HttpGet]
        public IActionResult GetReservationById([FromQuery] int reservationId) 
        {
            var reservation = _reservations.FirstOrDefault(reservation => reservation.reservationId == reservationId);

            if (reservation == null) return NotFound();
            return Ok(reservation);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteReservation([FromQuery] int reservationId) 
        {
            var reservation = _reservations.FirstOrDefault(reservation => reservation.reservationId == reservationId);
            if (reservation == null) return NotFound();

            _reservations.Remove(reservation);
            return Ok(reservation.reservationId);// Falta adiconar clientId
        }

        [HttpGet("availability")]

        public IActionResult GetAvailability([FromBody] string data_init, string data_finish)
        { 
            if (data_init == null || data_finish == null) return BadRequest();

            
        }

        //[HttpPut("{reservationid}/{clientid}")]

        //public IActionResult UpdateReservation([FromQuery] int reservationId, int clientId)
        //{

        //}
    }
}

