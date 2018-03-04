using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    class MergeSort
	{
		private Random randomNumberGenerator;
		private int N = 100;		// number of elements in list
		private bool showSteps = false;	// turn on printing for debug
		private int[] list;

		/// <summary>
		/// Create a list of integers of size N.
		/// </summary>
		public MergeSort()
		{
			list = new int[N];
			randomNumberGenerator = new Random();

			for (int i = 0; i < N; i++)
			{
				list[i] = randomNumberGenerator.Next(0, 100);
			}
		}

		public void Sort()
		{
			SortArray(0, list.Length - 1);	// sort the entire array by calling SortArray recursively
		}

		private void SortArray(int lower, int upper)
		{
			// test for base case - size of array is one
			if ((upper - lower) >= 1)	// true - not the base case
			{
				int middle = (lower + upper) / 2;	// get middle of the array
				int nextToMiddle = middle + 1;      // move right one element

				if (showSteps == true)
				{
					Console.WriteLine("Array:	" + SubArray(lower, upper));
					Console.WriteLine("      	" + SubArray(lower, middle));
					Console.WriteLine("      	" + SubArray(nextToMiddle, upper));
					Console.WriteLine();
				}

				// split the array in half then sort each half recursively
				SortArray(lower, middle);
				SortArray(nextToMiddle, upper);

				// merge the 2 sorted arrays
				Merge(lower, middle, nextToMiddle, upper);
			}
		}   // end of SortArray

		private void Merge(int left, int endOfLeft, int startOfRight, int right)
		{
			int leftIndex = left;   // start of left subarray
			int rightIndex = startOfRight;  // start of right subarray
			int mergedIndex = left;     // start of the temporary array
			int[] mergedArray = new int[list.Length];   // consolidating array

			if (showSteps == true)
			{
				Console.WriteLine("merge:	" + SubArray(left, endOfLeft));
				Console.WriteLine("      	" + SubArray(startOfRight, right));
			}

			// merge the arrays until either reaches its end
			while (leftIndex <= endOfLeft && rightIndex <= right)
			{
				// grab the smaller of the items from either array and adjust index to next position
				if (list[leftIndex] <= list[rightIndex])
				{
					mergedArray[mergedIndex++] = list[leftIndex++];
				}
				else
				{
					mergedArray[mergedIndex++] = list[rightIndex++];
				}
			}   // end of while

			if (leftIndex == startOfRight) // empty?
			{
				while (rightIndex <= right)
				{
					mergedArray[mergedIndex++] = list[rightIndex++];
				}
			}
			else	// right is empty
			{
				while (leftIndex <= endOfLeft)
				{
					mergedArray[mergedIndex++] = list[leftIndex++];
				}
			}

			// return the values back into the org array
			for (int i = left; i <= right; i++)
			{
				list[i] = mergedArray[i];
			}

			if (showSteps == true)
			{
				Console.WriteLine("      	" + SubArray(left, right));
				Console.WriteLine();
			}
		}   // end of Merge()

		public string SubArray(int low, int high)	// provides spacing when printing each step
		{
			string tempStr = string.Empty;

			for (int i = 0; i < low; i++) {		// add alignment spaces
				tempStr += "   ";
			}

			for (int i = low; i <= high; i++)
			{       // add items remaining in the array
				tempStr += " " + list[i];
			}
			return tempStr;
		}   // end of SubArray()

		public override string ToString()
		{
			return SubArray(0, list.Length - 1);
		}	// end of ToString()
	}	// end of class MergeSort
}
