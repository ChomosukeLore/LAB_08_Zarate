using LAB_08_Zarate.DTOs;
using LAB_08_Zarate.Models;

namespace LAB_08_Zarate.Repositories
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetClientsByName(string name);
        TopClientDto? GetTopClientByOrders();
        IEnumerable<string> GetProductsPurchasedByClient(int clientId);

        IEnumerable<string> GetClientsWhoBoughtProduct(int productId);
    }
}