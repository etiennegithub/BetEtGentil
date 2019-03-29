using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetEtMechant.Class
{
    public class FlashMessage
    {
        public string Message { get; private set; }
        public TypeMessage TypeMessage { get; private set; }

        public FlashMessage(string message, TypeMessage typeMessage)
        {
            Message = message;
            TypeMessage = typeMessage;
        }
    }

    public enum TypeMessage
    {
        SUCCESS,
        WARNING,
        DANGER,
        INFO
    }
}
