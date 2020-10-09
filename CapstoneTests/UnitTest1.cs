using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace CapstoneTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PurchaseItemsShouldReduceAccountBalanceAndStockOfSelectedItem()
        {
            //Arrange
            CateringItem cateringItem = new CateringItem();
            //cateringItem.QuantityInStock = int currentStock;
            //Act

            //Assert

        }

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
