using CDSPractical;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CDSPracticalTests {
    public class Tests {
        Questions instance = new Questions();

        [Fact]
        public void CanExtractNumbers() {
            Assert.Equal(new List<int> {
                123,
                234
            }, instance.ExtractNumbers(new List<string> {
                "123",
                "hello",
                "234"
            }));

            Assert.Equal(new List<int> {}, instance.ExtractNumbers(new List<string> {                
                "hello",
                "there"
            }));

            Assert.Equal(new List<int> {
                123,
                345
            }, instance.ExtractNumbers(new List<string> {
                "hello",
                "there",
                "123",
                "234.23",
                "345"
            }));
        }

        [Fact]
        public void CanGetLongestCommonWord() {
            Assert.Equal("wandering", instance.LongestCommonWord(
                new List<string> {
                    "love",
                    "wandering",
                    "goofy",
                    "sweet",
                    "mean",
                    "show",
                    "fade",
                    "scissors",
                    "shoes",
                    "gainful",
                    "wind",
                    "warn"
                },
                new List<string> {
                    "wacky",
                    "fabulous",
                    "arm",
                    "rabbit",
                    "force",
                    "wandering",
                    "scissors",
                    "fair",
                    "homely",
                    "wiggly",
                    "thankful",
                    "ear" 
                })
            );
        }

        [Fact]
        public void CanGetDistanceInMiles() {
            Assert.Equal(10.00, instance.DistanceInMiles(16.00));
        }

        [Theory]
        [InlineData(1.6, 1)]
        [InlineData(0, 0)]
        [InlineData(-1.6, -1)]
        [InlineData(10.01, 6.256)]
        [InlineData(double.NaN, double.NaN)]
        public void CanGetDistanceInMilesParam(double km, double expected)
        {
            int precision = 3;
            var actual = instance.DistanceInMiles(km);
            Assert.Equal(expected, actual, precision);
        }
        [Fact]
        public void CanGetDistanceInKilometers() {
            Assert.Equal(16.00, instance.DistanceInKm(10.00));
        }

        [Theory]
        [InlineData(1,1.6)]
        [InlineData(0, 0)]
        [InlineData(-1,-1.6)]
        [InlineData(6.26,10.016)]
        [InlineData(double.NaN, double.NaN)]
        public void CanGetDistanceInKilometersParam(double m, double expected)
        {
            int precision = 3;
            var actual = instance.DistanceInKm(m);
            Assert.Equal(expected, actual, precision);
        }

        /// <summary>
        /// https://en.wikipedia.org/wiki/Palindrome
        /// </summary>
        [Fact]
        public void IsPalindrome() {
            var palindromes = new List<string> {
                "madaM","raCecAr","11/11/11","Anna"
            };

            var invalid = new List<string> {
                "Hello","This is not a Palindrome"
            };

            foreach (var word in palindromes)
            {
                Assert.True(instance.IsPalindrome(word));
            }

            foreach (var word in invalid) {
                Assert.False(instance.IsPalindrome(word));
            }
        }

        [Theory]
        [InlineData("two")]
        [InlineData("two", "one")]
        [InlineData("two", "one","three")]
        public void CanShuffle(params string[] input)
        {
            var actual = instance.Shuffle(input.ToList()).ToList();
            //NOTE: As with less than two items, shuffle might return same result
            if (input.Length > 2)
            {
                bool isEqual = actual.SequenceEqual(input);
                Assert.False(isEqual);
            }

            //NOTE: if sorted, both should be equal. Possibly Another test
            bool equalOrderBy = actual.OrderByDescending(x => x)
                .SequenceEqual(input.OrderByDescending(y => y));
            Assert.True(equalOrderBy);
        }

        [Theory]
        [InlineData(new []{7,1,5,2,4,3,6}, new []{1,2,3,4,5,6,7})]
        [InlineData(new[] { 7, 5,1, 2, 4, 3, 600 }, new[] { 1, 2, 3, 4, 5, 7,600 })]
        [InlineData(new[] { int.MaxValue,1,int.MinValue }, new[] { int.MinValue,1,int.MaxValue })]

        public void CanSort(int []data,int []expected) {
            Assert.Equal(expected, instance.Sort(data));
        }

        
        [Theory]
        [InlineData(2, 0)]
        [InlineData(8, 2)]
        [InlineData(4000000, 4613732)]
        public void CanSumFibonacciNumbers(int limit, int expected) {
            Assert.Equal(expected, instance.FibonacciSum(limit));
        }

        [Fact]
        public void CanGenerateListOfNumbers() {
            var list = instance.GenerateList();

            var current = 1;
            foreach (var num in list) {
                Assert.Equal(current, num);
                current++;
            }
        }
    }

    public class MyEqualityComparer: IEqualityComparer<List<string>>
    {
        public bool Equals(List<string> x, List<string> y)
        {
            var areEquivalent = y != null && (x != null && ((x.Count == y.Count) && !x.Except(y).Any()));
            return areEquivalent;
        }

        public int GetHashCode(List<string> obj)
        {
            return obj.GetHashCode();
        }
    }
}
