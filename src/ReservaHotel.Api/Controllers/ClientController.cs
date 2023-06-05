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
            client.clientId += 1;
            _clients.Add(client);
            return CreatedAtAction(nameof(GetClientById),
                new { id = client.clientId}, client);
        }

        [HttpGet("ListAll")]
        public IEnumerable<Client> GetAllClients()
        {
            return _clients;
        }

        [HttpGet("ById/{id}")]
        
        public IActionResult GetClientById(int id)
        {
            var client = _clients.FirstOrDefault(client => client.clientId == id);
            if (client == null) return NotFound();
            return Ok(client);
        }

    }
}
