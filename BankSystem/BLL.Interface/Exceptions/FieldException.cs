using System;

namespace BLL.Interface.Exceptions
{
    public class FieldException : Exception
    {
        const string validMessage = "Incorrect data entered in the field.";

        public FieldException() : base(validMessage)
        { }

        public FieldException(string auxMessage) :
            base(String.Format("{0} - {1}", auxMessage, validMessage))
        { }
    }
}
