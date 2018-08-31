using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        // 3 methods to initialize an object: 

        [TestMethod()]
        public void SayHelloTest_SettingProperties1()
        {
            // Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";
            currentProduct.ProductID = 1;
            currentProduct.ProductDescription = "15-inch black steel blade";
            currentProduct.ProductVendor.CompanyName = "ABC Corp";

            var expected = "Hello, your Saw with Product number: '1' is a 15-inch black steel blade"
                + " available on: ";

            // Act
            var actual = currentProduct.SayHello();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHelloTest_ParameterizedConstructor2()
        {
            // Arrange
            var oefenProduct = new Product(32, "Pukje", "Grooot");
            var expected = "Hello, your Pukje with Product number: '32' is a Grooot" + " available on: ";

            // Act
            var actual = oefenProduct.SayHello();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHelloTest_ObjectInitializer3()
        {
            // Arrange
            var currentProduct = new Product
            {
                ProductID = 3,
                ProductName = "boot",
                ProductDescription = "Zeiljacht"
            };

            var expected = "Hello, your boot with Product number: '3' is a Zeiljacht" + " available on: ";

            // Act
            var actual = currentProduct.SayHello();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Product_NullTest()
        {
            // Arrange
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;

            string expected = null;

            // Act
            var actual = companyName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertMetersToInchesTest()
        {
            // Arrange
            var expected = 78.74;

            // Act
            var actual = 2 * Product.InchesPerMeter;

            // Assert


            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinimumPriceTest_Default()
        {
            // Arrange
            var currentProduct = new Product();
            var expected = .96m;

            // Act
            var actual = currentProduct.MinimumPrice;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinimumPriceTest_Bulk()
        {
            // Arrange
            var currentProduct = new Product(1, "Bulk Tools","");
            var expected = 9.99m;

            // Act
            var actual = currentProduct.MinimumPrice;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ProductName_Format()
        {
            // Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "   Steel Hammer   ";
            var expected = "Steel Hammer";

            // Act
            var actual = currentProduct.ProductName;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}