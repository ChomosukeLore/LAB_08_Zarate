using Microsoft.AspNetCore.Mvc;
using LAB_08_Zarate.Repositories;

namespace LAB_08_Zarate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        // GET: api/client/search?name=Juan
        [HttpGet("search")]
        public IActionResult GetClientsByName([FromQuery] string name = "Juan")
        {
            var clients = _clientRepository.GetClientsByName(name);
            return Ok(clients);
        }

        [HttpGet("top-orders")]
        public IActionResult GetTopClientByOrders()
        {
            var topClient = _clientRepository.GetTopClientByOrders();
            if (topClient == null) return NotFound("No se encontraron registros de pedidos.");
            return Ok(topClient);
        }

        [HttpGet("{clientId}/products")]
        public IActionResult GetProductsByClient(int clientId = 1)
        {
            var products = _clientRepository.GetProductsPurchasedByClient(clientId);
            return Ok(products);
        }

        [HttpGet("by-product/{productId}")]
        public IActionResult GetClientsWhoBoughtProduct(int productId = 2)
        {
            var clients = _clientRepository.GetClientsWhoBoughtProduct(productId);
            return Ok(clients);
        }
    }
}