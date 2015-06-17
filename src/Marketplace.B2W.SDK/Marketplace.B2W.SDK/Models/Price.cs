using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marketplace.B2W.SDK.Models
{
    [Serializable]
    public class Price
    {
        /// <summary>
        /// (number): (size:15.2) "Preço por" do SKU
        /// </summary>
        public double sellPrice { get; set; }

        /// <summary>
        /// (number): (size:15.2) "Preço de" do SKU
        /// </summary>
        public double listPrice { get; set; }

        public Price()
        {
        }

        public Price(double sellPrice, double listPrice)
        {
            this.sellPrice = sellPrice;
            this.listPrice = listPrice;
        }
    }
}
