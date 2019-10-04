using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.Interfaces
{
    public interface ISorter<T>
    {
        T[] Sort(T[] array);
    }
}
