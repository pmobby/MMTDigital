using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Client.Entities
{
    public class Category
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
