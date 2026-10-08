using LAB_08_Zarate.Models;

namespace LAB_08_Zarate.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProductsWithPriceGreaterThan(decimal minPrice);
        Product? GetMostExpensiveProduct();
        decimal GetAveragePrice();
        
        IEnumerable<Product> GetProductsWithoutDescription();
    }
}