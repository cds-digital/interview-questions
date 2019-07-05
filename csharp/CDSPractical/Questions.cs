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
       // Questions.ExtractNumbers(new List<string> {"123", "hello", "234" });
        public IEnumerable<int> ExtractNumbers(IEnumerable<string> source)
        {

            var result = new List<int>();
            foreach (var listItem in source)
            {
                var isNumeric = int.TryParse(listItem, out int n);
                if (isNumeric)
                {
                    result.Add(n);
                }
            }
            return result.Select(x => x);

            //throw new NotImplementedException();
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
            var firstList = first.OrderByDescending(x => x.Length);
            string result = string.Empty;
            foreach (var firstListItem in firstList)
            {
                if (second.Contains(firstListItem))
                {
                    result = firstListItem;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return result;
            //throw new NotImplementedException();
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
            var result = km * 0.625;
            return result;
            //throw new NotImplementedException();
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
            var result = miles * 1.6;
            return result;
            //throw new NotImplementedException();
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
            string result = string.Empty;
            bool isPalindrome = false;
            for (int i = word.Length; i > 0; i--)
            {
                result = result + word[i];
            }
            if (result.ToLower() == word.ToLower())
            {
                isPalindrome = true;
            }
            return isPalindrome;
            // throw new NotImplementedException();
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
            var sourceList = source.ToList();
            Random randomn = new Random();
            for (int i = 0; i < source.Count(); i++)
            {
                int j = randomn.Next(0, i);
                var value = sourceList[j];
                sourceList[j] = sourceList[i];
                sourceList[i] = value;
            }
            return sourceList.Select(x => x);
            //throw new NotImplementedException();
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
            int temp = 0;           
            for (int i = 0; i <= source.Length - 1; i++)
            {
                for (int j = i + 1; j < source.Length; j++)
                {
                    if (source[i] > source[j])
                    {
                        temp = source[i];
                        source[i] = source[j];
                        source[j] = temp;
                    }
                }
            }

            return source;

            // throw new NotImplementedException();
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
            int a = 0, b = 1, c = 0;
            List<int> d = new List<int>();
            for (int i = 0; i < 33; i++)
            {
                c = a + b;
                if (c % 2 == 0)
                {
                    d.Add(c);
                }
                a = b;
                b = c;
            }

            return d.Sum();
            //throw new NotImplementedException();
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
                threads[i] = new Thread(() => {
                    var complete = false;
                    while (complete)
                    {
                        var next = ret.Count + 1;
                        Thread.Sleep(new Random().Next(1, 10));
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
