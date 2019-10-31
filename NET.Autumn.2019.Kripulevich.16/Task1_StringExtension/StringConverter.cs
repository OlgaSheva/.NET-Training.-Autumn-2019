using System;

namespace Task1_StringExtension
{
    public class StringConverter
    {
        public string Convert(string inputString, int count)
        {
            if (inputString == null)
            {
                throw new ArgumentNullException(nameof(inputString));
            }
            if (string.IsNullOrWhiteSpace(inputString))
            {
                throw new ArgumentException(nameof(inputString));
            }
            if (string.IsNullOrEmpty(inputString))
            {
                throw new ArgumentException(nameof(inputString));
            }
            if (count < 0)
            {
                throw new ArgumentException(nameof(count));
            }
            if(count == 0 || inputString.Length < 3)
            {
                return inputString;
            }

            int length = inputString.Length;
            char[] odd = new char[length / 2];
            char[] even = new char[length / 2 + length % 2];
            int oddj = 0;
            int evenj = 0;

            while(count-- > 0)
            {
                oddj = 0;
                evenj = 0;
                for (int i = 1; i <= length; i++)
                {
                    if (i % 2 == 0)
                    {
                        odd[oddj++] = inputString[i - 1];
                    }
                    else
                    {
                        even[evenj++] = inputString[i - 1];
                    }
                }
                inputString = new string(even) + new string(odd);
            }

            return inputString;
        }
    }
}
