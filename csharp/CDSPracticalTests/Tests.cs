using CDSPractical;
using System.Collections.Generic;
using Xunit;

/// <summary>
/// 
/// </summary>
namespace CDSPracticalTests
{
    /// <summary>
    /// 
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// 
        /// </summary>
        Questions instance = new Questions();

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void CanGetDistanceInMiles()
        {
            Assert.Equal(10.00, instance.DistanceInMiles(16.00));
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void CanGetDistanceInKilometers()
        {
            Assert.Equal(16.00, instance.DistanceInKm(10.00));
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void IsPalindrome()
        {
            var palindromes = new List<string> { };
            var invalid = new List<string> { };

            foreach (var word in palindromes)
                Assert.True(instance.IsPalindrome(word));

            foreach (var word in invalid)
                Assert.False(instance.IsPalindrome(word));
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void CanShuffle()
        {
            Assert.Equal(new List<string> { "two", "one" }, instance.Shuffle(new List<string> { "one", "two" }));
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void CanSort()
        {
            Assert.Equal(new int[] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 }, instance.Sort(new int[] { 45, 50, 20, 35, 40, 10, 25, 15, 5, 30 }));
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void CanSumFibonacciNumbers()
        {
            Assert.Equal(4613732, instance.FibonacciSum());
        }

        /// <summary>
        /// 
        /// </summary>
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
