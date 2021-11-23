using System;

namespace CianParser.Parser.Exceptions
{
    public class UriNotDefinedException : Exception
    {
        public UriNotDefinedException(string message) : base(message)
        {
        }
    }
}