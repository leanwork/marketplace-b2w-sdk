using System;
using System.Configuration;

namespace Marketplace.B2W.SDK.Configuration
{
    public static class APISettings
    {
        public static bool Sandbox
        {
            get 
            {
                var value = ConfigurationManager.AppSettings["Marketplace.B2W.Sandbox"];
                bool sandbox = false;
                if (!Boolean.TryParse(value, out sandbox))
                {
                    throw new ConfigurationErrorsException("A chave 'Marketplace.B2W.Sandbox' não está configurada no appSettings.");
                }
                return sandbox;
            }
        }

        public static string ApiKey
        {
            get
            {
                var value = ConfigurationManager.AppSettings["Marketplace.B2W.ApiKey"];
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ConfigurationErrorsException("A chave 'Marketplace.B2W.ApiKey' não está configurada no appSettings.");
                }
                return value;
            }
        }
    }
}
