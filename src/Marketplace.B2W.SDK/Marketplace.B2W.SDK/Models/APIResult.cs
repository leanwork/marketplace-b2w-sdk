using System.Net;

namespace Marketplace.B2W.SDK.Models
{
    public class APIResult
    {
        public HttpStatusCode StatusCode { get; set; }

        public Error Error { get; set; }

        public bool HasErrors()
        {
            return this.Error != null;
        }

        public bool HasServerError()
        {
            return (StatusCode == HttpStatusCode.InternalServerError ||
                    StatusCode == HttpStatusCode.ServiceUnavailable ||
                    StatusCode == HttpStatusCode.BadRequest ||
                    StatusCode == HttpStatusCode.Unauthorized ||
                    StatusCode == HttpStatusCode.Forbidden ||
                    StatusCode == HttpStatusCode.GatewayTimeout ||
                    (Error != null && Error.httpStatusCode == 0));
        }
    }
}
