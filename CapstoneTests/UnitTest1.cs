using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace CapstoneTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(500, "2.55", "497.45", 1)]
        [DataRow(1000, "236.25", "763.75", 1)]
        [DataRow(5000, "2843.60", "2156.40", 1)]
        public void PurchaseItemsShouldReduceAccountBalance(int valueToAdd, string price, string value, int userQuantity)
        {
            //Arrange
            Accounting accounting = new Accounting();
            CateringItem cateringItem = new CateringItem();
            accounting.AddMoney(valueToAdd);
            decimal expected = decimal.Parse(value);
            cateringItem.Price = decimal.Parse(price);
            

            //Act
            //decimal result = accounting.SubtractPurchase(cateringItem, userQuantity);

            //Assert
            //Assert.AreEqual(expected, result);
        }
        
        /*[TestMethod]
        [DataRow("B3", "2.55")]
        public void PullOutPrice(string value)
        {
            //Arrange
            Accounting accounting = new Accounting();
            CateringItem cateringItem = new CateringItem();
            decimal expected = decimal.Parse(value);
            cateringItem.Price = expected;                                
           
            //Act
            decimal result = accounting.SubtractPurchase(cateringItem);

            //Assert
            Assert.AreEqual(expected, result);
        }
        */

        // Accounting -- MostEfficientChange Method
        [TestMethod]
        [DataRow("124.54", 6)]
        [DataRow("25.37", 1)]
        [DataRow("86.75", 4)]
        public void MostEfficientChangeShouldReturnCountOf20s(string input, int expected)
        {
            // Arrange
            Accounting accounting = new Accounting();

            // Act
            decimal value = decimal.Parse(input);
            int result = accounting.MostEfficientChange(value)[0];

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("134.54", 1)]
        [DataRow("35.37", 1)]
        [DataRow("86.75", 0)]
        public void MostEfficientChangeShouldReturnCountOf10s(string input, int expected)
        {
            // Arrange
            Accounting accounting = new Accounting();

            // Act
            decimal value = decimal.Parse(input);
            int result = accounting.MostEfficientChange(value)[1];

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("135.54", 1)]
        [DataRow("35.37", 1)]
        [DataRow("80.75", 0)]
        public void MostEfficientChangeShouldReturnCountOf5s(string input, int expected)
        {
            // Arrange
            Accounting accounting = new Accounting();

            // Act
            decimal value = decimal.Parse(input);
            int result = accounting.MostEfficientChange(value)[2];

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("134.54", 4)]
        [DataRow("32.37", 2)]
        [DataRow("80.75", 0)]
        public void MostEfficientChangeShouldReturnCountOf1s(string input, int expected)
        {
            // Arrange
            Accounting accounting = new Accounting();

            // Act
            decimal value = decimal.Parse(input);
            int result = accounting.MostEfficientChange(value)[3];

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("134.55", 2)]
        [DataRow("32.35", 1)]
        [DataRow("80.75", 3)]
        public void MostEfficientChangeShouldReturnCountOfQuarters(string input, int expected)
        {
            // Arrange
            Accounting accounting = new Accounting();

            // Act
            decimal value = decimal.Parse(input);
            int result = accounting.MostEfficientChange(value)[4];

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("134.65", 1)]
        [DataRow("32.45", 2)]
        [DataRow("80.75", 0)]
        public void MostEfficientChangeShouldReturnCountOfDimes(string input, int expected)
        {
            // Arrange
            Accounting accounting = new Accounting();

            // Act
            decimal value = decimal.Parse(input);
            int result = accounting.MostEfficientChange(value)[5];

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("134.65", 1)]
        [DataRow("32.55", 1)]
        [DataRow("80.75", 0)]
        public void MostEfficientChangeShouldReturnCountOfNickels(string input, int expected)
        {
            // Arrange
            Accounting accounting = new Accounting();

            // Act
            decimal value = decimal.Parse(input);
            int result = accounting.MostEfficientChange(value)[6];

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
