//Selection Sort
//find lowest value
//move it in front
// run n-1 times

using System;
					
public class Program
{
	public static void Main()
	{
		int[]x = {12, 7, 5 ,8,3};
		string[] words = {"pear", "apple", "orange", "banana"}; 
		
		
		SelectionSort2(x);
		SelectionSort(words); 
		SelectionSort1(x);
		
		
		foreach(int y in x){
			//Console.WriteLine(y);
		}
		
		foreach (string w in words)
		{ 
			//Console.WriteLine(w); 
		}
		
	}
	
	static void SelectionSort1(int[] x)
	{
		int n = x.Length;
		
		for(int i = 0; i < n-1; i++)
		{
			int minVal = x[i];
			for(int j = i + 1; j < n; j++)
			{
				if(minVal > x[j])
				{
					minVal = x[j];
					//Console.WriteLine(minVal); // i dont get this output 3,3,3,3,5,5,5,7,7,8
				}	
			}Console.WriteLine(minVal); // i dont get this output 3,5,7,8
		}
	}
	
	
	
	
	
	static void SelectionSort2(int[] x)
	{
		int n = x.Length;
	
		for(int i = 0; i < n - 1; i++) //01234 < 4
		{
			int minIndex = i;
			
			for(int j = i +1; j < n; j++) // 01234 < 4
			{
				if(x[minIndex] > x[j])
				{
					minIndex = j;
				}
			}
			int temp = x[minIndex];
			x[minIndex] = x[i];
			x[i] = temp;
		}
	}
	


    static void SelectionSort(string[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                // Compare strings lexicographically
                if (string.Compare(arr[j], arr[minIndex]) < 0)
                {
                    minIndex = j;
                }
            }

            // Swap
            string temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
    }


}