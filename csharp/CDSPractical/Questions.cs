using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

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

            IList<int> listOfIntegersFromSource = new List<int>();
            bool isInt = false;
            //check if source contains any string
            if(source != null)
            {
                if(source.Count() > 0 )
                {
                    foreach (var stringval in source)
                    {
                        int intFromSource;

                        //check if the value is integer

                        isInt = int.TryParse(stringval, out intFromSource);

                        if (isInt == true)
                        {
                            listOfIntegersFromSource.Add(intFromSource);
                        }

                        isInt = false;
                    }
                }
               
            }

            return listOfIntegersFromSource;

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

            string longestCommonWord = string.Empty;

                        

            if(first != null && second != null)
            {
                if(first.Count() > 0 && second.Count() > 0)
                {
                    try
                    {
                        //use join to find the common word, then order by descending to find longest among common,then return the first. 
                        longestCommonWord = first.Join(second, str1 => str1, str2 => str2, (str1, str2) => str1)
                                                 .OrderByDescending(x => x.Length)
                                                 .FirstOrDefault();

                        if (!string.IsNullOrEmpty(longestCommonWord))
                        {
                            return longestCommonWord;
                        }
                    }
                    catch(Exception ex)
                    {
                        return "Need to log the error " + ex.Message;
                    }
                   

                }

            }



            return longestCommonWord;



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

            const double milesInKm = 1.6;
            double miles = 0.0;
            if(km > 0)
            {
                miles = km / milesInKm;
                return miles;
            }
            else
            {
                return 0;
            }

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
            const double kmInMIles = 1.6;
            double km = 0.0;
            if (miles > 0)
            {
               km = miles * kmInMIles;
                return km;
            }
            else
            {
                return 0;
            }
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

            
            if(!string.IsNullOrEmpty(word))
            {
                string revWord = word.Reverse().ToString();

                if(revWord == word)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
                                   
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

            if(source != null)
            {
                if(source.Count() > 0)
                {
                    return source.Reverse();
                }
            }

            return source;

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

            if(source.Count() > 1)
            {
                
                int temp;


                for(int i = 0; i< source.Length; i++ )
                {
                    //loop one less time as with every loop one element is sorted
                   for(int j =0; j < source.Length - 1;  j++ )
                    {
                        //if n+1 element is greater then nth element then swap the two
                        if(source[j] > source[j+1])
                        {
                            temp = source[j + 1];
                            source[j + 1] = source[j];
                            source[j] = temp;
                        }
                    }
                }

                return source;
            }
            else
            {
                return source;
            }


            

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

            int i = 1;
            int j = 2;

            int fibo = 0;
            int sum = 2;

            do
            {
                fibo = GetFibo(i, j);

                if(fibo % 2 == 0)
                {
                    sum = sum + fibo;
                }

                i = j;
                j = fibo;
            } while (fibo <= 4000000);

            return sum;

        }

        int GetFibo(int i, int j)
        {            
            int fibo = i + j;
                      

            return fibo;
        }

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
                        //Thread.Sleep(new Random().Next(1, 10));

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

            //for (var i = 0; i < numThreads; i++) {
            //    threads[i].Join();
            //}

            return ret;
        }
    }
}
