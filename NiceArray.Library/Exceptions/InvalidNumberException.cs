using System;
using System.Collections.Generic;
using System.Text;

namespace NiceArray_Library.Exceptions
{
    public class InvalidNumberException : Exception
    {
        static string message = "can not be converted to numbers";

        public InvalidNumberException(IEnumerable<string> invalids) : base($" '{string.Join(", ", invalids)}' {message}")
        {
        }
    }
}
