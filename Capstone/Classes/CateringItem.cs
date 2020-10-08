using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain the definition for one catering item
    /// </summary>
    public class CateringItem
    {
        public CateringItem(string productCode, string product, decimal price, string productType)
        {
            this.ProductCode = productCode;
            this.Product = product;
            this.Price = price;
            this.ProductType = productType;
        }
        public string ProductCode {get; set;}
        public string Product { get; set; }
        public decimal Price { get; set; }
        public string ProductType { get; set; }
        
    }
}
