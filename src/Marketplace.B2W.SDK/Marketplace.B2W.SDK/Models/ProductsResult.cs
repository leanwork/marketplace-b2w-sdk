using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.B2W.SDK.Models
{
    public class ProductsResult : APIResult
    {
        /// <summary>
        ///  (array[ProductResponse]): Array de Produtos associados ao parceiro informado
        /// </summary>
        public IEnumerable<Product> products
        {
            get { return _products ?? (_products = new List<Product>()); }
            set { _products = value; }
        }
        IEnumerable<Product> _products;

        /// <summary>
        /// (integer): Total de registros em banco associados ao parceiro
        /// </summary>
        public int total { get; set; }
    }
}
