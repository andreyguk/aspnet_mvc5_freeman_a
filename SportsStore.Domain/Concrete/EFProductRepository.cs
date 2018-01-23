using System.Collections.Generic;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EfProductRepository : IProductRepository
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Product> Products => _context.Products;
    }
}