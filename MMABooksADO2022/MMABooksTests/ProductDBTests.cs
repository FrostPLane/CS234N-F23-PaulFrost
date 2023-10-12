using MMABooksBusinessClasses;
using MMABooksDBClasses;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksTests
{
    public class ProductDBTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void TestGetProduct()
        {
            Product p = ProductDB.GetProduct(1);
            Assert.AreEqual(1, p.ProductCode);
        }

        [Test]
        public void TestCreateCustomer()
        {
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";

            int customerID = CustomerDB.AddCustomer(c);
            c = CustomerDB.GetCustomer(customerID);
            Assert.AreEqual("Mickey Mouse", c.Name);
        }
    }
}
