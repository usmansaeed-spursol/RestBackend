using Newtonsoft.Json;

namespace PersonalProduct.API.Models.Requests
{
    public class CustomerTypeRequest
    {
        [JsonProperty(PropertyName = "CustomerTypeName")]
        public string CustomerTypeName { get; set; }

    }
}
