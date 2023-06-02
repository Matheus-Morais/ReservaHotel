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
        private Client _client = new Client { clientId = 1, CPF = "12345678923", Name ="Luisinho"};
        private Room _room = new Room { RoomId = 1, NumberRoom = 201 };
        

        [HttpPost]
        public IActionResult CreateReservation([FromBody] Reservation reservation, int clientId)
        {
            if (clientId != _client.clientId) return NotFound("Cliente não encontrado");

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

        public IActionResult GetAvailability([FromBody] DateTime data_init, DateTime data_finish)
        { 
            if (data_init == null || data_finish == null) return BadRequest();

            foreach (var reservation in _reservations)
            {
                switch (DateTime.Compare(data_init, reservation.data_init))
                {
                    case 0:
                        return Ok(new
                        {
                            Disponibilidade = "Reservado",
                            Mensagem = $"O período de {data_init} à {data_finish} está Reservado"
                        });

                    case 1:
                        if (DateTime.Compare(data_init, reservation.data_finish) == 1)
                        {
                            return Ok(new
                            {
                                Disponibilidade = "Disponível",
                                Mensagem = $"O período de {data_init} à {data_finish} está Disponível"
                            });
                        }
                        else
                        {
                            return Ok(new
                            {
                                Disponibilidade = "Reservado",
                                Mensagem = $"O período de {data_init} à {data_finish} está Reservado"
                            });
                        }
                    case -1:
                        if (DateTime.Compare(reservation.data_init, data_finish) == -1)
                        {
                            return Ok(new
                            {
                                Disponibilidade = "Disponível",
                                Mensagem = $"O período de {data_init} à {data_finish} está Disponível"
                            });
                        }
                        else
                        {
                            return Ok(new
                            {
                                Disponibilidade = "Reservado",
                                Mensagem = $"O período de {data_init} à {data_finish} está Reservado"
                            });
                        }
                    }
                }
            return BadRequest();

            }

        //[HttpPut("{reservationid}/{clientid}")]

        //public IActionResult UpdateReservation([FromQuery] int reservationId, int clientId)
        //{

        //}
    }
}

