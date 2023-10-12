using System;

namespace MMABooksBusinessClasses
{
    public class Customer
    {
        // there are several warnings in this file related to nullable properties and return values.
        // you can ignore them
        public Customer() { }

        public Customer(int id, string name, string address, string city, string state, string zipcode)
        {
            CustomerID = id;
            Name = name;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipcode;
        }

        private int customerID;
        public int CustomerID {
            get
            {
                return customerID;
            }
            set
            {
                if (value is int)
                    customerID = value;
                else
                    throw new ArgumentException("The customer id must be an int.");
            }
        }

        private string name;
        public string Name {
            get
            {
                return name;
            }
            set
            {
                if (value is string)
                    name = value;
                else
                    throw new ArgumentException("The customer name must be a string.");
            }
        }

        private string address;
        public string Address {
            get
            {
                return address;
            }
            set
            {
                if (value is string)
                    address = value;
                else
                    throw new ArgumentException("The customer address must be a string.");
            }
        }

        private string city;
        public string City {
            get
            {
                return address;
            }
            set
            {
                if (value is string)
                    address = value;
                else
                    throw new ArgumentException("The customer city must be a string.");
            }
        }

        private string state;
        public string State {
            get
            {
                return state;
            }
            set
            {
                if (value.Length <= 2)
                    state = value.ToUpper();
                else
                    throw new ArgumentOutOfRangeException("The state code must be exactly 2 characters.");
            }
        }

        private string zipCode;
        public string ZipCode
        {
            get
            {
                return zipCode;
            }
            set
            {
                if (value is string)
                    zipCode = value;
                else
                    throw new ArgumentException("The customer zipcode must be a string.");
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
