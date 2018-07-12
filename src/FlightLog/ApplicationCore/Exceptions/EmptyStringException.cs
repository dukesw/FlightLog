using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.Exceptions
{
    public class EmptyStringException : Exception
    {
        public EmptyStringException(string stringName) : base(string.Format("String named {0} is empty", stringName))
        {
        }
    }
}
