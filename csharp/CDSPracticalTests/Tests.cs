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
                "Rotor",
                "Radar",
                "mIniM",
                "cIviC",
            };
            var invalid = new List<string> {
                "random",
                "Craig",
                "This worn't work!"
            };

            Assert.NotEmpty(palindromes);

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

            Assert.Equal(new List<string> { "one", "two", "three", "four" }, instance.Shuffle(new List<string> {"three", "four", "one", "two" }));
            Assert.Equal(new List<string> { "one", "two", "three", "four", "five" }, instance.Shuffle(new List<string> { "four", "five", "one", "two", "three" }));

            int x = 5;
            int y = x / 2;
            System.Diagnostics.Debug.WriteLine(y);




        }

        [Fact]
        public void CanSort() {

            var sorted = new int[10];
            sorted[0] = 1;
            sorted[1] = 2;
            sorted[2] = 3;
            sorted[3] = 4;
            sorted[4] = 5;
            sorted[5] = 6;
            sorted[6] = 7;
            sorted[7] = 8;
            sorted[8] = 9;
            sorted[9] = 10;

            var unSorted = new int[10];
            unSorted[0] = 3;
            unSorted[1] = 10;
            unSorted[2] = 7;
            unSorted[3] = 2;
            unSorted[4] = 9;
            unSorted[5] = 1;
            unSorted[6] = 6;
            unSorted[7] = 4;
            unSorted[8] = 8;
            unSorted[9] = 5;

            Assert.Equal(sorted, instance.Sort(unSorted));


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
