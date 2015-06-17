using System;

namespace Marketplace.B2W.SDK.Models
{
    [Serializable]
    public class MarketStructure
    {
        /// <summary>
        /// (size:30) ID da Categoria selecionada para o SKU.
        /// </summary>
        public string categoryId { get; set; }

        /// <summary>
        /// (optional): (size:30) ID da Sub-categoria selecionada para o SKU.
        /// </summary>
        public string subCategoryId { get; set; }

        /// <summary>
        /// (optional): (size:30) ID da Familia selecionada para o SKU.
        /// </summary>
        public string familyId { get; set; }

        /// <summary>
        /// (optional): (size:30) ID da Sub-familia selecionada para o SKU.
        /// </summary>
        public string subFamilyId { get; set; }
    }
}
