const instance = require('./index');

describe("A set of functions", () => {
	it("can extract numbers", () => {
		let result = instance.extractNumbers(["123", "hello", "234"]);
		expect(result[0]).toEqual(123);
		expect(result[1]).toEqual(234);

		result = instance.extractNumbers(["hello", "there"]);
		expect(result.length).toEqual(0);

		result = instance.extractNumbers(["hello", "there", "123", "234.23", "345"]);
		expect(result[0]).toEqual(123);
		expect(result[1]).toEqual(234.23);
		expect(result[2]).toEqual(345);
	});

	it("can get the longest common word", () => {
		let result = instance.longestCommonWord(
			[
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
	     	],
			[
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
	     	]
		);

		expect(result).toEqual("wandering");
	});

	it("can convert kilometers into miles", () => {
		let result = instance.distanceInMiles(16);
		expect(result).toEqual(10);
	});

	it("can convert miles into kilometers", () => {
		let result = instance.distanceInKm(10);
		expect(result).toEqual(16);
	});

	it("can correctly detect palindromes", () => {
		let palindromes = [];
		let invalid = [];

		palindromes.forEach((p) => {
			expect(instance.isPalindrome(p)).toEqual(true);
		});

		invalid.forEach((i) => {
			expect(instance.isPalindrome(i)).toEqual(false);
		});
	});

	it("can generate a list of numbers", () => {
		let list = instance.generateList();
		let current = 1;
		list.forEach((num) => {
			expect(num).toEqual(current);
			current++;
		});
	});
});