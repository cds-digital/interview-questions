using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.IO;

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
        /// 
        
        /// </summary>
        /// <param name="source">An enumerable containing words</param>
        /// <returns></returns>
        public IEnumerable<int> ExtractNumbers(IEnumerable<string> source) {
            List<int> result = new List<int>();
            foreach (string value in source)
            {
                int n;
                bool isNumeric = int.TryParse(value, out n);
                if (isNumeric)
                    result.Add(n);
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
        public string LongestCommonWord(IEnumerable<string> first, IEnumerable<string> second) {
        HashSet<string> hashSet = new HashSet<string>();

            foreach (string word in first) // moving first to hashset
            {
                hashSet.Add(word);
            }

            int matchingWordSize = 0;
            string matchingWord = "";

            foreach (string word in second) // looping through second
            {
                if (!hashSet.Contains(word)) // finding common word
                {
                    continue;
                }
                else if (matchingWordSize < word.Length) // storing longest common word
                {
                    matchingWordSize = word.Length;
                    matchingWord = word;
                }
            }

            return matchingWord;
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
            double result = km * 0.6;
            result = Math.Ceiling(Math.Round(result, 2)); // converting to miles
            return  result;
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
            //Reverse the string
            if (word == null || word.Length == 0)
            {
                return false;
            }

            //Reverse the string
            char[] reverse = new char[word.Length];
            for (int i = word.Length - 1, j = 0; i >= 0; i--, j++)
            {
                reverse[j] = word[i];
            }
            return word.CompareTo(reverse.ToString()) == 0 ? true : false; //compare original and reverse string
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
                return null;
            }

            object[] sourceObjects = source.ToArray<object>();
            int lastObjectIndex = sourceObjects.Length - 1;
            Random rand = new Random(); 

            for (int i = 0; i <= lastObjectIndex; i++)
            {
                int swapIndex = rand.Next(lastObjectIndex); // finding random index and swapping
                object temp = sourceObjects[i];
                sourceObjects[i] = sourceObjects[swapIndex];
                sourceObjects[swapIndex] = temp;
            }

            return sourceObjects;
        }

        /// <summary>
        /// Write a method that sorts an array of integers into ascending
        /// order - do not use any built in sorting mechanisms or frameworks.
        /// 
        /// Complete the test for this method.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
	    public int[] Sort(int[] source) {
            int[] sorted = new int[] { };
            for (int i = 0; i < source.Count(); i++)
            {
                var x = source[i];
                var j = i;
                while (j > 0 && source[j - 1] > x)
                {
                    source[j] = source[j - 1];
                    j = j - 1;
                }
                sorted[j] = x;
            }
            return sorted;
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
        public int FibonacciSum() {
            // Generated Fibonicci series and sum in one function 
            // result will have fibonicci series
            int first = 0;
            int second = 1;
            IList<int> result = new List<int> { }; // fibonicci series list . This code should go under getfibonicci
            result.Add(first);
            result.Add(second);
            int evenCount = 0;
            var sum = 0;
            while (second < 4000000) // term should be less than 4 million
            {
                sum = first + second;
                if (sum % 2 == 0)
                {
                    evenCount += sum;
                }
                result.Add(sum);
                first = second;
                second = sum;
            }
            return evenCount;
        }

  /*      public IEnumerable<int> getfibonicci()
        {

            
        } */

        /// <summary>
        /// Generate a list of integers from 1 to 100.
        /// 
        /// This method is currently broken, fix it so that the tests pass.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GenerateList() {
            var ret = new List<int>();
            var numThreads = 2;

            Thread[] threads = new Thread[numThreads];
            for (var i = 0; i < numThreads; i++) {
                threads[i] = new Thread(() => {
                    var complete = false;
                    while (!complete) {                        
                        var next = ret.Count + 1;
                        // Thread.Sleep(new Random().Next(1, 10)); 
                        Thread.Sleep(new Random().Next(1, 100)); // change
                        if (next <= 100) {
                            ret.Add(next);
                        }

                        if (ret.Count >= 100) {
                            complete = true;
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
