using System;
using System.Collections.Generic;
using System.Linq;

namespace Marketplace.B2W.SDK.Models
{
    [Serializable]
    public class Product
    {
        /// <summary>
        /// Identificador do produto para o parceiro.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Nome do produto.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Tipo de entrega do produto. Este campo recebe os seguintes valores: SHIPMENT, WITHDRAW e ALL.
        /// </summary>
        /// <example>
        ///     SHIPMENT - entrega do produto pelo revendedor;
        ///     WITHDRAW - retirada local do produto em lugar estabelecido pelo revendedor;
        ///     ALL - efetua as duas modalidades.
        /// </example>
        public string deliveryType { get; set; }

        /// <summary>
        /// Informações do fabricante.
        /// </summary>
        public Manufacturer manufacturer { get; set; }

        /// <summary>
        /// Nomenclatura Brasileira de Mercadoria.
        /// </summary>
        public Nbm nbm { get; set; }

        /// <summary>
        /// Lista de links para as informações de SKU
        /// </summary>
        public IList<Link> sku
        {
            get { return _skus ?? (_skus = new List<Link>()); }
            set { _skus = value; }
        }
        IList<Link> _skus;

        public bool ContainsSku(string sku)
        {
            return this.sku.Any(x => x.id == sku);
        }
    }
}
