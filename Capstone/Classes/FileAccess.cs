using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain any and all details of access to files
    /// </summary>
    /// 


    public class FileAccess
    {
        private string filePath = @"C:\Catering"; // You will likely need to create this folder on your machine

        // Read from the Catering System file.
        public void ReadingCateringInventory(Catering catering)
        {
            using (StreamReader reader = new StreamReader(Path.Combine(filePath, "cateringsystem.csv")))
            {
                while (!reader.EndOfStream)
                {
                    // Reads line from file.
                    string line = reader.ReadLine();

                    // Split line into an array via the pipe symbol.
                    string[] parts = line.Split("|");

                    // Declare parts.
                    string productCode = parts[0];
                    string product = parts[1];
                    decimal price = decimal.Parse(parts[2]);
                    string productType = parts[3];


                    // Create new instance of CateringItem.
                    CateringItem cateringItem = new CateringItem(productCode, product, price, productType);

                    // Add cateringItem to list within catering.
                    catering.Add(cateringItem);
                }
            }
        }
    }
}
