using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Marketplace.B2W.SDK
{
    /// <summary>
    /// Object extensions
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Convert any object to byte array
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Byte array</returns>
        public static byte[] ConvertToByte(this object obj)
        {
            if (obj == null)
            {   
                return new byte[0];
            }

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }
        
        /// <summary>
        /// Convert any object to json
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>JSON</returns>
        public static string ToJSON(this object obj)
        {
            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss";
            return JsonConvert.SerializeObject(obj, jsonSerializerSettings);
        }
    }
}