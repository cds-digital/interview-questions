using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CDSPractical {
    public class Questions {
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
        /// <returns>An enumerable of the input values that successfully parse as integers</returns>
        public IEnumerable<int> ExtractNumbers(IEnumerable<string> source)
        {
            //tested 2 versions of this with 10000000 iterations of the assert, my Linq version consistently comes out slower than the foreach version
            var results = new List<int> { };
            foreach (var item in source)
            {
                int result;
                if (int.TryParse(item, out result))
                {
                    results.Add(result);
                }
            }
            return results;
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
        /// <returns>The longest string that appears in both collections</returns>
        public string LongestCommonWord(IEnumerable<string> first, IEnumerable<string> second) {
            var combined = (first ?? Enumerable.Empty<string>()).Concat(second ?? Enumerable.Empty<string>());
            var common = combined.GroupBy(w => w).Where(g => g.Count() > 1).Select(g => g.Key);
            var longest = common.OrderByDescending(s => s.Length).FirstOrDefault();
            return longest ?? string.Empty;
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
        /// <returns>the input value converted to miles</returns>
        public double DistanceInMiles(double km) {
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
        /// <returns>the input value converted to kilometers</returns>
        public double DistanceInKm(double miles) {
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
        /// <returns>boolean of true if the input word is a palindrome</returns>
        public bool IsPalindrome(string word) {
            string lowercase = word.ToLower();
            char[] lowercaseArray = lowercase.ToCharArray();
            Array.Reverse(lowercaseArray);
            return lowercase == (new string(lowercaseArray));
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
        /// <param name="source">An enumerable containing objects</param>
        /// <returns></returns>
        public IEnumerable<object> Shuffle(IEnumerable<object> source) {
            if (source.Count() < 2)
                return source;

            var result = source.ToList();
            var length = result.Count;
            for (int i = 0; i < length-1; i++)
            {
                //cant use some random generator to determine positions to swap as this could potentially result in the 
                //same ordered collection as is input
                //further, given the requirements dont explicitly require randomness (and the given test prevents this)
                //we can use some fixed arbitrary shuffling algorithm
                if (i % 2 == 0)
                {
                    SwapElements(result, i, i + 1);
                }
                else
                {
                    SwapElements(result, i, length - 1);
                }
            }
            return result;
        }

        private void SwapElements(List<object> source, int position1, int position2)
        {
            var temp = source[position1];
            source[position1] = source[position2];
            source[position2] = temp;
        }

        /// <summary>
        /// Write a method that sorts an array of integers into ascending
        /// order - do not use any built in sorting mechanisms or frameworks.
        /// 
        /// Complete the test for this method.
        /// </summary>
        /// <param name="source">an array of of potentially unsorted integers</param>
        /// <returns>a sorted array of integers</returns>
        public int[] Sort(int[] source) {
            //going with bubble sort here as this is one of the first sorting algorithms i learned at uni in leicester back in 1994
            //rather than copy/paste a complex quicksort algorithm from google.
            int len = source.Length;
            //shallow copy is fine here
            var sortedArray = (int[]) source.Clone();
            for (int iteration = len - 1; iteration > 0; iteration--)
            {
                for (int index = 0; index < iteration; index++)
                {
                    if (sortedArray[index] > sortedArray[index + 1])
                    {
                        var smaller = sortedArray[index + 1];
                        sortedArray[index + 1] = sortedArray[index];
                        sortedArray[index] = smaller;
                    }
                }
            }
            return sortedArray;
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
        /// <returns>integer sum of even fibonacci elements that do not exceed 4000000</returns>
        public int FibonacciSum() {
            var maxElementValue = 4000000;
            var fibElements = maxElementValue.GenerateFibonacciSequence();
            var evenSum = fibElements.Where(f => f % 2 == 0).Sum(f => f);
            return evenSum;
        }

        /// <summary>
        /// Generate a list of integers from 1 to 100.
        /// 
        /// This method is currently broken, fix it so that the tests pass.
        /// </summary>
        /// <returns>An enumerable of sequentially ordered integers 1 to 100</returns>
        public IEnumerable<int> GenerateList() {
            var ret = new List<int>();
            var numThreads = 2;
            object listLock = new object();

            Thread[] threads = new Thread[numThreads];
            for (var i = 0; i < numThreads; i++) {
                threads[i] = new Thread(() => {
                    var complete = false;
                    while (!complete) {
                        lock (listLock)
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
                    }                    
                });
                threads[i].Start();
            }

            for (var i = 0; i < numThreads; i++) {
                threads[i].Join();
            }

            return ret;
        }
    }
}
