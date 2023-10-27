using MMABooksDB;
using MMABooksProps;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DBCommand = MySql.Data.MySqlClient.MySqlCommand;
using MMABooksBusiness;

namespace MMABooksTests
{
    internal class CustomerDBTests
    {
        CustomerDB db;

        [SetUp]
        public void ResetData()
        {
            db = new CustomerDB();
            DBCommand command = new DBCommand();
            command.CommandText = "usp_testingResetData";
            command.CommandType = CommandType.StoredProcedure;
            db.RunNonQueryProcedure(command);
        }

        [Test]
        public void TestRetrieve()
        {
            CustomerProps c = (CustomerProps)db.Retrieve(999);
            Assert.AreEqual(999, c.CustomerID);
            Assert.AreEqual("Ore", c.Name);
        }

        [Test]
        public void TestRetrieveAll()
        {
            List<CustomerProps> list = (List<CustomerProps>)db.RetrieveAll();
            Assert.AreEqual(53, list.Count);
        }
        [Test]
        public void TestDelete()
        {
            Customer c = new Customer("10");
            c.Delete();
            c.Save();
            Assert.Throws<Exception>(() => new Customer("10"));
        }


        [Test]
        public void TestDeleteForeignKeyConstraint()
        {
            CustomerProps c = (CustomerProps)db.Retrieve("OR");
            Assert.Throws<MySqlException>(() => db.Delete(c));
        }

        [Test]
        public void TestUpdate()
        {
            CustomerProps c = (CustomerProps)db.Retrieve("OR");
            c.Name = "Oregon";
            Assert.True(db.Update(c));
            c = (CustomerProps)db.Retrieve("OR");
            Assert.AreEqual("Oregon", c.Name);
        }

        [Test]
        public void TestUpdateFieldTooLong()
        {
            CustomerProps c = (CustomerProps)db.Retrieve("OR");
            c.Name = "Oregon is the state where Crater Lake National Park is.";
            Assert.Throws<MySqlException>(() => db.Update(c));
        }

        [Test]
        public void TestCreate()
        {
            CustomerProps c = new CustomerProps();
            c.Name = "testName";
            db.Create(c);
            CustomerProps c2 = (CustomerProps)db.Retrieve(c.CustomerID);
            Assert.AreEqual(c.GetState(), c2.GetState());
        }

        [Test]
        public void TestCreatePrimaryKeyViolation()
        {
            CustomerProps c = new CustomerProps();
            c.CustomerID = 999;
            c.Name = "testName";
            Assert.Throws<MySqlException>(() => db.Create(c));
        }
    }
}
