using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace MMABooksBusinessClasses
{
    public class Product
    {
        public Product() { }

        public Product(string productcode, string description, decimal unitprice, int onhandquantity)
        {
            ProductCode = productcode;
            Description = description;
            UnitPrice = unitprice;
            OnHandQuantity = onhandquantity;
        }

        private string productCode;
        public string ProductCode {
            get
            {
                return productCode;
            }
            set
            {
                if (value.Length <= 2)
                    productCode = value.ToUpper();
                else
                    throw new ArgumentOutOfRangeException("The product code must be exactly 4 characters.");
            }
        }

        private string description;
        public string Description {
            get
            {
                return description;
            }
            set
            {
                if (value is string)
                    description = value;
                else
                    throw new ArgumentException("The description must be a string.");
            }
        }

        private decimal unitPrice;
        public decimal UnitPrice
        {
            get
            {
                return unitPrice;
            }
            set
            {
                Match decimalTest = Regex.Match(value.ToString(), @"\d{10}.\d{4}$");
                if (decimalTest.Success)
                    unitPrice = value;
                else
                    throw new ArgumentException("The unit price must be a decimal.");
            }
        }

        private int onhandquantity;
        public int OnHandQuantity {
            get
            {
                return onhandquantity;
            }
            set
            {
                if (value is int)
                    onhandquantity = value;
                else
                    throw new ArgumentException("The on hand quantity must be an int.");
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
