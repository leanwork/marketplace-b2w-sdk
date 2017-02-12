using Marketplace.B2W.SDK.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.B2W.SDK.Services
{
    public class Skus : APIServiceBase, ISkus
    {
        #region Ctor

        public Skus()
            : base()
        {
        }

        public Skus(string apiKey, bool sandbox = false)
            : base(apiKey, sandbox)
        {
        }

        #endregion

        public SkusResult Get(int offset = 1, int limit = 50)
        {
            offset = (offset <= 0) ? 1 : offset;
            limit = (limit <= 0) ? 50 : limit;

            SkusResult apiResult = new SkusResult();

            try
            {
                var resource = "/sku";
                using (var webResponse = CreateWebRequest().GET(resource))
                {
                    if (webResponse.StatusCode != HttpStatusCode.OK)
                    {
                        apiResult.Error = GetError(webResponse);
                    }
                    else
                    {
                        // OK - Requisição efetuada com sucesso
                        using (var stream = new StreamReader(webResponse.GetResponseStream()))
                        {
                            apiResult = JsonConvert.DeserializeObject<SkusResult>(stream.ReadToEnd());
                        }
                    }

                    apiResult.StatusCode = webResponse.StatusCode;
                }
            }
            catch (Exception ex)
            {
                apiResult = ThreatException(ex, apiResult);
            }

            return apiResult;
        }
    }
}
