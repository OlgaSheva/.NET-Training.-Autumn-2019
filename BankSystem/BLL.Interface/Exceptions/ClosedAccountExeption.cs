using System;

namespace BLL.Interface.Exceptions
{
    /// <summary>
    /// Closed account exception.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class ClosedAccountException : Exception
    {
        const string clozedMessage = "This account is closed.";

        public ClosedAccountException() : base(clozedMessage)
        { }

        public ClosedAccountException(string auxMessage) :
            base(String.Format("{0} - {1}", auxMessage, clozedMessage))
        { }
    }
}
