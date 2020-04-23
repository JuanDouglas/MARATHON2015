using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marathon.API.Exceptions
{

    [Serializable]
    public class TokenException : System.Exception
    {
        public TokenException() { }
        public TokenException(string message) : base(message) { }
        public TokenException(string message, System.Exception inner) : base(message, inner) { }
        protected TokenException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}