using CDSPractical;
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
            var palindromes = new List<string>
            {
	            " Civic",
	            "Deified",
	            "Level",
	            "Racecar",
	            "Lemel",
	            "Madam",
	            "Minim",
	            "Murdrum",
	            "Mum",
	            "Radar",
	            "nOOn",
	            "Refer",
	            "rotator",
	            "sagas",
	            "Wow ",
	            "a"
            };
            var invalid = new List<string> {
				"already",
	            "analysis",
	            "Daughter",
	            "if",
	            "Bee",
	            "Design",
	            "Car",
	            "Bill",
	            "Radar1",
	            "Radars" ,
	            "Race car"
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
	    public void CanShuffleLarger(){
		    var originalList = new List<string> { "one", "two", "Three", "Four", "Five", "Six", "Seven"};
		    var shuffledList = instance.Shuffle(originalList).ToList();
		    var lastElement = originalList.Count - 1;

			for (var i = 0; i < lastElement; ++i)
			{
				Assert.NotEqual(originalList[i], shuffledList[i]);
			}
	    }

		[Fact]
        public void CanSort() {
			int[] arrangedArray = Enumerable.Range(1, 100).ToArray();
			int[] unarrangedArray = new int[] {63,91,71,83,94,34,51,37,8,39,58,55,22,74,50,89,73,60,9,100,52,26,48,70,4,88,81,7,15,14,99,87,6,19,
			18,45,12,68,28,3,5,40,61,96,80,57,2,35,30,98,86,85,95,59,42,23,79,49,72,20,24,78,56,41,75,31,65,62,43,93,69,44,17,82,84,11,
			67,77,33,16,36,21,66,92,1,32,64,38,76,90,53,27,13,25,54,97,46,10,29,47};

			Assert.Equal(arrangedArray, instance.Sort(unarrangedArray));
		}

        [Fact]
        public void CanSumFibonacciNumbers() {
            Assert.Equal(4613732, instance.FibonacciSum(4000000));
        }

        [Fact]
        public void CanGenerateListOfNumbers() {
            var list = instance.GenerateList(100);

            var current = 1;
            foreach (var num in list) {
                Assert.Equal(current, num);
                current++;
            }
        }
    }
}
