using System;

namespace BLL.Interface.Exceptions
{
    /// <summary>
    /// Freezed account exception.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class FreezedAccountException : Exception
    {
        const string freezedMessage = "This account is closed.";

        public FreezedAccountException() : base(freezedMessage)
        { }

        public FreezedAccountException(string auxMessage) :
            base(String.Format("{0} - {1}", auxMessage, freezedMessage))
        { }
    }
}
