using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
			var myArray = new MergeSort();

			Console.WriteLine("Before sorting:  {0}", myArray);
			Console.WriteLine("");

			myArray.Sort();		// perofrm the sort

			Console.WriteLine("After sorting:  {0}", myArray);

			System.Threading.Thread.Sleep(100000);

		}
    }
}
