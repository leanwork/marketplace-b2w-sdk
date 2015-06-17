using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.B2W.SDK.Models
{
    public class SkusResult : APIResult
    {
        /// <summary>
        /// (array[SkuResponse]): Array de skus associados ao parceiro informado
        /// </summary>
        public IEnumerable<Sku> sku
        {
            get { return _skus ?? (_skus = new List<Sku>()); }
            set { _skus = value; }
        }
        IEnumerable<Sku> _skus;

        /// <summary>
        /// (integer): Total de registros em banco associados ao parceiro
        /// </summary>
        public int total { get; set; }
    }
}
