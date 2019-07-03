using System;
using System.Collections.Generic;
using System.Linq;

namespace CDSPractical
{
    /// <summary>
    /// This class holds all the extended methods  
    /// </summary>
    static class ExtendedMethods
    {
        public static IEnumerable<T> ShuffleExtender<T>(this IEnumerable<T> enumerable)
        {
            var r = new Random();
            return enumerable.OrderBy(x => r.Next()).ToList();
        }
    }
}
