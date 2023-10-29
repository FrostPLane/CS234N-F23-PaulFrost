using MMABooksDB;
using MMABooksProps;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCommand = MySql.Data.MySqlClient.MySqlCommand;


namespace MMABooksTests
{
    public class ProductDBTests
    {
        ProductDB db;

        [SetUp]
        public void ResetData()
        {
            db = new ProductDB();
            DBCommand command = new DBCommand();
            command.CommandText = "usp_testingResetData";
            command.CommandType = CommandType.StoredProcedure;
            db.RunNonQueryProcedure(command);
        }

        [Test]
        public void TestRetrieve()
        {
            ProductProps p = (ProductProps)db.Retrieve(1753);
            Assert.AreEqual(1753, p.ProductCode);
            Assert.AreEqual("Murach's Java Programming", p.Description);
        }

        [Test]
        public void TestRetrieveAll()
        {
            List<ProductProps> list = (List<ProductProps>)db.RetrieveAll();
            Assert.AreEqual(16, list.Count);
        }

        [Test]
        public void TestDelete()
        {
            ProductProps p = (ProductProps)db.Retrieve(1756);
            Assert.True(db.Delete(p));
            Assert.Throws<Exception>(() => db.Retrieve(1756));
        }


        [Test]
        public void TestDeleteForeignKeyConstraint()
        {
            ProductProps p = (ProductProps)db.Retrieve(1753);
            Assert.Throws<MySqlException>(() => db.Delete(p));
        }

        [Test]
        public void TestUpdate()
        {
            ProductProps p = (ProductProps)db.Retrieve(1757);
            p.Description = "Murach's JavaScript and DOM Scripting";
            Assert.True(db.Update(p));
            p = (ProductProps)db.Retrieve("1757");
            Assert.AreEqual("Murach's JavaScript and DOM Scripting", p.Description);
        }

        [Test]
        public void TestUpdateFieldTooLong()
        {
            ProductProps p = (ProductProps)db.Retrieve(1757);
            p.Description = "Murach's JavaScript and DOM ScriptingMurach's JavaScript and DOM ScriptingMurach's JavaScript and DOM ScriptingMurach's JavaScript and DOM ScriptingMurach's JavaScript and DOM Scripting";
            Assert.Throws<MySqlException>(() => db.Update(p));
        }

        [Test]
        public void TestCreate()
        {
            ProductProps p = new ProductProps();
            p.ProductCode = "??";
            p.Description = "Where am I";
            db.Create(p);
            ProductProps p2 = (ProductProps)db.Retrieve(p.ProductCode);
            Assert.AreEqual(p.GetState(), p2.GetState());
        }

        [Test]
        public void TestCreatePrimaryKeyViolation()
        {
            ProductProps p = new ProductProps();
            p.ProductCode = "A5B5";
            p.Description = "Test Description";
            Assert.Throws<MySqlException>(() => db.Create(p));
        }
    }
}
