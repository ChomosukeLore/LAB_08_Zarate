using LAB_08_Zarate.Models;

namespace LAB_08_Zarate.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly LinqexampleContext _context;

        public ProductRepository(LinqexampleContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProductsWithPriceGreaterThan(decimal minPrice)
        {
            return _context.Products
                .Where(p => p.Price > minPrice)
                .ToList();
        }

        public Product? GetMostExpensiveProduct()
        {
            return _context.Products
                .OrderByDescending(p => p.Price)
                .FirstOrDefault();
        }

        public decimal GetAveragePrice()
        {
            if (!_context.Products.Any())
                return 0;

            return _context.Products
                .Select(p => p.Price)
                .Average();
        }

        public IEnumerable<Product> GetProductsWithoutDescription()
        {
            return _context.Products
                .Where(p => string.IsNullOrEmpty(p.Description))
                .ToList(); 
        }
    }
}