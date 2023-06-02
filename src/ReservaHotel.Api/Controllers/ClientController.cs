using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ReservaHotel.Api.Models;

namespace ReservaHotel.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ClientController : ControllerBase
    {
        public static List<Client> _clients = new List<Client>();

        [HttpPost]
        public IActionResult AddClient([FromBody]Client client)
        {
            _clients.Add(client);
            return CreatedAtAction(nameof(GetClientById),
                new { id = client.clientId}, client);
        }

        [HttpGet]
        public IEnumerable<Client> GetAllClients()
        {
            return _clients;
        }

        [HttpGet("{id}")]
        
        public IActionResult GetClientById([FromBody] int id)
        {
            var client = _clients.FirstOrDefault(client => client.clientId == id);
            if (client == null) return NotFound();
            return Ok(client);
        }

    }
}
