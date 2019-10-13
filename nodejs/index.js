/// Given an enumerable of strings, attempt to parse each string and if
/// it is an integer, add it to the returned enumerable.
///
/// For example:
///
/// extractNumbers(["123", "hello", "234"]);
///
/// ; would return:
///
/// [
///   123,
///   234
/// ]
///
const extractNumbers = (source) => {
	var extractedNumbers = [];
	for (let i = 0; i < source.length; i++) {
		if (!isNaN(source[i])) {
			extractedNumbers.push(Number(source[i]));
		}
	}

	return extractedNumbers;
};

/// Given two enumerables of strings, find the longest common word.
///
/// For example:
///
/// longestCommonWord(
///     [
///         "love",
///         "wandering",
///         "goofy",
///         "sweet",
///         "mean",
///         "show",
///         "fade",
///         "scissors",
///         "shoes",
///         "gainful",
///         "wind",
///         "warn"
///     ],
///     [
///         "wacky",
///         "fabulous",
///         "arm",
///         "rabbit",
///         "force",
///         "wandering",
///         "scissors",
///         "fair",
///         "homely",
///         "wiggly",
///         "thankful",
///         "ear"
///     ]
/// );
///
/// ; would return "wandering" as the longest common word.
const longestCommonWord = (first, second) => {
	let longestCommonWordLength = 0;
	let longestCommonWord = null;

	for (let i = 0; i < first.length; i++) {
		for (let j = 0; j < second.length; j++) {
			if (first[i] === second[j] && first[i].length > longestCommonWordLength) {
				longestCommonWord = first[i];
				longestCommonWordLength = first[i].length;
			}
		}
	}

	return longestCommonWord;
};

/// Write a method that converts kilometers to miles, given that there are
/// 1.6 kilometers per mile.
///
/// For example:
///
/// distanceInMiles(16);
///
/// ; would return 10;
const distanceInMiles = (kilometers) => {
	return kilometers / 1.6;
};

/// Write a method that converts miles to kilometers, give that there are
/// 1.6 kilometers per mile.
///
/// For example:
///
/// distanceInKm(10);
///
/// ; would return 16;
const distanceInKm = (miles) => {
	return miles * 1.6;
};

/// Write a method that returns true if the word is a palindrome, false if
/// it is not.
///
/// For example:
///
/// isPalindrome("bolton");
///
/// ; would return false, and:
///
/// isPalindrome("Anna");
///
/// ; would return true.
///
/// Also complete the related test case for this method.
const isPalindrome = (word) => {
	let strLen = word.length;
	word = word.toLocaleLowerCase();

	for (let i = 0; i < strLen / 2; i++) {
		if (word[i] !== word[strLen - i - 1]) {
			return false;
		}
	}
	return true;
};

/// Generate a list of integers from 1 to 100.
///
/// This method is currently broken, fix it so that the tests pass, without
/// removing the function call that inserts the number.
const generateList = () => {
	var list = new Array();
	var funcs  = new Array();
	for (var i = 1; i <= 100; i++) {
		funcs.push(function(){
			let index = i;
			list.push(index);
		});
	};
	funcs.map((f) => f());
	return list;
};

module.exports = {
	extractNumbers 		: extractNumbers,
	longestCommonWord 	: longestCommonWord,
	distanceInMiles 	: distanceInMiles,
	distanceInKm 		: distanceInKm,
	isPalindrome 		: isPalindrome,
	generateList 		: generateList
};