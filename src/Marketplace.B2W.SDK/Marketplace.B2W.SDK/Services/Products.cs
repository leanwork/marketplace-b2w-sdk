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
    public class Products : APIServiceBase, IProducts
    {
        #region Ctor

        public Products()
            : base()
        {
        }

        public Products(string apiKey, bool sandbox = false)
            : base(apiKey, sandbox)
        {
        }

        #endregion

        public ProductsResult Get(int offset = 1, int limit = 50)
        {
            offset = (offset <= 0) ? 1 : offset;
            limit = (limit <= 0) ? 50 : limit;

            ProductsResult apiResult = new ProductsResult();

            try
            {
                var resource = "/product";
                using (var webResponse = CreateWebRequest().GET(resource))
                {
                    apiResult.StatusCode = webResponse.StatusCode;
                    
                    if (webResponse.StatusCode != HttpStatusCode.OK)
                    {
                        apiResult.Error = GetError(webResponse);
                    }
                    else
                    {
                        // OK - Requisição efetuada com sucesso
                        using (var stream = new StreamReader(webResponse.GetResponseStream()))
                        {
                            apiResult = JsonConvert.DeserializeObject<ProductsResult>(stream.ReadToEnd());
                        }
                    }
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
