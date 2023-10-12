using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksBusinessClasses
{
    public class State
    {
        public State() { }

        public State(string code, string name)
        {
            StateCode = code;
            StateName = name;
        }

        private string stateName;
        public string StateName {
            get
            {
                return stateName;
            }
            set
            {
                if (value is string)
                    stateName = value;
                else
                    throw new ArgumentException("The state name must be a string.");
            }
        }

        private string stateCode;
        public string StateCode { 
            get
            {
                return stateCode;
            }
            set
            {
                if (value.Length <= 2)
                    stateCode = value.ToUpper();
                else
                    throw new ArgumentOutOfRangeException("The state code must be exactly 2 characters.");
            }
        }

        public override string ToString()
        {
            return StateCode + ", " + StateName;
        }
    }
}
