using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RestaurantAPI;

namespace RestaurantAPITests
{
    [TestClass]
    public class UnitTestOrder
    {
        [TestMethod]
        public void TestGetOrderMethod1()
        {
            string input = "morning,1,2,3";
            string expectedOutput = "eggs,toast,coffee";
            string output = new OrderService().GetOrder(input);
            Assert.AreEqual(output, expectedOutput);
        }

        [TestMethod]
        public void TestGetOrderMethod2()
        {
            string input = "morning,2,1,3";
            string expectedOutput = "eggs,toast,coffee";
            string output = new OrderService().GetOrder(input);
            Assert.AreEqual(output, expectedOutput);
        }

        [TestMethod]
        public void TestGetOrderMethod3()
        {
            string input = "morning,1,2,3,4";
            string expectedOutput = "eggs,toast,coffee,error";
            string output = new OrderService().GetOrder(input);
            Assert.AreEqual(output, expectedOutput);
        }

        [TestMethod]
        public void TestGetOrderMethod4()
        {
            string input = "morning,1,2,3,3,3";
            string expectedOutput = "eggs,toast,coffee,coffee,coffee";
            string output = new OrderService().GetOrder(input);
            Assert.AreEqual(output, expectedOutput);
        }

        [TestMethod]
        public void TestGetOrderMethod5()
        {
            string input = "night,1,2,3,4";
            string expectedOutput = "steak,potato,wine,cake";
            string output = new OrderService().GetOrder(input);
            Assert.AreEqual(output, expectedOutput);
        }

        [TestMethod]
        public void TestGetOrderMethod6()
        {
            string input = "night,1,2,2,4";
            string expectedOutput = "steak,potato,potato,cake";
            string output = new OrderService().GetOrder(input);
            Assert.AreEqual(output, expectedOutput);
        }

        [TestMethod]
        public void TestGetOrderMethod7()
        {
            string input = "night,1,2,3,5";
            string expectedOutput = "steak,potato,wine,error";
            string output = new OrderService().GetOrder(input);
            Assert.AreEqual(output, expectedOutput);
        }       

    }
}
