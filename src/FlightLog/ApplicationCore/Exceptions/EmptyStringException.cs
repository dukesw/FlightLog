using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.Exceptions
{
    public class EmptyStringException : Exception
    {
        public EmptyStringException(string variableName) : base($"String variable {variableName} is empty")
        {
        }
    }
}
