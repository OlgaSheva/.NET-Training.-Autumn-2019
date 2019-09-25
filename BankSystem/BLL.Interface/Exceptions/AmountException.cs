using System;

namespace BLL.Interface.Exceptions
{
    /// <summary>
    /// Amount exception.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class AmountException : Exception
    {
        const string validMessage = "This amount is not valid.";

        public AmountException() : base(validMessage)
        { }

        public AmountException(string auxMessage) :
            base(String.Format("{0} - {1}", auxMessage, validMessage))
        { }
    }
}
