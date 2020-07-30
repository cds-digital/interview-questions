using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
        /// <returns></returns>
        public IEnumerable<int> ExtractNumbers(IEnumerable<string> source) {

            if (source == null)
                throw new ArgumentNullException(nameof(source));

            int intValue = 0;
            return source.Where(s => int.TryParse(s, out intValue)).Select(s => intValue);
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
        public string LongestCommonWord(IEnumerable<string> first, IEnumerable<string> second) {

            if (first == null)
                throw new ArgumentNullException(nameof(first));
            if (second == null)
                throw new ArgumentNullException(nameof(second));

            var hashFirst = new HashSet<string>(first);
            var hashSecond = new HashSet<string>(second);

            hashFirst.IntersectWith(hashSecond);
            return hashFirst.OrderByDescending(x => x.Length)
                .FirstOrDefault();
            // or
            //return first.Intersect(second, StringComparer.OrdinalIgnoreCase)
            //    .OrderByDescending(x => x.Length)
            //    .FirstOrDefault();
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
        /// <returns></returns>
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
        /// <returns></returns>
        public bool IsPalindrome(string word) {

            if (string.IsNullOrWhiteSpace(word))
            {
                return false;
            }

            var reversed = new string(word.Reverse().ToArray());
            var palindrome = string.Equals(word, reversed, 
                StringComparison.InvariantCultureIgnoreCase);

            return palindrome;
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
        public IEnumerable<object> Shuffle(IEnumerable<object> source) {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
           
            var rnd = new Random();
            var result = source.Select(x => new {value = x, order = rnd.Next()})
                .OrderBy(x => x.order).Select(x => x.value).ToList();

            return result;
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
            source.Insertsort();
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
        public int FibonacciSum(int limit)
        {
            return Util.EvenFibonacciSum(limit);
        }


        /// <summary>
        /// Generate a list of integers from 1 to 100.
        /// 
        /// This method is currently broken, fix it so that the tests pass.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GenerateList()
        {

            var ret = new int[100];
            var numThreads = 2;

            // NOTE This method is implemented wrongly based on the description. 
            // Bare minimum:
            //      Thread.Sleep should not be used in this situation
            //      We need a thread lock and sync mechanism
            // It will need a further discussion to clarify requirements
            // before it can be fixed

            // one way to implement in a simple manner is 
            Parallel.For(0, 100,
                new ParallelOptions { MaxDegreeOfParallelism = numThreads },
                index =>
                {
                    // Every thread has its own item. No shared resource, no lock required.
                    ret[index] = index+1;
                });
            return ret;



            //var ret = new List<int>();
            //Thread[] threads = new Thread[numThreads];
            //for (var i = 0; i < numThreads; i++)
            //{
            //    threads[i] = new Thread(() => {
            //        var complete = false;
            //        while (!complete)
            //        {
            //            var next = ret.Count + 1;
            //            //Thread.Sleep(new Random().Next(1, 10));
            //            if (next <= 100)
            //            {
            //                ret.Add(next);
            //            }

            //            if (ret.Count >= 100)
            //            {
            //                complete = true;
            //            }
            //        }
            //    });
            //    threads[i].Start();
            //}

            //for (var i = 0; i < numThreads; i++)
            //{
            //    threads[i].Join();
            //}

            //return ret;
        }


        
    }

    public static class Util
    {
        /// <summary>
        /// Returns sum of even Fibonacci
        /// numbers which are less than or
        /// equal to given limit. 
        ///  1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233
        /// every third number in the Fibonacci series is even
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static int EvenFibonacciSum(int limit)
        {
            if (limit < 2)
                return 0;

            var one = 2;
            var two = 8;
            var temp = 0;
            var sum = 0;
            while (one < limit)
            {
                //update sum 
                sum += one;
                // Move to next even number 
                temp = two;
                two = (4 * two) + one;
                one = temp;
            }
            return sum;
        }

        
        public static void Insertsort(this int[] data)
        {
            int n = data.Length;
            for (int i = 1; i < n; i++)
            {
                int item = data[i];
                int ins = 0;
                for (int j = i - 1; j >= 0 && ins != 1;)
                {
                    if (item < data[j])
                    {
                        data[j + 1] = data[j];
                        j--;
                        data[j + 1] = item;
                    }
                    else
                    {
                        ins = 1;
                    }
                }
            }
        }
    }
}
