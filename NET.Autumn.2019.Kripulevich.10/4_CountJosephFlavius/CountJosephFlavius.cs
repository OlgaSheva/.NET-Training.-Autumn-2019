using System;
using System.Collections.Generic;

namespace _4_CountJosephFlavius
{
    public static class CountJosephFlavius
    {
        public static int WhoWillSurvive(int count, int step)
        {
            if (count <= 0)
            {
                throw new ArgumentException($"The {nameof(count)} can't be less than one.");
            }

            if (step <= 0)
            {
                throw new ArgumentException($"The {nameof(step)} can't be less than one.");
            }

            if (count == 1 || step == 1)
            {
                return 0;
            }

            var list = new LinkedList<int>();
            for (int i = 0; i < count; i++)
            {
                list.AddLast(i);
            }

            var current = list.First;
            int score = 0;

            while(list.First != list.Last)
            {
                ++score;

                if (score == step)
                {
                    int value = current.Value;
                    current = current.Next;
                    list.Remove(value);
                    score = 1;
                }

                if (current == null)
                {
                    current = list.First;
                }

                current = current.Next ?? list.First;
            }

            return list.First.Value;
        }
    }
}
