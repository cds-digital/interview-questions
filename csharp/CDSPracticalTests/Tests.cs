using CDSPractical;
using System;
using System.Collections.Generic;
using Xunit;

namespace CDSPracticalTests {
    public class Tests {
       
        #region Arrange
        Questions instance = new Questions();
        #endregion

        #region UnitTests
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

            Assert.Equal(new List<int> {
                
            }, instance.ExtractNumbers(new List<string> {
                "hello",
                "there"
                
            }));
        }

        
        [Fact]
        public void CanGetLongestCommonWord() {
            Assert.Equal("wanderlust", instance.LongestCommonWord(
                new List<string> {
                    "love",
                    "wandering",
                    "wanderlust",
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
                    "WanderLust",
                    string.Empty,
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
                "Anna","Nayan","Kayak","rotor"
                
            };
            var invalid = new List<string> {
                "Annaa","yujsa" ,"IamNotPalindrome"
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


        [Trait("Categories", "Unit")]
        [Theory]
        [MemberData(nameof(TestDataForCanShort))]
        public void CanSort(int[] input, int[] expected) {

            //act
           var output=  instance.Sort(input);
            //assert
           Assert.Equal(expected, output);
            
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
        #endregion

        #region MemberData
        public static IEnumerable<object[]> TestDataForCanShort =>
        new List<object[]>
        {
            new object[] { new int[] { 1, 3, 4, 2 }, new int[] { 1, 2, 3, 4 } },
            new object[] { new int[] { 5, 4, 8, 2 }, new int[] { 2, 4, 5, 8 } },
            new object[] { new int[] { }, new int[] { } },
        };
        #endregion
    }
}
