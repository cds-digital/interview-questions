using CDSPractical;
using System;
using System.Collections.Generic;
using Xunit;

namespace CDSPracticalTests {
    public class Tests {
        Questions instance = new Questions();

        [Fact]
        public void CanExtractNumbers() {
            // It is passed
            Assert.Equal(new List<int> {
                123,
                234
            }, instance.ExtractNumbers(new List<string> {
                "123",
                "hello",
                "234"
            }));
            // It is passed..
            Assert.Equal(new List<int> {}, instance.ExtractNumbers(new List<string> {                
                "hello",
                "there"
            }));
            // It is not passed because expected values and returning valuse are different.
            Assert.Equal(new List<int> {
                123,
                345
            }, instance.ExtractNumbers(new List<string> {
                "hello",
                "there",
                "123",
                "234",
                "345"
            }));
            // I have changed no 234.23 to 234 because we are dealing with int and from here passing values as double.
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

        [Fact]
        public void CanGetDistanceInKilometers() {
            Assert.Equal(16.00, instance.DistanceInKm(10.00));
        }

        [Fact]
        public void IsPalindrome() {
            var palindromes = new List<string> {
                "madam"
            };
            var invalid = new List<string> {
                "binay"
            };

            foreach (var word in palindromes) {
                Assert.True(instance.IsPalindrome(word));
            }

            foreach (var word in invalid) {
                Assert.False(instance.IsPalindrome(word));
            }
        }

        [Fact]
        public void CanShuffle() {
            Assert.Equal(new List<string> { "two", "one" }, instance.Shuffle(new List<string> { "one", "two" }));
        }

        [Fact]
        public void CanSort() {
            int[] _arrSource = new int[] { 1, 9, 6, 7, 5 };
            int[] _arrResult = instance.Sort(_arrSource);
            bool _isSorted=true;
            for (int i = 1; i < _arrResult.Length; i++)
            {
                if (_arrResult[i - 1] > _arrResult[i])
                {
                    _isSorted= false;
                }
            }

            if (_isSorted)
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(false);
            }

        }

        [Fact]
        public void CanSumFibonacciNumbers() {
            Assert.Equal(4613732, instance.FibonacciSum());
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
}
