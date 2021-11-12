using System;

namespace LW5
{
    public class Exceptions
    {
        public class NumberException : Exception
        {
            public NumberException(string message) : base(message) {}
        }

        public class StringException : Exception
        {
            public StringException(string message) : base(message) {}
        }

        public class NoVirus : StringException
        {
            public NoVirus(string message) : base(message) {}
        }
        public class IsZero : NumberException
        {
            public IsZero(string message) : base(message) {}
        }
    }
}