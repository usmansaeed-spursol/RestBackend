using Newtonsoft.Json;

namespace PersonalProduct.API.Models.Requests
{
    public class ProductRequest
    {
        [JsonProperty(PropertyName = "ProductName")]
        public string ProductName { get; set; }

        [JsonProperty(PropertyName = "ProductDescription")]
        public string ProductDescription { get; set; }

    }
}
