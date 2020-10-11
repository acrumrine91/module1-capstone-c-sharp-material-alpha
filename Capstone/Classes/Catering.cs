using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain all the "work" for a catering system
    /// </summary>
    public class Catering
    {
        // List used in AllCateringItems. This is the list that is updated.
        private List<CateringItem> items = new List<CateringItem>();

        // List used in AllPurchasedItems. This is the list that is used to print purchase reports.
        private List<CateringItem> purchasedItems = new List<CateringItem>();

        /// <summary>
        /// Returns the list items which was populated by the .csv in FileAccess.
        /// </summary>
        public List<CateringItem> AllCateringItems
        {
            get
            {
                return this.items;
            }
        }

        /// <summary>
        /// Returns the list purchasedItems which was populated via purchases.
        /// </summary>
        public List<CateringItem> AllPurchasedItems
        {
            get
            {
                return this.purchasedItems;
            }
        }

        /// <summary>
        /// The only way to add to the list, since it is private, is to create a method that does so within the same class. This adds items to the items list.
        /// </summary>
        /// <param name="cateringItem"></param>
        public void Add(CateringItem cateringItem)
        {
            this.items.Add(cateringItem);
        }

        /// <summary>
        /// As above, but for purchased items.
        /// </summary>
        /// <param name="cateringItem"></param>
        public void PurchasedAdd(CateringItem cateringItem)
        {
            this.purchasedItems.Add(cateringItem);
        }

        /// <summary>
        /// This is a search function to see if a productCode is within the list AllCateringItems. If not, return null.
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public CateringItem SearchProductCode(string productCode)
        {
            foreach (CateringItem cateringItem in this.AllCateringItems)
            {
                if (cateringItem.ProductCode == productCode)
                {
                    return cateringItem;
                }
            }
            return null;
        }

        /// <summary>
        /// Checks if a product is in stock. If the catering item is in AllCateringItems and has a stock greater than 0, returns the cateringItem, otherwise null.
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public CateringItem ProductIsInStock(string productCode)
        {
            CateringItem cateringItem = SearchProductCode(productCode);
            
            if (cateringItem != null && cateringItem.QuantityInStock > 0)
            {
                return cateringItem;
            }
            else
            {
                return null;
            }
        }
    }
}
