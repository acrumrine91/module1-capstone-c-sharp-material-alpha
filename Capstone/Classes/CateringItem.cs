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
        public CateringItem()
        {

        }
        public CateringItem(string productCode)
        {
            this.ProductCode = productCode;
        }
        public CateringItem(string productCode, string product, decimal price, string productType)
        {
            this.ProductCode = productCode;
            this.Product = product;
            this.Price = price;
            this.ProductType = productType;
        }
        public CateringItem(string productCode, string product, decimal price, string productType, int quantityInStock)
        {
            this.ProductCode = productCode;
            this.Product = product;
            this.Price = price;
            this.ProductType = productType;
            this.QuantityInStock = quantityInStock;
        }
        
        public string ProductCode {get; set;}
        public string Product { get; set; }
        public decimal Price { get; set; }
        public string ProductType { get; set; }
        public int QuantityInStock { get; set; } = 50;
        public int PurchasedQuantity
        {
            get
            {
                return 50 - QuantityInStock;
            }
        }

        /// <summary>
        /// String override to print out the correct format.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this.QuantityInStock == 0) // If Quantity of Product == 0, replace Quantity with "SOLD OUT".
            {
                return $"SOLD OUT    {this.ProductType}    {this.ProductCode}--{this.Product}    {this.Price}";
            }
            
            return $"{this.QuantityInStock}    {this.ProductType}    {this.ProductCode}--{this.Product}    {this.Price}";
        }

        /// <summary>
        /// Format for Display Purchase Report
        /// </summary>
        /// <returns></returns>
        public string PurchasedFormat()
        {
            return $"{this.PurchasedQuantity}   {this.ProductType}   {this.Product}   ${this.Price}   ${this.Price * this.PurchasedQuantity}";
        }
    }
}
