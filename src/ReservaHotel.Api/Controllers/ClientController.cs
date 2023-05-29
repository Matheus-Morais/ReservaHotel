using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ReservaHotel.Api.Models;

namespace ReservaHotel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private static List<Client> _clients = new List<Client>();

        [HttpPost]
        public IActionResult AddClient([FromBody]Client client)
        {
            _clients.Add(client);
            return CreatedAtAction(nameof(GetClientById),
                new { id = client.clientId}, client);
        }

        [HttpGet]
        public IEnumerable<Client> GetClient()
        {
            return _clients;
        }

        [HttpGet("{id}")]
        
        public IActionResult GetClientById(int id)
        {
            var client = _clients.FirstOrDefault(client => client.clientId == id);
            if (client == null) return NotFound();
            return Ok(client);
        }
    }
}
