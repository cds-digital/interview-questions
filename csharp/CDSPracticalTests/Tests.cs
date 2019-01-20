using CDSPractical;
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CDSPracticalTests {
    public class Tests {
        Questions instance = new Questions();

        [TestCase(new string[] { "123", "hello", "234" }, new int[] { 123, 234 })]
        [TestCase(new string[] { "hello", "there" }, new int[] { })]
        [TestCase(new string[] { "hello", "there", "123", "234.23", "345" }, new int[] { 123, 345 })]
        public void CanExtractNumbers(IEnumerable<string> inputStrings, IEnumerable<int> parsedIntegers) {
            Assert.AreEqual(parsedIntegers, instance.ExtractNumbers(inputStrings));
        }

        [TestCase(new string[] { "love", "goofy", "sweet", "mean", "show", "fade", "scissors", "shoes", "gainful", "wind", "warn" },
            new string[] { "wacky", "fabulous", "arm", "rabbit", "force", "wandering", "scissors", "fair", "homely", "wiggly", "thankful", "ear" }, "scissors")]
        [TestCase(new string[] { }, new string[] { }, "")]
        [TestCase(null, new string[] { }, "")]
        public void CanGetLongestCommonWord(IEnumerable<string> first, IEnumerable<string> second, string expectedLongest) {
            //taking wandering out of the first list and requiring result of scissors is a nicer test 
            //as we ensure the implementation considers the requirement that the word appears in both lists, not just getting the longest word in either.
            //as it stood, you could implement the method incorrectly and the test would still pass.
            Assert.AreEqual(expectedLongest, instance.LongestCommonWord(first, second));
        }

        [TestCase(16.00, 10.00)]
        [TestCase(21.00, 13.125)]
        [TestCase(22.998, 14.37375)]
        [TestCase(22.98456874, 14.3653554625)]
        [TestCase(22.45718789858458d, 14.035742436615362d)]
        public void CanGetDistanceInMiles(double km, double expectedMiles) {
            Assert.AreEqual(expectedMiles, instance.DistanceInMiles(km));
        }

        [TestCase(10.00, 16.00)]
        [TestCase(13.125, 21.00)]
        [TestCase(14.37375, 22.998)]
        [TestCase(14.3653554625, 22.98456874)]
        [TestCase(14.035742436615362d, 22.45718789858458d)]
        public void CanGetDistanceInKilometers(double miles, double expectedKm) {
            Assert.AreEqual(expectedKm, instance.DistanceInKm(miles));
        }

        [TestCase("Hannah", true)]
        [TestCase("Redivider", true)]
        [TestCase("DAD", true)]
        [TestCase("Mum", true)]
        [TestCase("Boris Johnson", false)]
        [TestCase("Donald Trump", false)]
        public void IsPalindrome(string test, bool expectedOutcome) {
            Assert.AreEqual(instance.IsPalindrome(test), expectedOutcome);
        }

        [Test]
        public void CanShuffle() {
            Assert.AreEqual(new List<string> { "one" }, instance.Shuffle(new List<string> { "one" }));
            Assert.AreEqual(new List<string> { "two", "one" }, instance.Shuffle(new List<string> { "one", "two" }));
            Assert.AreNotEqual(new List<string> { "one", "two", "three" }, instance.Shuffle(new List<string> { "one", "two", "three" }));
            List<Person> people = new List<Person> { new Person { Name = "Bowser", Age = 21 }, new Person { Name = "Skinner", Age = 57 } };
            Assert.AreNotEqual(people, instance.Shuffle(people));
        }

        [TestCase(new int[] { 5, 3, 2, 4, 1 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 5, 3, 2, 5, 4 }, new int[] { 1, 2, 2, 3, 4, 5, 5 })]
        [TestCase(new int[] { }, new int[] { })]
        public void CanSort(int[] unsorted, int[] sorted) {
            Assert.AreEqual(sorted, instance.Sort(unsorted));
        }

        [Test]
        public void CanSumFibonacciNumbers() {
            Assert.AreEqual(4613732, instance.FibonacciSum());
        }

        [Test]
        public void CanGenerateListOfNumbers() {
            var list = instance.GenerateList();

            var current = 1;
            foreach (var num in list) {
                Assert.AreEqual(current, num);
                current++;
            }
        }
    }
}
