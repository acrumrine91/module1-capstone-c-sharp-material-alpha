using System;
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
        //private string filePath = @"C:\Catering"; // You will likely need to create this folder on your machine

        private List<CateringItem> items = new List<CateringItem>();

        public List<CateringItem> AllCateringItems
        {
            get
            {
                return this.items;
            }
        }

        public void Add(CateringItem cateringItem)
        {
            this.items.Add(cateringItem);
        }

    }
}
