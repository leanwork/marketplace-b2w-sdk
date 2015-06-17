using Marketplace.B2W.SDK.Configuration;
using Marketplace.B2W.SDK.Utils;
using Marketplace.B2W.SDK.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Marketplace.B2W.SDK.Services
{
    /// <summary>
    /// API Service Base
    /// </summary>
    public abstract class APIServiceBase
    {
        string _apiKey;

        public bool Sandbox { get; set; }

        internal ISimpleRequest SimpleRequest
        {
            get { return _simpleRequest ?? new SimpleRequest(); }
            set { _simpleRequest = value; }
        }
        ISimpleRequest _simpleRequest;

        #region ctor

        public APIServiceBase()
        {
            this.Sandbox = APISettings.Sandbox;
            this._apiKey = APISettings.ApiKey;
        }

        public APIServiceBase(string apiKey, bool sandbox = false)
            : base()
        {
            if (String.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentNullException("apiKey");

            this.Sandbox = sandbox;
            this._apiKey = apiKey;
        }

        #endregion

        protected ISimpleRequest CreateWebRequest()
        {
            var request = this.SimpleRequest;
            request.SetHost(GetHost());
            request.AddHeader(Keys.AUTHORIZATION, GetBasicAuthentication());
            return request;
        }

        private string GetBasicAuthentication()
        {
            string hash = Convert.ToBase64String(Encoding.ASCII.GetBytes(String.Format("{0}:", this._apiKey)));
            return String.Format("Basic {0}", hash);
        }

        protected Error GetError(HttpWebResponse response)
        {
            string json = null;
            try
            {
                using (var stream = new StreamReader(response.GetResponseStream()))
                {
                    json = stream.ReadToEnd();
                    return JsonConvert.DeserializeObject<Error>(json);
                }
            }
            catch (Exception ex)
            {
                return new Error
                {
                    message = json ?? ex.GetBaseException().Message
                };
            }
        }

        protected Error GetError(Exception ex)
        {
            return new Error { message = ex.GetBaseException().Message };
        }

        protected T ThreatException<T>(Exception exception, T response) where T : APIResult
        {
            string message = null;

            if (response == null)
            {
                response = Activator.CreateInstance<T>();
            }

            response.StatusCode = HttpStatusCode.InternalServerError;

            try
            {
                var webEx = exception as WebException;
                if (webEx != null)
                {
                    var httpWebResponse = webEx.Response as HttpWebResponse;
                    if (httpWebResponse != null && httpWebResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        response.StatusCode = HttpStatusCode.NotFound;
                        return response;
                    }

                    using (var stream = new StreamReader(webEx.Response.GetResponseStream()))
                    {
                        message = stream.ReadToEnd();
                        response.Error = JsonConvert.DeserializeObject<Error>(message);
                    }

                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Error = new Error
                {
                    message = message ?? ex.GetBaseException().Message
                };
            }

            return response;
        }

        #region privates

        private string GetHost()
        {
            return this.Sandbox ? Hosts.SANDBOX : Hosts.PRODUCTION;
        }

        #endregion
    }
}
