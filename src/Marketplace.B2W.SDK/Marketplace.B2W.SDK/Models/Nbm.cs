using System;

namespace Marketplace.B2W.SDK.Models
{
    [Serializable]
    public struct Nbm
    {
        /// <summary>
        /// Procedência: [0] Nacional, [1] Importação Direta ou [2] Estrangeira - Adquirido Mercado Int.
        /// </summary>
        public int origin { get; set; }

        /// <summary>
        /// Número referente ao NBM (Nomenclatura Brasileira de Mercadoria)
        /// </summary>
        public int number { get; set; }
    }
}
