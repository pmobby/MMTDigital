using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core.Entities;
using Web.Core.Interfaces;
using Web.Infrastructure.EF_Core;

namespace Web.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MMTShopContext _context;
        public ProductRepository(MMTShopContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductByCategoriesAsync(int categoryId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Where(c => c.Category.Id == categoryId)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.Category)                
                .ToListAsync();
        }
    }
}
