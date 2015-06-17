using System;

namespace Marketplace.B2W.SDK.Models
{
    [Serializable]
    public class Manufacturer
    {
        /// <summary>
        ///  Tempo da garantia (em meses) do produto no fabricante
        /// </summary>
        public int warrantyTime { get; set; }

        /// <summary>
        /// Modelo do produto de acordo com o fabricante
        /// </summary>
        public string model { get; set; }

        /// <summary>
        /// Nome do fabricante
        /// </summary>
        public string name { get; set; }
    }
}
