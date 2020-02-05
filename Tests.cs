using CDSPractical;
using System.Collections.Generic;
using Xunit;

namespace CDSPracticalTests
{
    public class Tests
    {
        private readonly Questions instance = new Questions();

        [Fact]
        public void CanExtractNumbers1()
        {
            Assert.Equal(new List<int> {
                123,
                234
            }, instance.ExtractNumbers(new List<string> {
                "123",
                "hello",
                "234"
            }));
        }

        [Fact]
        public void CanExtractNumbers2()
        {
            Assert.Equal(new List<int> { }, instance.ExtractNumbers(new List<string> {
                "hello",
                "there"
            }));

        }
        [Fact]
        public void CanExtractNumbers3()
        {
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

        /// <summary>
        /// Split the True and False assetts into separate unit tests.
        /// </summary>
        /// <param name="word"></param>
        [Theory]
        [InlineData("Anna")]
        [InlineData("radar")]
        public void WordIsPalindrome(string word)
        {
            Assert.True(instance.IsPalindrome(word));
        }

        [Theory]
        [InlineData("bolton")]
        [InlineData("qwertyuiop")]
        public void WordIsNotPalindrome(string word)
        {
            Assert.False(instance.IsPalindrome(word));
        }

        [Fact]
        public void CanShuffle()
        {
            Assert.Equal(new List<string> { "two", "one" }, instance.Shuffle(new List<string> { "one", "two" }));
        }

        [Fact]
        public void CanSort()
        {
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, instance.Sort(new[] { 5, 3, 4, 1, 2 }));
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
