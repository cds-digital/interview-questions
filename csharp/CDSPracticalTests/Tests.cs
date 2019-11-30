using CDSPractical;
using System;
using System.Collections.Generic;
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
                "mum", "refer", "dad"
            };
            var invalid = new List<string> {
                "this", "list", "is", "invalid"
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
            Assert.Equal(new List<string> { "one", "two" }, instance.Shuffle(new List<string> { "two", "one" }));
        }

        [Fact]
        public void CanSort() {
            Assert.Equal(instance.Sort(new int[] { 4, 7, 11 }), instance.Sort(new int[] { 11, 4, 7 }));
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
