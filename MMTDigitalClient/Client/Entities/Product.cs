using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Client.Entities
{
    public class Product
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("sku")]
        public string SKU { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }
    }
}
