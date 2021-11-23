using System;

namespace CianParser.QueryBuilder.Exceptions
{
    public class UriEmptyException : Exception
    {
        public UriEmptyException() : base()
        {
        }
        
        public UriEmptyException(string message) : base(message)
        {
        }
    }
}