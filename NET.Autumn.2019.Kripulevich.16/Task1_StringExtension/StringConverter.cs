using System;
using System.Text;

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

            var sb = new StringBuilder(inputString);
            int iterationCount = IteretionCountForIdenticalString(inputString);
            iterationCount = count % iterationCount;
            while(iterationCount-- > 0)
            {
                sb = OneIteration(sb);
            }

            return sb.ToString();
        }

        private int IteretionCountForIdenticalString(string inputString)
        {
            int count = 0;
            var sb = new StringBuilder(inputString);
            do
            {
                sb = OneIteration(sb);
                count++;
            } while (!inputString.Equals(sb.ToString()));

            return count;
        }

        private StringBuilder OneIteration(StringBuilder @string)
        {
            StringBuilder odd = new StringBuilder();
            StringBuilder even = new StringBuilder();
            for (int i = 1; i <= @string.Length; i++)
            {
                if (i % 2 == 0)
                {
                    odd.Append(@string[i - 1]);
                }
                else
                {
                    even.Append(@string[i - 1]);
                }
            }

            return even.Append(odd);
        }
    }
}
