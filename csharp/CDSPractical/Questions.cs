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
            //integerList will contain all the results from the source that are integers
            var integerList = new List<int>();

            //parse the source list
            foreach (var element in source)
            {
                //try to parse the current element of the list and identify if 
                //it's an integer or nor
                var isInteger = int.TryParse(element, out int integer);

                //if the parsed element is an integer, add it to the integer list
                if (isInteger)
                {
                    integerList.Add(integer);
                }
            }

            return integerList.AsEnumerable();
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
            //the longest common word will be achieved by first identifying all the
            //commong words between the two lists and then taking the first result
            //after the list has been ordered descending based on their length
            return first
                .Intersect(second)
                .OrderByDescending(commonWords => commonWords.Length)
                .FirstOrDefault();
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
            //palindromes aren't case sensitive, so we can convert them to lower case
            //convert the word in char array to be able to use the reverse function
            var charArray = word.ToLowerInvariant().ToCharArray();

            //reverse the order of the characters inside the char array
            Array.Reverse(charArray);

            //create a string result from the reversed char array
            var reversedWord = new string(charArray);
            //create isPalindrom variable containing the result of the comparison
            //between the initial word and the resulting word
            var isPalindrome = reversedWord.Equals(word.ToLowerInvariant());

            return isPalindrome;
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
            var shuffledList = new List<object>();
            var random = new Random();

            //repeat the shuffling process as long as the source enumerable has 
            //the same order as the shuffled list - this is to make sure that
            //after the shuffling process, we don't have the same list as the source
            do
            {
                //initialize source list and shuffle list
                var sourceList = source.ToList();
                shuffledList = new List<object>();

                //as long as we still have elements in the source list, pick a
                //random index from the ones available and extract the resulting
                //word into the shuffled list
                while (sourceList.Count > 0)
                {
                    var randomIndex = random.Next(sourceList.Count);
                    shuffledList.Add(sourceList.ElementAt(randomIndex));
                    sourceList.RemoveAt(randomIndex);
                }
            }
            while (source.ToList().SequenceEqual(shuffledList));

            return shuffledList.AsEnumerable();
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
            //using bubble sort - not the most efficient method, 
            //but the one that popped first into my head
            for (var i = 0; i < source.Count(); i++)
            {
                for (var j = 0; j < source.Count() - 1; j++)
                {
                    //if the current value is greater than the next value from
                    //the array, swap the two values
                    if (source[j] > source[j + 1])
                    {
                        var temporaryVariable = source[j + 1];
                        source[j + 1] = source[j];
                        source[j] = temporaryVariable;
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
            var result = 0;
            var currentFibonacciNumber = 0;
            var previousFibonacciNumber = 1;
            var secondPreviousFibonnaciNumber = 0;

            //keep creating Fibonacci numbers from the sequence and add them to the result
            //only if they are even numbers, as long as the sum of the currentFibonacciNumber
            //and previousFibonacciNumber doesn't exceed the threshold
            do
            {
                secondPreviousFibonnaciNumber = previousFibonacciNumber;
                previousFibonacciNumber = currentFibonacciNumber;
                currentFibonacciNumber = previousFibonacciNumber + secondPreviousFibonnaciNumber;

                if (currentFibonacciNumber % 2 == 0)
                {
                    result += currentFibonacciNumber;
                }
            }
            while (currentFibonacciNumber + previousFibonacciNumber < 4000000);

            return result;
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
                        //by having assigned the next variable and then setting the 
                        //thread to a random sleep period, it's highly likely that both
                        //threads will have the same next value, so setting the thread 
                        //sleep value first and then initializing the next value will solve
                        //the problem of duplicate entries
                        Thread.Sleep(new Random().Next(1, 10));
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