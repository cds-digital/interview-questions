using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace CDSPractical
{
    public class Questions
    {
        /// <summary>
        /// Given an enumerable of strings, attempt to parse each string and if 
        /// it is an integer, add it to the returned enumerable.
        /// 
        /// For example:
        /// 
        /// ExtractNumbers(new List<string> { "123", "hello", "234" });
        /// 
        /// ; would return:
        /// 
        /// {
        ///   123,
        ///   234
        /// }
        /// </summary>
        /// <param name="source">An enumerable containing words</param>
        /// <returns></returns>
        public IEnumerable<int> ExtractNumbers(IEnumerable<string> source)
        {
            List<int> result = new List<int>();

            source.ToList().ForEach(n =>
            {
                if (int.TryParse(n, out int res))
                {
                    result.Add(res);
                }
            });

            return result;
        }

        /// <summary>
        /// Given two enumerables of strings, find the longest common word.
        /// 
        /// For example:
        /// 
        /// LongestCommonWord(
        ///     new List<string> {
        ///         "love",
        ///         "wandering",
        ///         "goofy",
        ///         "sweet",
        ///         "mean",
        ///         "show",
        ///         "fade",
        ///         "scissors",
        ///         "shoes",
        ///         "gainful",
        ///         "wind",
        ///         "warn"
        ///     },
        ///     new List<string> {
        ///         "wacky",
        ///         "fabulous",
        ///         "arm",
        ///         "rabbit",
        ///         "force",
        ///         "wandering",
        ///         "scissors",
        ///         "fair",
        ///         "homely",
        ///         "wiggly",
        ///         "thankful",
        ///         "ear"
        ///     }
        /// );
        /// 
        /// ; would return "wandering" as the longest common word.
        /// </summary>
        /// <param name="first">First list of words</param>
        /// <param name="second">Second list of words</param>
        /// <returns></returns>
        public string LongestCommonWord(IEnumerable<string> first, IEnumerable<string> second)
        {

            return first.Intersect(second).OrderByDescending(word => word.Length).FirstOrDefault();
        }

        /// <summary>
        /// Write a method that converts kilometers to miles, given that there are
        /// 1.6 kilometers per mile.
        /// 
        /// For example:
        /// 
        /// DistanceInMiles(16.00);
        /// 
        /// ; would return 10.00;
        /// </summary>
        /// <param name="km">distance in kilometers</param>
        /// <returns></returns>
        public double DistanceInMiles(double km)
        {
            return km / 1.6;
        }

        /// <summary>
        /// Write a method that converts miles to kilometers, give that there are
        /// 1.6 kilometers per mile.
        /// 
        /// For example:
        /// 
        /// DistanceInKm(10.00);
        /// 
        /// ; would return 16.00;
        /// </summary>
        /// <param name="miles">distance in miles</param>
        /// <returns></returns>
        public double DistanceInKm(double miles)
        {
            return miles * 1.6;
        }

        /// <summary>
        /// Write a method that returns true if the word is a palindrome, false if
        /// it is not.
        /// 
        /// For example:
        /// 
        /// IsPalindrome("bolton");
        /// 
        /// ; would return false, and:
        /// 
        /// IsPalindrome("Anna");
        /// 
        /// ; would return true.
        /// 
        /// Also complete the related test case for this method.
        /// </summary>
        /// <param name="word">The word to check</param>
        /// <returns></returns>
        public bool IsPalindrome(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return false;
            }

            var chars = word.ToLower().ToCharArray();

            for (int i = 0; i <= chars.Length / 2; ++i)
            {
                if (chars[i] != chars[chars.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Write a method that takes an enumerable list of objects and shuffles
        /// them into a different order.
        /// 
        /// For example:
        /// 
        /// Shuffle(new List<string>{ "one", "two" });
        /// 
        /// ; would return:
        /// 
        /// {
        ///   "two",
        ///   "one"
        /// }
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IEnumerable<object> Shuffle(IEnumerable<object> source)
        {
            if (!(source is IList<object> asList))
            {
                asList = source.ToList();
            }

            for (var i = asList.Count - 1; i >= 0; --i)
            {
                yield return asList[i];
            }
        }

        /// <summary>
        /// Write a method that sorts an array of integers into ascending
        /// order - do not use any built in sorting mechanisms or frameworks.
        /// 
        /// Complete the test for this method.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public int[] Sort(int[] source)
        {
            if (source.Length == 0) return new int[0];
       
            var result = new int[source.Length];
            result[0] = source[0];

            for (var index = 1; index < source.Length; ++index)
            {
                var currentValue = source[index];
                var i = index;
                while (i > 0 && result[i - 1] > currentValue)
                {
                    result[i] = result[i - 1];
                    --i;
                }

                result[i] = currentValue;
            }

            return result;
        }

        /// <summary>
        /// Each new term in the Fibonacci sequence is generated by adding the 
        /// previous two terms. By starting with 1 and 2, the first 10 terms will be:
        ///
        /// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
        ///
        /// By considering the terms in the Fibonacci sequence whose values do 
        /// not exceed four million, find the sum of the even-valued terms.
        /// </summary>
        /// <returns></returns>
        public int FibonacciSum()
        {
            var previous = 1;
            var current = 2;
            var sum = 2;
            int next;
            while ((next = previous + current) < 4_000_000)
            {
                if (next % 2 == 0)
                {
                    sum += next;
                }

                previous = current;
                current = next;
            }

            return sum;
        }

        /// <summary>
        /// Generate a list of integers from 1 to 100.
        /// 
        /// This method is currently broken, fix it so that the tests pass.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GenerateList()
        {
            var ret = new List<int>();
            var numThreads = 2;

            Thread[] threads = new Thread[numThreads];
            for (var i = 0; i < numThreads; i++)
            {
                threads[i] = new Thread(() =>
                {
                    var complete = false;
                    while (!complete)
                    {
                        var next = ret.Count + 1;
                        if (next <= 100)
                        {
                            ret.Add(next);
                        }

                        if (ret.Count >= 100)
                        {
                            complete = true;
                        }
                    }
                });
                threads[i].Start();
            }

            for (var i = 0; i < numThreads; i++)
            {
                threads[i].Join();
            }

            return ret;
        }
    }
}
