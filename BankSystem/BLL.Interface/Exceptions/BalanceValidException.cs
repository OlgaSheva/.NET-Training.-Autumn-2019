using System;

namespace BLL.Interface.Exceptions
{
    /// <summary>
    /// Balance valid exception.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class BalanceValidException : Exception
    {
        const string validMessage = "This balance is not valid.";

        public BalanceValidException() : base(validMessage)
        { }

        public BalanceValidException(string auxMessage) :
            base(String.Format("{0} - {1}", auxMessage, validMessage))
        { }
    }
}
