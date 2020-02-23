using CDSPractical;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CDSPracticalTests
{
    public class Tests
    {
        private Questions instance = new Questions();

        [Fact]
        public void CanExtractNumbers()
        {
            Assert.Equal(new List<int> {
                123,
                234
            }, instance.ExtractNumbers(new List<string> {
                "123",
                "hello",
                "234"
            }));

            Assert.Equal(new List<int> { }, instance.ExtractNumbers(new List<string> {
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
        public void CanGetLongestCommonWord()
        {
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
        public void CanGetDistanceInMiles()
        {
            Assert.Equal(10.00, instance.DistanceInMiles(16.00));
        }

        [Fact]
        public void CanGetDistanceInKilometers()
        {
            Assert.Equal(16.00, instance.DistanceInKm(10.00));
        }

        [Fact]
        public void IsPalindrome()
        {
            var palindromes = new List<string>
            {
                "Anna",
                "Test1tset",
                "123$321"
            };
            var invalid = new List<string>
            {
                "bolton",
                "Test1test",
                "123$123"
            };

            foreach (var word in palindromes)
            {
                Assert.True(instance.IsPalindrome(word));
            }

            foreach (var word in invalid)
            {
                Assert.False(instance.IsPalindrome(word));
            }
        }

        [Fact]
        public void CanShuffle()
        {
            var initialList = new List<string> { "one", "two", "three", "four", "five" };
            var shuffledList = instance.Shuffle(initialList);

            Assert.False(initialList.SequenceEqual(shuffledList));
        }

        [Fact]
        public void CanSort()
        {
            int[] randomArray = { 7, 4, 2, 12, 8 };
            int[] sortedArray = { 2, 4, 7, 8, 12 };

            randomArray = instance.Sort(randomArray);

            Assert.True(sortedArray.SequenceEqual(randomArray));
        }

        [Fact]
        public void CanSumFibonacciNumbers()
        {
            Assert.Equal(4613732, instance.FibonacciSum());
        }

        [Fact]
        public void CanGenerateListOfNumbers()
        {
            var list = instance.GenerateList();

            var current = 1;
            foreach (var num in list)
            {
                Assert.Equal(current, num);
                current++;
            }
        }
    }
}