using Newtonsoft.Json;

namespace PersonalProduct.API.Models.Responses
{
    public class ErrorResponse
    {
        #region Feilds and Properties

        private string message;
        [JsonProperty(PropertyName = "message")]

        public string Message { get { return message; } set { message = value; } }

        #endregion

        #region Constructor

        public ErrorResponse(string message)
        {
            this.message = message;
        }
        #endregion
    }
}
