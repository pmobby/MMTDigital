using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Core.Entities;

namespace Web.Infrastructure.EF_Core
{
    public class MMTShopContextSeed
    {
        //This class is used to intially add data to the DB. 
        //A check is done each time the app runs to see if data has already populated the DB
        public static async Task SeedDBAsync(MMTShopContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Web/Infrastructure/EF_Core/RawSeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                if (!context.Categories.Any())
                {
                    var categoriesData = File.ReadAllText("../Web/Infrastructure/EF_Core/RawSeedData/categories.json");
                    var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);

                    foreach (var item in categories)
                    {
                        context.Categories.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<MMTShopContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}
