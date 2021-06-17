using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core.Entities;

namespace Web.Core.Interfaces
{
    public interface IProductRepository
    {        
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<Category>> GetCategoriesAsync();
        Task<IReadOnlyList<Product>> GetProductByCategoriesAsync(int categoryId);
    }
}
