using Newtonsoft.Json;

namespace PersonalProduct.API.Models.Responses
{
    public class CustomerTypeResponse
    {
        [JsonProperty("customerTypeId")]
        public virtual int CustomerTypeID { get; set; }
        [JsonProperty("customerTypeName")]
        public virtual string CustomerTypeName { get; set; }
        [JsonProperty("createdOn")]
        public virtual DateTime CreatedOn { get; set; }
        [JsonProperty("createdBy")]
        public virtual string CreatedBy { get; set; }
        [JsonProperty("lastModifiedOn")]
        public virtual DateTime? LastModifiedOn { get; set; }
        [JsonProperty("lastModifiedBy")]
        public virtual string LastModifiedBy { get; set; }
    }
}
