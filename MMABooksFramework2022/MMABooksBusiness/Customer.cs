using MMABooksTools;
using System;
using System.Collections.Generic;
using System.Text;

using MMABooksProps;
using MMABooksDB;

using System.Collections.Generic;

namespace MMABooksBusiness
{
    public class Customer : BaseBusiness
    {
        /// <summary>
        /// Read/Write property. 
        /// </summary>
        //  Notice that I used a name for the business object property that I thought would be more intuitive for the 
        //  application programmer.  It doesn't have to match the database.
        public int CustomerID
        {
            get
            {
                return ((CustomerProps)mProps).CustomerID;
            }
        }

        public String Name
        {
            get
            {
                return ((CustomerProps)mProps).Name;
            }

            set
            {
                if (!(value == ((CustomerProps)mProps).Name))
                {
                    if (value.Trim().Length >= 1 && value.Trim().Length <= 100)
                    {
                        mRules.RuleBroken("Name", false);
                        ((CustomerProps)mProps).Name = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("Name must be no more than 100 characters long.");
                    }
                }
            }
        }

        public String Address
        {
            get
            {
                return ((CustomerProps)mProps).Address;
            }

            set
            {
                if (!(value == ((CustomerProps)mProps).Address))
                {
                    if (value.Trim().Length >= 1 && value.Trim().Length <= 50)
                    {
                        mRules.RuleBroken("Address", false);
                        ((CustomerProps)mProps).Address = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("Address must be no more than 50 characters long.");
                    }
                }
            }
        }

        public String City
        {
            get
            {
                return ((CustomerProps)mProps).City;
            }

            set
            {
                if (!(value == ((CustomerProps)mProps).City))
                {
                    if (value.Trim().Length >= 1 && value.Trim().Length <= 20)
                    {
                        mRules.RuleBroken("City", false);
                        ((CustomerProps)mProps).City = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("City must be no more than 20 characters long.");
                    }
                }
            }
        }

        public String State
        {
            get
            {
                return ((CustomerProps)mProps).State;
            }

            set
            {
                if (!(value == ((CustomerProps)mProps).State))
                {
                    if (value.Trim().Length >= 1 && value.Trim().Length <= 12)
                    {
                        mRules.RuleBroken("State", false);
                        ((CustomerProps)mProps).State = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("State must be no more than 12 characters long.");
                    }
                }
            }
        }

        public int ZipCode
        {
            get
            {
                return ((CustomerProps)mProps).ZipCode;
            }

            set
            {
                if (!(value == ((CustomerProps)mProps).ZipCode))
                {
                    if (value.ToString().Length >= 1 && value.ToString().Length <= 10)
                    {
                        mRules.RuleBroken("ZipCode", false);
                        ((CustomerProps)mProps).ZipCode = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("ZipCode must be no more than 10 digits long.");
                    }
                }
            }
        }

        public override object GetList()
        {
            List<Customer> customers = new List<Customer>();
            List<CustomerProps> props = new List<CustomerProps>();


            props = (List<CustomerProps>)mdbReadable.RetrieveAll();
            foreach (CustomerProps prop in props)
            {
                Customer c = new Customer(prop);
                customers.Add(c);
            }

            return customers;
        }

        protected override void SetDefaultProperties()
        {
        }

        /// <summary>
        /// Sets required fields for a record.
        /// </summary>
        protected override void SetRequiredRules()
        {
            mRules.RuleBroken("CustomerID", true);
            mRules.RuleBroken("Name", true);
            mRules.RuleBroken("Address", true);
            mRules.RuleBroken("City", true);
            mRules.RuleBroken("State", true);
            mRules.RuleBroken("ZipCode", true);
        }

        /// <summary>
        /// Instantiates mProps and mOldProps as new Props objects.
        /// Instantiates mbdReadable and mdbWriteable as new DB objects.
        /// </summary>
        protected override void SetUp()
        {
            mProps = new CustomerProps();
            mOldProps = new CustomerProps();

            mdbReadable = new CustomerDB();
            mdbWriteable = new CustomerDB();
        }
        /// <summary>
        /// Default constructor - gets the connection string - assumes a new record that is not in the database.
        /// </summary>
        public Customer() : base()
        {
        }

/*        /// <summary>
        /// Calls methods SetUp() and Load().
        /// Use this constructor when the object is in the database AND the connection string is in a config file
        /// </summary>
        /// <param name="key">ID number of a record in the database.
        /// Sent as an arg to Load() to set values of record to properties of an 
        /// object.</param>*/
        public Customer(string key)
            : base(key)
        {
        }

        private Customer(CustomerProps props)
            : base(props)
        {
        }

    }
}
