using System;

namespace Marketplace.B2W.SDK.Models
{
    [Serializable]
    public class Link
    {
        /// <summary>
        /// Identificador do recurso associado
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Recurso associado
        /// </summary>
        public string rel { get; set; }

        /// <summary>
        /// Link para acessar o recurso associado
        /// </summary>
        public string href { get; set; }

    }
}
