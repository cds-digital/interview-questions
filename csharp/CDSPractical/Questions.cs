using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CDSPractical
{
    public class Questions
    {
        const double KMPerMile = 1.6;
        const long MaxTerm = 4000000;
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
            IList<int> result = new List<int>();

            foreach (var value in source)
            {
                int number = 0;
                if (int.TryParse(value, out number)) //try to read integer value
                {
                    result.Add(number);
                }
            }
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
            
            var commonWords = from word1 in first
                              join
                              word2 in second on word1 equals word2
                              select word1;

            if (commonWords.Count() > 0)
            {
                return commonWords.OrderByDescending(w => w.Length).FirstOrDefault();
            }
            return string.Empty;
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
            return km / KMPerMile;
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
            return miles * KMPerMile;
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
            string wordToCheck = word.ToLower();
            int length = word.Length;
            for (int index = 0; index < length / 2; index++)
            {
                if (wordToCheck[index] != wordToCheck[length - 1 - index])
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
            int length = source.Count();

            var list = new List<object>(source);

            Random random = new Random(0);

            object tempObject;
            //skip first no. as there will be swap atleast
            for (int index = 1; index < length; index++)
            {
                int nextRandom = random.Next(0, length - 1);//random index to swap
                while (nextRandom == index)
                {//skip to next if replacing same index
                    nextRandom = random.Next(0, length - 1);
                }
                tempObject = list[index];
                list[index] = list[index - 1];
                list[index - 1] = tempObject;
            }

            return list;
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
            int length = source.Count();
            int tempSwap = 0;

            //first pass is to settle down heightest number at bottom, n-1 passes
            for (int passIndex = 1; passIndex < length; passIndex++)
            {
                //everytime skip one pass from bottom 
                for (int index = 0; index < length - passIndex; index++)
                {
                    if (source[index] > source[index + 1])
                    {
                        tempSwap = source[index];
                        source[index] = source[index + 1];
                        source[index + 1] = tempSwap;
                    }
                }
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
            int previousNumber = 1;
            int number = 2;
            int sum = 0;
            int evenTermSum = 0;

            while (number <= MaxTerm)
            {
                sum = previousNumber + number; //fabonacci
                if (number % 2 == 0)
                {
                    evenTermSum += number; //even term sum
                }
                //seed next numbers
                previousNumber = number;
                number = sum;
            }
            return evenTermSum;
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
                        lock (ret)//both thread are competing and  updating data
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

            for (var i = 0; i < numThreads; i++)
            {
                threads[i].Join();
            }

            return ret;
        }
    }
}
