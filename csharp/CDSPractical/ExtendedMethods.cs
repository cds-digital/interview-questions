using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CDSPractical
{
  static class ExtendedMethods
    {
        public static IEnumerable<T> ShuffleExt<T>(this IEnumerable<T> sourceList)
        {
            var r = new Random();
            return sourceList.OrderBy(x => r.Next()).ToList();
        }
    }
}
