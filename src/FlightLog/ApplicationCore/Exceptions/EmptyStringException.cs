using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.Exceptions
{
    public class EmptyStringException : Exception
    {
        public EmptyStringException(string stringName) : base($"String named {stringName} is empty")
        {
        }
    }
}
