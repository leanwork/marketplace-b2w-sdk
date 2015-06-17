using System;
using System.Collections.Generic;

namespace Marketplace.B2W.SDK.Models
{
    [Serializable]
    public class Sku
    {
        /// <summary>
        /// (string): (size:18) Id do SKU que é fornecido pelo parceiro
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// (string): (size:100) Nome/Descrição do SKU a ser importado
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// (string, optional): (size:4000) Descrição detalhada do SKU
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// (size:13) Lista de EANs do SKU. Pode possuir de 1 a N elementos
        /// </summary>
        public List<string> ean { get; set; }

        /// <summary>
        /// (number, optional): (size:15.4) Altura do SKU (metros)
        /// </summary>
        public decimal height { get; set; }

        /// <summary>
        /// (number, optional): (size:15.4) Largura do SKU (metros)
        /// </summary>
        public decimal width { get; set; }

        /// <summary>
        /// (number, optional): (size:15.4) Comprimento do SKU (metros)
        /// </summary>
        public decimal length { get; set; }

        /// <summary>
        /// (number): (size:15.3) Peso do SKU (kg)
        /// </summary>
        public decimal weight { get; set; }

        /// <summary>
        /// (integer): Quantidade em estoque do SKU
        /// </summary>
        public decimal stockQuantity { get; set; }

        /// <summary>
        /// (boolean): Indica se o SKU está ativo ou não
        /// </summary>
        public bool enable { get; set; }

        /// <summary>
        /// Informações sobre preço
        /// </summary>
        public Price price { get; set; }

        /// <summary>
        /// (array[string], optional): (size:125) Lista de URLs onde podem ser encontradas as imagens do produto. Até 4 imagens.
        /// </summary>
        public List<string> urlImage
        {
            get { return _urlImage ?? (_urlImage = new List<string>()); }
            set { _urlImage = value; }
        }
        List<string> _urlImage;

        /// <summary>
        /// (optional): Posição da estrutura mercadologica selecionada para o SKU.
        /// </summary>
        public MarketStructure marketStructure { get; set; }

        /// <summary>
        /// (optional): Atributos do SKU conforme Estrutura Mercadológica selecionada.
        /// </summary>
        public List<AttributeValue> attributeValues
        {
            get { return _attributeValues ?? (_attributeValues = new List<AttributeValue>()); }
            set { _attributeValues = value; }
        }
        List<AttributeValue> _attributeValues;

        /// <summary>
        /// (string): (size:150) Nome da grade do SKU
        /// </summary>
        public string variance { get; set; }

        /// <summary>
        /// (integer): (size:3) Prazo cross-docking do produto (em dias)
        /// </summary>
        public int crossDocking { get; set; }
    }
}
