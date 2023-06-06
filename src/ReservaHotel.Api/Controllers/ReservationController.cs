using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Api.Models;
using ReservaHotel.Api.Controllers;

namespace ReservaHotel.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ReservationController : ControllerBase
    {
        private static int id = 0;

        private static List<Reservation> _reservations = new List<Reservation>();
        private Client _client = new Client { clientId = 1, CPF = "12345678923", Name = "Luisinho" };
        private Room _room = new Room { RoomId = 1, NumberRoom = 201 };


        [HttpPost]
        public IActionResult CreateReservation([FromBody] Reservation reservation)
        {
            if (reservation.clientId != _client.clientId) return NotFound("Cliente não encontrado");

            if (reservation == null) return BadRequest();

            reservation.reservationId = id++;

            _reservations.Add(reservation);
            return Ok(reservation);
        }

        [HttpGet]
        public IActionResult GetAllReservation() 
        {
            return Ok(_reservations);
        }

        [HttpGet("{id}")]
        public IActionResult GetReservationById(int id) 
        {
            var reservation = _reservations.FirstOrDefault(reservation => reservation.reservationId == id);

            if (reservation == null) return NotFound();
            return Ok(reservation);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteReservation(int id) 
        {
            var reservation = _reservations.FirstOrDefault(reservation => reservation.reservationId == id);
            if (reservation == null) return NotFound();

            _reservations.Remove(reservation);
            return Ok(reservation.reservationId);// Falta adiconar clientId
        }

        [HttpGet("Availability")]

        public IActionResult GetAvailability([FromBody] DateReserved dates)
        { 
            foreach (var reservation in _reservations)
            {
                switch (DateTime.Compare(dates.init, reservation.data_init))
                {
                    case 0:
                        return Ok(new
                        {
                            Disponibilidade = "Reservado",
                            Mensagem = $"O período de {dates.init} à {dates.init} está Reservado"
                        });

                    case 1:
                        if (DateTime.Compare(dates.init, reservation.data_finish) == 1)
                        {
                            return Ok(new
                            {
                                Disponibilidade = "Disponível",
                                Mensagem = $"O período de {dates.init} à {dates.finish} está Disponível"
                            });
                        }
                        else
                        {
                            return Ok(new
                            {
                                Disponibilidade = "Reservado",
                                Mensagem = $"O período de {dates.init} à {dates.finish} está Reservado"
                            });
                        }
                    case -1:
                        if (DateTime.Compare(reservation.data_init, dates.finish) == -1)
                        {
                            return Ok(new
                            {
                                Disponibilidade = "Disponível",
                                Mensagem = $"O período de {dates.init} à {dates.finish} está Disponível"
                            });
                        }
                        else
                        {
                            return Ok(new
                            {
                                Disponibilidade = "Reservado",
                                Mensagem = $"O período de {dates.init} à {dates.finish} está Reservado"
                            });
                        }
                    }
                }
            if (_reservations == null) return Ok(new
            {
                Disponibilidade = "Reservado",
                Mensagem = $"O período de {dates.init} à {dates.finish} está Reservado"
            });

            return BadRequest();
            }

        //[HttpPut("{reservationid}/{clientid}")]

        //public IActionResult UpdateReservation([FromQuery] int reservationId, int clientId)
        //{

        //}
    }
}

