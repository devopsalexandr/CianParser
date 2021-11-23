using System;

namespace CianParser.Parser.Exceptions
{
    public class JsNotFoundException : Exception
    {
        public JsNotFoundException(string message) : base(message)
        {
        }
    }
}