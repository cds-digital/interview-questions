using System.Collections.Generic;

namespace CDSPractical.Extensions
{
	public static class ListExtensions
	{
		/// <summary>
		/// Shuffles the order of a list ensuring no item is in its original position
		/// </summary>
		public static void Shuffle<T>(this IList<T> list)
		{
			var count = list.Count;
			var last = count - 1;
			var randomGenerator = new System.Random();
			for (var i = 0; i < last; ++i)
			{
				var r = randomGenerator.Next(i, count);

				while (r == i)
				{
					r = randomGenerator.Next(i, count);
				}

				var temp = list[i];
				list[i] = list[r];
				list[r] = temp;
			}
		}		
	}

}
