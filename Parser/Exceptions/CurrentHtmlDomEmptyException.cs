using System;

namespace CianParser.Parser.Exceptions
{
    public class CurrentHtmlDomEmptyException : Exception
    {
        public CurrentHtmlDomEmptyException(string message) : base(message)
        {
        }
    }
}