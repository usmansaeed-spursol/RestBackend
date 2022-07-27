using Newtonsoft.Json;

namespace PersonalProduct.API.Models.Responses
{
    public class ProductResponse
    {
        
        [JsonProperty("ProductId")]
        public virtual int Id { get; set; }
        [JsonProperty("ProductName")]
        public virtual string ProductName { get; set; }
        [JsonProperty("ProductDescription")]
        public virtual string ProductDescription { get; set; }
        }
}
