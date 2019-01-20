using System;
using System.Collections.Generic;
using System.Text;

namespace CDSPractical
{
    public static class Extensions
    {
        public static List<int> GenerateFibonacciSequence(this int maxElementValue)
        {
            List<int> fibElements = new List<int> { 1, 2 };
            if (maxElementValue < 3)
                return fibElements;

            int index = 1;
            int nextItem = 0;
            while (nextItem <= maxElementValue)
            {
                nextItem = fibElements[index] + fibElements[index - 1];
                if (nextItem <= maxElementValue)
                {
                    fibElements.Add(nextItem);
                    index++;
                }
            }
            return fibElements;
        }
    }
}
