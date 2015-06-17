using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marketplace.B2W.SDK.Models
{
    [Serializable]
    public class AttributeValue
    {
        /// <summary>
        /// string): (size:100) Nome do atributo conforme informado no recurso "attribute"
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// (Object): (size:100) Valor do atributo.
        /// </summary>
        public string value { get; set; }
    }
}
