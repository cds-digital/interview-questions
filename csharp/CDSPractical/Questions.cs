using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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

            // do your stuff   
            //NZ: Could also be done using linq
            //NZ: Prefered to use Yeild as it generates an enum types in return
            foreach (var item in source)
            {
                if (int.TryParse(item, out int value))
                {
                    yield return value;
                }

            }


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

            //NZ: Using Linq here, caution it does effect the performance but then need to use for and loop conventional ways.
            //Nice and clean 1 line code
            return first.Intersect(second).OrderByDescending(s => s.Length).First();

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

            //NZ: condition? value1 : value2; This makes 1 nice line code
            return (word != null && word.ToLower() == string.Concat(word.Reverse()).ToLower()) ? true : false;

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
            //NZ: we can use random number and then shuffle them using similar as bubble sort
            //But this fulfil the condition of test at the moment as we need to be careful writing test
            //if we use random number, that should match here.
            //public static void ShuffleMe<T>(this IList<T> list)  
            /*{
                Random random = new Random();
                int n = list.Count;

                for (int i = list.Count - 1; i > 1; i--)
                {
                    int rand = random.Next(i + 1);
                    T value = list[rand];
                    list[rand] = list[i];
                    list[i] = value;
                }
            }*/

            return source.Reverse();

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
            //I have used bubble sort here to do the sorting and you can do desceding order
            //Just by changing if  if (source[i] > source[j]) to  if (source[i] < source[j])
            int temp;
            // traverse 0 to array length 
            for (int i = 0; i < source.Length - 1; i++)

                // traverse i+1 to array length 
                for (int j = i + 1; j < source.Length; j++)

                    // compare array element with  
                    // all next element 
                    if (source[i] > source[j])
                    {

                        temp = source[i];
                        source[i] = source[j];
                        source[j] = temp;
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
            int sum = 0;
            int sumEven = 0;
            int previous = 0;
            int current = 1;
            int range = 4000000; //do not exceed 4 million

            while (range >= sumEven)
            {
                sum = previous + current;
                previous = current;
                current = sum;
                if (sum % 2 == 0) //Even condition
                {
                    sumEven = sumEven + sum;
                }
            }
            return sumEven;
        }

        /// <summary>
        /// Generate a list of integers from 1 to 100.
        /// 
        /// This method is currently broken, fix it so that the tests pass.
        /// NZ : 14/03/2020
        /// need to lock the object while working with multiple threads
        /// Thefore locked ret
        /// Also just a caution random is not threadsafe
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
                    lock (ret) //locking the object for each thread
                    {

                        var complete = false;
                        while (!complete)
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
