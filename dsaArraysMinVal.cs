using System;
					
public class Program
{
	static int[] x = {121,21,33,46,57,29}; 
	
	public static void Main()
	{
		MinVal(x);

	}
	
	static void MinVal(int[] x)
	{
		int low = x[0];
		foreach(int num in x)
		{
			if(num < low){
			low = num;
			}
		}	
		Console.WriteLine($"Lowest value:{low}");
	}
}


/*

using System;
					
public class Program
{
	static int[] x = {11,21,33,46,57,29}; 
	
	public static void Main()
	{
		MinVal(x);
		Console.WriteLine(x);
	}
	
	static void MinVal(int[] x)
	{
		int low = x[0];
		foreach(int num in x)
		{
			if(num < low){
			low = num;
			}
		}	
	}
}

here i have a problem why does it display the system int32
Ah, I see exactly what’s happening here 👀

When you call:

csharp
Console.WriteLine(x);
you’re trying to print the entire array x. In C#, arrays don’t override ToString(). So instead of printing the contents, it prints the type name:
System.Int32[]

That’s why you see that output—it’s just telling you “this is an array of integers,” not the values inside.

How to fix it
If you want to display the minimum value you found, you need to actually return or print low from your MinVal method:

csharp
using System;

public class Program
{
    static int[] x = {11,21,33,46,57,29}; 
    
    public static void Main()
    {
        int min = MinVal(x);
        Console.WriteLine(min); // prints the minimum value
    }
    
    static int MinVal(int[] x)
    {
        int low = x[0];
        foreach(int num in x)
        {
            if(num < low){
                low = num;
            }
        }
        return low; // return the minimum
    }
}
This will correctly print 11.

If you want to print the whole array
Use string.Join:

csharp
Console.WriteLine(string.Join(", ", x));
That will display:
11, 21, 33, 46, 57, 29

So the key idea is: printing an array directly shows its type, not its contents. You either need to loop through it, use string.Join, or print specific values like the minimum.

Would you like me to show you a step-by-step annotated version where the program prints both the array contents and the minimum value side by side?


Nice work, Charls! 🎯 You nailed the fix—by moving the Console.WriteLine inside MinVal and printing low, you’re now showing the actual minimum value instead of the array type name.

A couple of small refinements you might find useful:

Return the value instead of printing inside the method  
This makes MinVal more reusable. For example:

csharp
static int MinVal(int[] x)
{
    int low = x[0];
    foreach(int num in x)
    {
        if(num < low){
            low = num;
        }
    }
    return low; // return instead of printing
}

public static void Main()
{
    int min = MinVal(x);
    Console.WriteLine($"Lowest value: {min}");
}
That way, you can use the minimum in other calculations later, not just print it.

Print the whole array alongside the result  
If you want to see the context:

csharp
Console.WriteLine($"Array: {string.Join(", ", x)}");
Console.WriteLine($"Lowest value: {min}");
Output:
Array: 121, 21, 33, 46, 57, 29  
Lowest value: 21

You’ve already solved the core issue perfectly. This tweak just makes your method more flexible and shows good practice for reusability.

Do you want me to show you a step-by-step annotated breakdown of how the program flows (array → loop → comparison → result), almost like a debug trace? That could help you visualize the logic more clearly.

*/