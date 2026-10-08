using LAB_08_Zarate.DTOs;
using LAB_08_Zarate.Models;

namespace LAB_08_Zarate.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly LinqexampleContext _context;

        public ClientRepository(LinqexampleContext context)
        {
            _context = context;
        }

        // Ejercicio 1: Obtener clientes por nombre
        public IEnumerable<Client> GetClientsByName(string name)
        {
            return _context.Clients
                .Where(c => c.Name.StartsWith(name))
                .ToList();
        }

        // Ejercicio 9: Cliente con más pedidos
        public TopClientDto? GetTopClientByOrders()
        {
            return _context.Clients
                .Select(c => new TopClientDto
                {
                    ClientId = c.ClientId,
                    ClientName = c.Name,
                    OrderCount = c.Orders.Count
                })
                .OrderByDescending(dto => dto.OrderCount)
                .FirstOrDefault();
        }

        public IEnumerable<string> GetProductsPurchasedByClient(int clientId)
        {
            return _context.OrderDetails
                .Where(od => od.Order.ClientId == clientId)
                .Select(od => od.Product.Name)
                .Distinct()
                .ToList();
        }

        public IEnumerable<string> GetClientsWhoBoughtProduct(int productId)
        {
            return _context.OrderDetails
                .Where(od => od.ProductId == productId)
                .Select(od => od.Order.Client.Name)
                .Distinct()
                .ToList();
        }
    }
}