using Client.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();        
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("List of Products");
            Console.WriteLine();
            
            await GetProducts();

            Console.WriteLine();
            
            Console.WriteLine("List of Categories");
            Console.WriteLine();

            await GetCategories();
            Console.WriteLine();

            await GetProductsByCategories();

            Console.WriteLine();
            Console.WriteLine("-------------------End of Program-------------------------");
        }

        private static async Task GetProductsByCategories()
        {
            Console.WriteLine("Please enter a category Id no to see products related to that category \n");
            Console.WriteLine("Enter no between 1 and 5: \n");

            int categoryId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("List of Products By Category \n");
            string productHeader = "ID \t SKU \t\t Name \t Description \t\t Price \t Category \t Category ID";
            Console.WriteLine(productHeader);

            var productByCategoryAPIService = client.GetStreamAsync($"api/products/{categoryId}");

            var products = await JsonSerializer.DeserializeAsync<List<Product>>(await productByCategoryAPIService);

            foreach (var product in products)
            {
                Console.Write(product.Id + "\t");
                Console.Write(product.SKU + "\t");
                Console.Write(product.Name + "\t");
                Console.Write(product.Description + "\t");
                Console.Write(product.Price + "\t");
                Console.Write(product.Category + "\t\t\t");
                Console.Write(product.CategoryId + "\t");
                Console.WriteLine();
            }
        }

        private static async Task GetCategories()
        {
            //An instance of client already started its request from get products thread, so no need to define it again

            var categoryAPIService = client.GetStreamAsync("api/products/categories");
            var categories = await JsonSerializer.DeserializeAsync<List<Category>>(await categoryAPIService);
            
            foreach (var itemname in categories)
            {
                Console.WriteLine(itemname.Name);
                Console.WriteLine();
            }            
            
        }

        private static async Task GetProducts()
        {
            client.BaseAddress = new Uri("https://localhost:44369/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var productAPIService = client.GetStreamAsync("api/products");
            var products = await JsonSerializer.DeserializeAsync<List<Product>>(await productAPIService);

            string productHeader = "ID \t SKU \t\t Name \t Description \t\t Price \t Category \t Category ID";
            Console.WriteLine(productHeader);

            foreach (var product in products)
            {
                Console.Write(product.Id + "\t");
                Console.Write(product.SKU + "\t");
                Console.Write(product.Name + "\t");
                Console.Write(product.Description + "\t");
                Console.Write(product.Price + "\t");
                Console.Write(product.Category + "\t\t\t");
                Console.Write(product.CategoryId + "\t");
                Console.WriteLine();                
            }
        }
    }
}
