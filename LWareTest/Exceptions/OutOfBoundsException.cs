using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LWareTest.Exceptions
{
    [Serializable()]
    public class OutOfBoundsException : System.Exception
    {
        public OutOfBoundsException() : base() { }
        public OutOfBoundsException(string message) : base() { }
        public OutOfBoundsException(string message, System.Exception inner) : base() { }
    }
}