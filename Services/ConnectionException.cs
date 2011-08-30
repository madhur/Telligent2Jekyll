using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace BlogManager.Services
{
    public class ConnectionException: Exception
    {
        public ConnectionException(): base()
        {

        }
        public ConnectionException(Exception innerException)
            : this("Errore durante la connessione", innerException)
        { }

        public ConnectionException(string message): base(message)
        {

        }
        public ConnectionException(string message, Exception innerException): base(message, innerException)
        {

        }
        protected ConnectionException(SerializationInfo info, StreamingContext context): base(info, context)
        {

        }
    }
}
