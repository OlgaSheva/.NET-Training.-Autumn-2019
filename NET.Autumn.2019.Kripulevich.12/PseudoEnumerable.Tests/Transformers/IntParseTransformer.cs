using PseudoEnumerable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEnumerable.Tests
{
    public static class IntParseTransformer
    {
        public static int Transform(string @string)
        {
            return int.Parse(@string);
        }
    }
}
