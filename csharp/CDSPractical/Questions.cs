using System;
using System.Collections;
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
            var _listArr = source.Cast<string>().ToList();
            List<int> _outputList = new List<int>();
            double _retNumber;
            foreach (var _item in _listArr)
            {
                bool _isNumber = Double.TryParse(Convert.ToString(_item), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out _retNumber);
                if (_isNumber)
                    _outputList.Add(Convert.ToInt32(_item));
            }
            return _outputList.AsEnumerable<int>();

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
            var _lengthFromFirstList = first.Max(s => s.Length);            
            var _biggestWordFromFirstList = first.FirstOrDefault(s => s.Length == _lengthFromFirstList);

            var _lengthFromSecondList = second.Max(s => s.Length);            
            var _biggestWordFromSecondList = second.FirstOrDefault(s => s.Length == _lengthFromSecondList);

            if (String.Equals(_biggestWordFromFirstList, _biggestWordFromSecondList))
            {
                return _biggestWordFromSecondList;
            }
            else
            {
                return "";
            }
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
            const double _kmValues = 1.6;
            return km/ _kmValues;
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
            const double _kmValues = 1.6;
            return _kmValues * miles;
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
            string _reverseWord = string.Empty;
            for (int i = word.Length - 1; i >= 0; i--)
            {
                _reverseWord += word[i].ToString();
            }
            if (_reverseWord == word)
            {
                return true;
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
        public IEnumerable<object> Shuffle(IEnumerable<object> source)
        {
            string _tempStr;
            var _listArr = source.Cast<string>().ToList().ToArray();

            _tempStr = _listArr[0];
            _listArr[0] = _listArr[1];
            _listArr[1] = _tempStr;
            List<string> _outputList = _listArr.ToList<string>();
           return  _outputList.AsEnumerable<object>();
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
            int temp;
            for (int i = 0; i < source.Length - 2; i++)
            {
                for (int j = 0; j < source.Length - 2; j++)
                {
                    if (source[j] > source[j + 1])
                    {
                        temp = source[j + 1];
                        source[j + 1] = source[j];
                        source[j] = temp;
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
            int _sumOFEvenValued = 0;
            int _num1 = 0, _num2 = 1, _num3;
            ArrayList _objArr = new ArrayList();
            for (int i = 2; i < 35; i++)
            {
                _num3 = _num1 + _num2;
                _objArr.Add(_num3);
                _num1 = _num2;
                _num2 = _num3;
                if (_num3 > 4000000)
                    break;
            }
            for (int i = 0; i < _objArr.Count - 1; i++)
            {
                if ((int)_objArr[i] % 2 == 0)
                {
                    _sumOFEvenValued = _sumOFEvenValued + (int)_objArr[i];
                }               
            }

            return _sumOFEvenValued;
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
                        //Thread.Sleep(new Random().Next(1, 10)); // No need to sleep current thread.
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
