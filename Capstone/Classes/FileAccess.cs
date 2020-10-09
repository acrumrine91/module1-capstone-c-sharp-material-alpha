using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlTypes;

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

                    switch (productType)
                    {
                        case "B":
                            productType = "Beverage";
                            break;
                        case "E":
                            productType = "Entree";
                            break;
                        case "D":
                            productType = "Dessert";
                            break;
                        case "A":
                            productType = "Appetizer";
                            break;
                    }


                    // Create new instance of CateringItem.
                    CateringItem cateringItem = new CateringItem(productCode, product, price, productType);

                    // Add cateringItem to list within catering.
                    catering.Add(cateringItem);
                }
            }
        }

        public void AccountPurchasesLog(Accounting accounting, string inputType, int moneyAdded)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(filePath, "Log.txt"), true))
            {
                switch (inputType)
                {
                    case "Added":
                        writer.WriteLine($"{DateTime.Now}  ADD MONEY: {moneyAdded.ToString("C")} {accounting.DisplayMoney().ToString("C")}");
                        break;
                    case "Change":
                        writer.WriteLine($"{DateTime.Now}  GIVE CHANGE: {accounting.DisplayMoney().ToString("C")} $0.00");
                        break;
                }
            }
        }

        public void PurchasesLog(CateringItem cateringItem, Accounting accounting, int purchasedQuantity)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(filePath, "Log.txt"), true))
            {
                writer.WriteLine($"{DateTime.Now} {purchasedQuantity} {cateringItem.Product} {cateringItem.ProductCode} {cateringItem.Price * purchasedQuantity} {accounting.DisplayMoney()}");
            }
        }
    }
}

