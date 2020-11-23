using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

/// <summary>
/// 
/// </summary>
namespace CDSPractical
{
    /// <summary>
    /// Ram Natarajan - Interview Question's Answers
    /// </summary>
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
            return source != null && source.Any() ? source.Select(s =>
            {
                var parseSuccess = int.TryParse(s, out int numericValue);
                return new { parseSuccess, numericValue };
            }).Where(r => r.parseSuccess).Select(sel => sel.numericValue).ToList<int>() : new List<int>();
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
            return first != null && first.Any() && second != null && second.Any() ?
                first.Intersect(second, StringComparer.OrdinalIgnoreCase).OrderByDescending(o => o.Length).First()
                : string.Empty;
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
            return (km / 1.6);
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
            return (miles * 1.6);
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
            return !string.IsNullOrWhiteSpace(word) ? word.ToLower().Equals(word.ToLower().Reverse()) : false;
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
            var randomNo = new Random();
            return source != null && source.Any() ?
                source.Select(x => new { value = x, randomOrder = randomNo.Next() }).OrderBy(x => x.randomOrder).Select(x => x.value).ToList()
                : new List<object>();
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
            int N = source.Length;

            for (int j = source.Length - 1; j > 0; j--)
                for (int i = 0; i < j; i++)
                    if (source[i] > source[i + 1])
                    {
                        int temporary;
                        temporary = source[i];
                        source[i] = source[i + 1];
                        source[i + 1] = temporary;
                    }

            return source;
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
            int topEnd = 4613732; // Setting a 4 million limit
            long firstValue = 0;
            long secondValue = 2;
            long summationValue = firstValue + secondValue;

            while (secondValue <= topEnd)
            {
                long nextValue = 4 * secondValue + firstValue;

                if (nextValue > topEnd)
                    break;

                firstValue = secondValue;
                secondValue = nextValue;
                summationValue += secondValue;
            }

            return Convert.ToInt32(summationValue);
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
                            ret.Add(next);

                        if (ret.Count >= 100)
                            complete = true;
                    }
                });
                threads[i].Start();
            }

            for (var i = 0; i < numThreads; i++)
                threads[i].Join();

            Thread.Sleep(new Random().Next(1, 10));

            return ret;
        }
    }
}
