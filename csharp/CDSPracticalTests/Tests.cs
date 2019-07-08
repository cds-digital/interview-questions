using CDSPractical;
using System;
using System.Collections.Generic;
using Xunit;

namespace CDSPracticalTests
{
    public class Tests
    {
        Questions instance = new Questions();

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
            var palindromes = new List<string> {"Anna","eye","Level","Noon"

            };
            var invalid = new List<string> {"bolton","Good", "Start"

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
            Assert.Equal(new List<string> { "two", "one" }, instance.Shuffle(new List<string> { "one", "two" }));

            Assert.NotEqual(new List<object> { 1, 2, 3, 4 }, instance.Shuffle(new List<object> { 1, 2, 3, 4 }));

        }

        [Fact]
        public void CanSort()
        {
            const int Size = 20;

            Assert.Equal(new int[] { 1, 2 }, instance.Sort(new int[] { 2, 1 }));
            Assert.Equal(new int[] { 1, 1, 2 }, instance.Sort(new int[] { 1, 2, 1 }));
            Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, instance.Sort(new int[] { 5, 4, 3, 2, 1 }));

            Assert.Equal(new int[] { 2, 4, 9, 11, 23, 47, 54, 57, 61, 64, 67, 93 }, instance.Sort(new int[] { 4, 54, 64, 23, 67, 47, 93, 57, 9, 61, 2, 11 }));

            Random random = new Random();
            var list = new int[Size];
            var listCopy = new List<int>();
            int number;
            for (int index = 0; index < Size; index++)
            {
                number = random.Next();
                list[index] = number;
                listCopy.Add(number);
            }

            listCopy.Sort();

            Assert.Equal(listCopy, instance.Sort(list));
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
