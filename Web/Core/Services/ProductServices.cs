using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core.Entities;
using Web.Core.Interfaces;

namespace Web.Core.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductServices> _logger;
        public ProductServices(IProductRepository productRepository, ILogger<ProductServices> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }
        public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
        {
            return await _productRepository.GetCategoriesAsync();
        }

        public async Task<IEnumerable<Product>> GetFeaturedProducts()
        {
            var products = await _productRepository.GetProductsAsync();

            try
            {            
                var featuredProducts = products.Where(s => s.SKU.StartsWith("1") || s.SKU.StartsWith("2") || s.SKU.StartsWith("3"));

                //for future, if the featured products changed, then a list with sku codes can be created and handled as shown below
                //var featuredProducts = products.where(s => skulist.Any(p =>s.StartsWith(f));

                return featuredProducts;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }

            return products;
            
        }

        public async Task<IReadOnlyList<Product>> GetProductByCategoriesAsync(int categoryId)
        {
            return await _productRepository.GetProductByCategoriesAsync(categoryId);
        }
    }
}
