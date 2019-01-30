using System;
using System.Linq;

namespace CDSPractical.Helpers
{
    public static class Converters
    {
	    private static double KmMileConversionRate = 1.6;

	    public static double ConvertKMtoMiles(double distance)
	    {
		    return distance / KmMileConversionRate;
	    }

	    public static double ConvertMilesToKM(double distance)
	    {
		    return distance * KmMileConversionRate;
	    }

	    public static string ReverseWord(string word)
	    {
			return new string(word.Reverse().ToArray());
		}

	    public static bool NumberIsEVen(int number)
	    {
		    return number % 2 == 0;

	    }
	}
}
