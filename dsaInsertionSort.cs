using System;
					
public class Program
{
	public static void Main()
	{
		InsertionSort();
	}
	
	static void InsertionSort()
	{
		int[] arr = [1,23,4,11,8];// should have been {} this not [] sorry long time not touching c#
		
		for(int i = 0; i < arr.Length; i++)
		{
			for(int j = i; j >  0; j--)
			{
				if(arr[j] < arr[j-1])
				{
					int temp = arr[j-1];
					arr[j-1] = arr[j];
					arr[j] = temp;
				}
			}
		}
				foreach(int num in arr)
				{
					Console.WriteLine(num);
				}
	}
}