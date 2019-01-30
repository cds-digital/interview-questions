using System;
using System.Collections.Generic;
using System.Linq;
using CDSPractical.Extensions;
using CDSPractical.Helpers;

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
			var list = new List<int>();

			foreach (var item in source)
			{
				bool success = Int32.TryParse(item, out var number);
				if (success)
					list.Add(number);
			}

			return list;
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
			return first.Where(x => second.Contains(x)).OrderByDescending(X => X.Length).FirstOrDefault();
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
			return Converters.ConvertKMtoMiles(km);
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
			return Converters.ConvertMilesToKM(miles);
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
			//Sanitise the word to ensure we are comparing the words regardless of capital letters or spaces at the ends
			var wordToCompare = word.ToLower().Trim();

			return wordToCompare == Converters.ReverseWord(wordToCompare);
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
			var list = source.ToList();
			list.Shuffle();
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
			int count = source.Length;
			bool swapped = true;

			while (swapped)
			{
				swapped = false;
				for (int i = 0; i < count - 1; i++)
				{
					if (source[i] > source[i + 1])
					{
						int temp = source[i + 1];
						source[i + 1] = source[i];
						source[i] = temp;
						swapped = true;
						// no need to compare the next item as we just shifted our number to it
						i++;
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
		public int FibonacciSum(int max)
		{
			int firstNumber = 0;
			int secondNumber = 1;
			int sum = 0;

			while (secondNumber <= max)
			{
				int temp = firstNumber;
				firstNumber = secondNumber;
				secondNumber = temp + secondNumber;

				if (Converters.NumberIsEVen(secondNumber))
					sum = sum + secondNumber;
			}

			return sum;
		}

		/// <summary>
		/// Generate a list of integers from 1 to 100.
		/// 
		/// This method is currently broken, fix it so that the tests pass.
		/// </summary>
		/// <returns></returns>

		public IEnumerable<int> GenerateList(int listLimit)
		{
			var ret = new List<int>();

			var complete = false;
			while (!complete)
			{
				var next = ret.Count + 1;

				if (next <= listLimit)
				{
					ret.Add(next);
				}

				if (ret.Count >= listLimit)
				{
					complete = true;
				}
			}

			return ret;
		}


	}
}
