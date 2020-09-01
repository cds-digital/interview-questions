using CDSPractical;
using System;
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

        [Fact]
        public void CanGetDistanceInKilometers() {
            Assert.Equal(16.00, instance.DistanceInKm(10.00));
        }

        [Fact]
        public void IsPalindrome() {
            var palindromes = new List<string> {
                "Anna",
                "nitin"
            };
            var invalid = new List<string> {
                "arun",
                "Heema"
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
            int[] arr = { 2, 3, 1, 5, 6, 8 };
            var shortedArr = instance.Sort(arr);
            Assert.True(shortedArr.SequenceEqual(arr.OrderBy(m => m)));
            
            int[] arr1 = { 12, 43, 11, 25, 9, 10 };
            var shortedArr1 = instance.Sort(arr1);
            Assert.True(shortedArr1.SequenceEqual(arr1.OrderBy(m => m)));
            
            int[] arr2 = { 24, 31, 12, 54, 66, 89 };
            var shortedArr2 = instance.Sort(arr2);
            Assert.True(shortedArr2.SequenceEqual(arr2.OrderBy(m => m)));
        }

        [Fact]
        public void CanSumFibonacciNumbers() {
            Assert.Equal(144, instance.FibonacciSum());
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
