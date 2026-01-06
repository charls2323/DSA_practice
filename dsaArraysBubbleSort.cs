using System;
					
public class Program
{
	public static void Main()
	{
		int[] x = {19, 7, 64, 99, 23, 10, 11,98, 97};
		
		BubbleSort(x);
	}
	
	static void BubbleSort(int[] x)
	{
		int noOfItems = 0;
		int n = x.Length;
		int time = 0;
	
		foreach(int no in x){
			noOfItems++;
		}
		
		for(int i = 0; i < n - 1; i++){
			for(int j = 0; j < n  - 1; j++){
				if(x[j] > x[j+1]){
				int temp = x[j];
				x[j] = x[j+1];
				x[j+1] = temp;
				}
			}
			//Console.WriteLine(x[i]);
		}
		
		
		
		
		
		
		/*
			for(int i = 0; i < noOfItems-1; i++){
			if(x[i] > x[i+1]){
				temp = x[i+1];
				x[i+1] = x[i];
				x[i] = temp;
				temp = x[i+1];
			}
			time++;
		}
		*/
		
		foreach(int print in x){
			Console.WriteLine(print);
		}

		
		/*
		foreach(int i in x)
		{
			foreach(int j in  x )
			{
				if(i < prev){
					prev = i;
			}
				Console.WriteLine(i);
		}
		*/
			
			/*
			foreach(int print in x)
			{
				Console.WriteLine(print);
			}
			*/
	}	
}

/*

int[] no = {2,3,1};
        
        for(int i = 0; i < no.Length; i++){
            for(int j = 0; j < no.Length - i - 1; j++){
                
                if(no[j] > no[j+1]){
                    
                int temp = no[j];
                no[j] = no[j+1];
                no[j+1] = temp;
                }
            }
        }
        foreach(int num in no){
           Console.WriteLine(num);
        }

*/


/*


ssues in your code
Console.WriteLine(x); is wrong

x is the entire array object, not the individual element. Printing x will just show the type name (System.Int32[]) instead of the values.

You need to print the element (print) instead.

csharp
Console.WriteLine(print);
Your "BubbleSort" logic isn’t actually sorting

Bubble Sort requires swapping adjacent elements repeatedly until the array is sorted.

Your code only compares num with prev but never swaps elements in the array.

Nested loops are misused

You’re looping with foreach, which doesn’t allow swapping because foreach gives read-only access to elements.

Bubble Sort needs for loops with indices so you can swap values.

Correct Bubble Sort Implementation
Here’s a working version of Bubble Sort in C#:

csharp
using System;

public class Program
{
    public static void Main()
    {
        int[] x = {19, 7, 64, 99, 23, 10, 11};
        
        BubbleSort(x);

        // Print sorted array
        foreach (int num in x)
        {
            Console.WriteLine(num);
        }
    }
    
    static void BubbleSort(int[] x)
    {
        int n = x.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (x[j] > x[j + 1])
                {
                    // Swap
                    int temp = x[j];
                    x[j] = x[j + 1];
                    x[j + 1] = temp;
                }
            }
        }
    }
}
Output
For your array {19, 7, 64, 99, 23, 10, 11}, the sorted result will be:

Code
7
10
11
19
23
64
99
👉 The key fixes are:

Use Console.WriteLine(print) instead of Console.WriteLine(x).

Implement proper swapping logic with indexed for loops.

Would you like me to also show you a step-by-step trace of Bubble Sort on your array so you can see how the values move around at each pass?

can you expllain it to me buble sort algorithm in step by step implementation
See my thinking
Bubble sort overview
Bubble sort repeatedly compares adjacent elements and swaps them if they’re out of order. After each full pass, the largest remaining element “bubbles” to its correct position at the end. We keep doing passes until no swaps happen, meaning the array is sorted.

Core idea with adjacent comparisons and swaps
Adjacency: Compare element at index j with index j + 1.

Swap rule: If x[j] > x[j + 1], swap them.

Pass boundary: After pass i, the last i + 1 elements are in final position.

Early exit: If a pass makes zero swaps, the array is already sorted.

Step-by-step implementation in C#
csharp
static void BubbleSort(int[] x)
{
    int n = x.Length;

    // Outer loop = how many passes we make
    for (int i = 0; i < n - 1; i++)
    {
        bool swapped = false; // track if any swap happened in this pass

        // Inner loop = compare adjacent pairs up to the unsorted boundary
        for (int j = 0; j < n - i - 1; j++)
        {
            // If the left element is greater, move it right by swapping
            if (x[j] > x[j + 1])
            {
                int temp = x[j];
                x[j] = x[j + 1];
                x[j + 1] = temp;

                swapped = true;
            }
        }

        // If no swaps happened, array is sorted; break early
        if (!swapped) break;
    }
}
Outer loop (i): Counts passes. Each pass places one largest element at the end.

Inner loop (j): Walks the unsorted part, doing adjacent comparisons.

swapped flag: Saves time when the array becomes sorted before finishing all passes.

Walkthrough on your array
We’ll sort: [19, 7, 64, 99, 23, 10, 11]

Pass 1 (i = 0)
Compare 19 and 7 → swap → [7, 19, 64, 99, 23, 10, 11]

Compare 19 and 64 → no swap

Compare 64 and 99 → no swap

Compare 99 and 23 → swap → [7, 19, 64, 23, 99, 10, 11]

Compare 99 and 10 → swap → [7, 19, 64, 23, 10, 99, 11]

Compare 99 and 11 → swap → [7, 19, 64, 23, 10, 11, 99]

Largest element 99 is now at the end (correct position).

Pass 2 (i = 1)
Compare 7 and 19 → no swap

Compare 19 and 64 → no swap

Compare 64 and 23 → swap → [7, 19, 23, 64, 10, 11, 99]

Compare 64 and 10 → swap → [7, 19, 23, 10, 64, 11, 99]

Compare 64 and 11 → swap → [7, 19, 23, 10, 11, 64, 99]

Second largest (64) is placed before 99.

Pass 3 (i = 2)
Compare 7 and 19 → no swap

Compare 19 and 23 → no swap

Compare 23 and 10 → swap → [7, 19, 10, 23, 11, 64, 99]

Compare 23 and 11 → swap → [7, 19, 10, 11, 23, 64, 99]

23 moves into position before 64 and 99.

Pass 4 (i = 3)
Compare 7 and 19 → no swap

Compare 19 and 10 → swap → [7, 10, 19, 11, 23, 64, 99]

Compare 19 and 11 → swap → [7, 10, 11, 19, 23, 64, 99]

19 settles into place.

Pass 5 (i = 4)
Compare 7 and 10 → no swap

Compare 10 and 11 → no swap

Compare 11 and 19 → no swap

No swaps: array is sorted. We can break early.

Final result: [7, 10, 11, 19, 23, 64, 99]

Printing the sorted values
Use a foreach after sorting to print each element:

csharp
int[] x = {19, 7, 64, 99, 23, 10, 11};
BubbleSort(x);

foreach (int num in x)
{
    Console.WriteLine(num);
}
Common pitfalls (and quick fixes)
Printing the array object instead of elements:  
Use Console.WriteLine(num) or string.Join(", ", x); don’t print x directly.

Using foreach for sorting:  
foreach is read-only; use indexed for loops to swap.

Forgetting the inner loop boundary:  
Limit with n - i - 1 so you don’t re-check the sorted tail.

No early exit:  
Add swapped to stop once sorted.

If you want, I can show a version that logs every comparison and swap so you can watch the array change in real time per pass.

so there is a formula? used to solve that?
There isn’t a single “formula” for Bubble Sort the way you’d have one for solving an equation, but there is a structured process (an algorithm) that always follows the same pattern. Think of it as a recipe rather than a formula.

Bubble Sort Algorithm in Steps
Start at the beginning of the array.

Compare adjacent elements (x[j] and x[j+1]).

Swap if out of order (if x[j] > x[j+1]).

Move to the next pair and repeat until the end of the array.

After one full pass, the largest element is guaranteed to be at the end.

Repeat passes until no swaps are needed (array is sorted).

Mathematical way to express it
Outer loop runs 
𝑛
−
1
 times (where 
𝑛
 is the length of the array).

Inner loop runs 
𝑛
−
𝑖
−
1
 times (because the last 
𝑖
 elements are already sorted).

Worst-case comparisons/swaps:

𝑛
⋅
(
𝑛
−
1
)
2
That’s the maximum number of comparisons Bubble Sort makes (quadratic time complexity).

Example with your array
Array: [19, 7, 64, 99, 23, 10, 11]

Pass 1: Largest (99) moves to the end.

Pass 2: Next largest (64) moves before 99.

Pass 3: Next largest (23) moves before 64.

Pass 4: Next largest (19) moves before 23.

Pass 5: Remaining small numbers settle.

Done when no swaps occur.

So instead of a single formula, Bubble Sort is defined by two nested loops and a swap condition. The “formula-like” part is the comparison count:

Comparisons
=
𝑛
⋅
(
𝑛
−
1
)
2
Would you like me to show you a visual diagram of Bubble Sort passes on your array so you can literally see how each number “bubbles” into place?

using System;
					
public class Program
{
	public static void Main()
	{
		int[] x = {19, 7, 64, 99, 23, 10, 11};
		
		BubbleSort(x);
	}
	
	static void BubbleSort(int[] x)
	{
		int noOfItems = 0;
		int n = x.Length;
		int temp = x[0];
	
		foreach(int no in x){
			noOfItems++;
		}
		
		for(int i = 0; i < noOfItems; i++){
			if(x[i] > x[i+1]){
				temp = x[i+1];
				x[i+1] = x[i];
				x[i] = temp;
			}
			Console.WriteLine(x[i]);
		}
		
		
		/*
		foreach(int i in x)
		{
			foreach(int j in  x )
			{
				if(i < prev){
					prev = i;
			}
				Console.WriteLine(i);
		}
		*/
			
			/*
			foreach(int print in x)
			{
				Console.WriteLine(print);
			}
			*/
	}	
}
I see exactly what’s happening in your code — you’re very close, but there are a few critical issues that prevent it from working as a proper Bubble Sort:

Problems in your current code
Index out of range risk

In your loop:

csharp
for(int i = 0; i < noOfItems; i++){
    if(x[i] > x[i+1]) { ... }
}
When i = noOfItems - 1, you’ll try to access x[i+1], which doesn’t exist. That will throw an error.

Only one pass

Bubble Sort requires multiple passes through the array. Your code only does one pass, so the array won’t be fully sorted.

Printing inside the loop

You’re printing x[i] during the sorting loop. That shows partial results, not the final sorted array. Printing should be done after sorting is complete.

Unnecessary foreach to count items

You already have n = x.Length; — no need to loop to count again.

Correct Bubble Sort Implementation
Here’s a fixed version of your code:

csharp
using System;

public class Program
{
    public static void Main()
    {
        int[] x = {19, 7, 64, 99, 23, 10, 11};
        
        BubbleSort(x);

        // Print sorted array
        foreach (int num in x)
        {
            Console.WriteLine(num);
        }
    }
    
    static void BubbleSort(int[] x)
    {
        int n = x.Length;
        int temp;

        // Outer loop for passes
        for (int i = 0; i < n - 1; i++)
        {
            // Inner loop for comparisons
            for (int j = 0; j < n - i - 1; j++)
            {
                if (x[j] > x[j + 1])
                {
                    // Swap
                    temp = x[j];
                    x[j] = x[j + 1];
                    x[j + 1] = temp;
                }
            }
        }
    }
}
Output
For your array {19, 7, 64, 99, 23, 10, 11}, the sorted result will be:

Code
7
10
11
19
23
64
99
Key takeaways
Use two nested loops: outer loop for passes, inner loop for adjacent comparisons.

Always stop the inner loop at n - i - 1 to avoid index errors.

Print the array after sorting, not inside the sorting loop.

Would you like me to also show you a version that prints the array after each pass so you can visually see how the numbers “bubble” into place step by step?

using System;
					
public class Program
{
	public static void Main()
	{
		int[] x = {19, 7, 64, 99, 23, 10, 11};
		
		BubbleSort(x);
	}
	
	static void BubbleSort(int[] x)
	{
		int noOfItems = 0;
		int n = x.Length;
		int temp = x[0];
		int time = 0;
	
		foreach(int no in x){
			noOfItems++;
		}
		
		for(int i = 0; i < noOfItems-1; i++){
			if(x[i] > x[i+1]){
				temp = x[i+1];
				x[i+1] = x[i];
				x[i] = temp;
				temp = x[i+1];
			}
			time++;
		}
		
		foreach(int print in x){
			Console.WriteLine(print);
		}

		
		/*
		foreach(int i in x)
		{
			foreach(int j in  x )
			{
				if(i < prev){
					prev = i;
			}
				Console.WriteLine(i);
		}
		*/
			
			/*
			foreach(int print in x)
			{
				Console.WriteLine(print);
			}
			*/
	}	
}


now i see why it fails 19 is already lower than 64 then the assigning get fumbled somewhere after that
Exactly — you’ve spotted the core issue 👍. The way your current loop is written, it only does one pass through the array, comparing each element with the next. That means only some numbers move closer to their correct positions, but the array isn’t fully sorted yet. Bubble Sort requires multiple passes until all elements are in order.

Let’s break it down:

Why your code fails
Single loop only:  
Your for(int i = 0; i < noOfItems-1; i++) loop runs once through the array, but Bubble Sort needs an outer loop to repeat passes.

Adjacent swap logic:  
You correctly swap x[i] and x[i+1] if needed, but after one pass, only the largest element (99) ends up at the end. The rest are still unsorted.

Printing too early:  
You print the array after one pass, so you see a “partially sorted” result.

Correct Bubble Sort structure
Bubble Sort always uses two nested loops:

csharp
static void BubbleSort(int[] x)
{
    int n = x.Length;
    int temp;

    // Outer loop: number of passes
    for (int i = 0; i < n - 1; i++)
    {
        // Inner loop: compare adjacent pairs
        for (int j = 0; j < n - i - 1; j++)
        {
            if (x[j] > x[j + 1])
            {
                // Swap
                temp = x[j];
                x[j] = x[j + 1];
                x[j + 1] = temp;
            }
        }
    }
}
Step-by-step on your array
Array: [19, 7, 64, 99, 23, 10, 11]

Pass 1: 99 bubbles to the end → [7, 19, 64, 23, 10, 11, 99]

Pass 2: 64 bubbles before 99 → [7, 19, 23, 10, 11, 64, 99]

Pass 3: 23 bubbles before 64 → [7, 19, 10, 11, 23, 64, 99]

Pass 4: 19 bubbles before 23 → [7, 10, 11, 19, 23, 64, 99]

Pass 5: No swaps → sorted.

Printing the result
After sorting, print the array:

csharp
foreach (int num in x)
{
    Console.WriteLine(num);
}
Output:

Code
7
10
11
19
23
64
99
👉 The key fix: add the outer loop so Bubble Sort keeps making passes until everything is in order.

Would you like me to show you a debugging version that prints the array after each pass, so you can literally watch the numbers bubble into place step by step?

using System;
					
public class Program
{
	public static void Main()
	{
		int[] x = {19, 7, 64, 99, 23, 10, 11,98, 97};
		
		BubbleSort(x);
	}
	
	static void BubbleSort(int[] x)
	{
		int noOfItems = 0;
		int n = x.Length;
		int time = 0;
	
		foreach(int no in x){
			noOfItems++;
		}
		
		for(int i = 0; i < n - 1; i++){
			for(int j = 0; j < n  - 1; j++){
				if(x[j] > x[j+1]){
				int temp = x[j];
				x[j] = x[j+1];
				x[j+1] = temp;
				}
			}
			//Console.WriteLine(x[i]);
		}
		
		
		
		
		
		
		/*
			for(int i = 0; i < noOfItems-1; i++){
			if(x[i] > x[i+1]){
				temp = x[i+1];
				x[i+1] = x[i];
				x[i] = temp;
				temp = x[i+1];
			}
			time++;
		}
		*/
		
		foreach(int print in x){
			Console.WriteLine(print);
		}

		
		/*
		foreach(int i in x)
		{
			foreach(int j in  x )
			{
				if(i < prev){
					prev = i;
			}
				Console.WriteLine(i);
		}
		*/
			
			/*
			foreach(int print in x)
			{
				Console.WriteLine(print);
			}
			*/
	}	
}
Nice work Charls — you’re almost there! Your latest code is very close to a correct Bubble Sort, but let me point out the subtle issue and how to refine it.

What’s happening in your code
You correctly use two nested loops.

But in your inner loop you wrote:

csharp
for(int j = 0; j < n - 1; j++)
This always compares all pairs, even those already sorted at the end. Bubble Sort can be optimized by reducing the range each pass:

csharp
for(int j = 0; j < n - i - 1; j++)
That way, after each pass, the largest element is already in place and doesn’t need to be checked again.

Your code does sort correctly, but it does extra unnecessary comparisons.

Corrected Bubble Sort
Here’s the clean version:

csharp
using System;

public class Program
{
    public static void Main()
    {
        int[] x = {19, 7, 64, 99, 23, 10, 11, 98, 97};
        
        BubbleSort(x);

        // Print sorted array
        foreach (int num in x)
        {
            Console.WriteLine(num);
        }
    }
    
    static void BubbleSort(int[] x)
    {
        int n = x.Length;

        // Outer loop for passes
        for (int i = 0; i < n - 1; i++)
        {
            // Inner loop for comparisons
            for (int j = 0; j < n - i - 1; j++)
            {
                if (x[j] > x[j + 1])
                {
                    // Swap
                    int temp = x[j];
                    x[j] = x[j + 1];
                    x[j + 1] = temp;
                }
            }
        }
    }
}
Output for your array
Input: {19, 7, 64, 99, 23, 10, 11, 98, 97}  
Sorted result:

Code
7
10
11
19
23
64
97
98
99
Key takeaways
Use n - i - 1 in the inner loop to avoid redundant checks.

Print the array after sorting, not inside the sorting loop.

Bubble Sort is simple but inefficient for large arrays (O(n²)), though perfect for learning.

Would you like me to show you a debugging version that prints the array after each pass so you can literally watch the numbers bubble into place step by step? That’s often the best way to “see” the algorithm in action.

so the n - i - 1 comes in handy when the condition is false?
Great observation, Charls! Let’s unpack why the n - i - 1 part matters in Bubble Sort.

What n - i - 1 really does
n = total number of elements in the array.

i = current pass number (outer loop).

n - i - 1 = the last index we need to check in the inner loop.

👉 This isn’t about the condition being true or false — it’s about avoiding unnecessary comparisons once the largest elements have already bubbled to the end.

Why it’s needed
After pass 1, the largest element is guaranteed to be at the last position.
→ No need to compare it again.

After pass 2, the two largest elements are in place.
→ No need to compare the last two.

After pass i, the last i elements are sorted.
→ So we only need to compare up to n - i - 1.

Without n - i - 1, your inner loop keeps checking elements that are already sorted, wasting time.

Example with your array
Array: [19, 7, 64, 99, 23, 10, 11]

Pass 1 (i = 0): Largest (99) moves to the end.
Inner loop runs up to n - 1.

Pass 2 (i = 1): Next largest (64) moves before 99.
Inner loop runs up to n - 2.

Pass 3 (i = 2): Next largest (23) moves before 64.
Inner loop runs up to n - 3.

And so on — each pass shortens the range because the tail is already sorted.

In short
n - i - 1 is not about the swap condition itself.

It’s about shrinking the inner loop boundary so Bubble Sort doesn’t waste time checking sorted elements at the end.

Would you like me to show you a debugging version of Bubble Sort that prints the array after each pass, so you can literally see how n - i - 1 reduces the comparisons step by step?

can you give me a visual values of the variables as it sorts each pass on the inner foreach then the outer
Perfect request, Charls 👌 — let’s make Bubble Sort visual so you can see how the variables change at each step. I’ll show you the outer loop (pass) and the inner loop (comparison), along with the array values after swaps.

Example array
We’ll use your array:

Code
[19, 7, 64, 99, 23, 10, 11, 98, 97]
Bubble Sort trace (outer + inner loop values)
Outer pass (i)	Inner comparison (j)	Compare x[j] vs x[j+1]	Swap?	Array after step
Pass 1 (i=0)	j=0	19 vs 7	Yes	[7, 19, 64, 99, 23, 10, 11, 98, 97]
j=1	19 vs 64	No	[7, 19, 64, 99, 23, 10, 11, 98, 97]
j=2	64 vs 99	No	[7, 19, 64, 99, 23, 10, 11, 98, 97]
j=3	99 vs 23	Yes	[7, 19, 64, 23, 99, 10, 11, 98, 97]
j=4	99 vs 10	Yes	[7, 19, 64, 23, 10, 99, 11, 98, 97]
j=5	99 vs 11	Yes	[7, 19, 64, 23, 10, 11, 99, 98, 97]
j=6	99 vs 98	Yes	[7, 19, 64, 23, 10, 11, 98, 99, 97]
j=7	99 vs 97	Yes	[7, 19, 64, 23, 10, 11, 98, 97, 99]
Pass 2 (i=1)	j=0	7 vs 19	No	[7, 19, 64, 23, 10, 11, 98, 97, 99]
j=1	19 vs 64	No	[7, 19, 64, 23, 10, 11, 98, 97, 99]
j=2	64 vs 23	Yes	[7, 19, 23, 64, 10, 11, 98, 97, 99]
j=3	64 vs 10	Yes	[7, 19, 23, 10, 64, 11, 98, 97, 99]
j=4	64 vs 11	Yes	[7, 19, 23, 10, 11, 64, 98, 97, 99]
j=5	64 vs 98	No	[7, 19, 23, 10, 11, 64, 98, 97, 99]
j=6	98 vs 97	Yes	[7, 19, 23, 10, 11, 64, 97, 98, 99]
Pass 3 (i=2)	j=0	7 vs 19	No	[7, 19, 23, 10, 11, 64, 97, 98, 99]
j=1	19 vs 23	No	[7, 19, 23, 10, 11, 64, 97, 98, 99]
j=2	23 vs 10	Yes	[7, 19, 10, 23, 11, 64, 97, 98, 99]
j=3	23 vs 11	Yes	[7, 19, 10, 11, 23, 64, 97, 98, 99]
j=4	23 vs 64	No	[7, 19, 10, 11, 23, 64, 97, 98, 99]
j=5	64 vs 97	No	[7, 19, 10, 11, 23, 64, 97, 98, 99]
Pass 4 (i=3)	j=0	7 vs 19	No	[7, 19, 10, 11, 23, 64, 97, 98, 99]
j=1	19 vs 10	Yes	[7, 10, 19, 11, 23, 64, 97, 98, 99]
j=2	19 vs 11	Yes	[7, 10, 11, 19, 23, 64, 97, 98, 99]
j=3	19 vs 23	No	[7, 10, 11, 19, 23, 64, 97, 98, 99]
…and so on until no swaps are needed.

Final sorted array
Code
[7, 10, 11, 19, 23, 64, 97, 98, 99]
How to visualize in code
If you want to see these values live, you can add debug prints inside both loops:

csharp
for (int i = 0; i < n - 1; i++)
{
    Console.WriteLine($"Pass {i+1}:");
    for (int j = 0; j < n - i - 1; j++)
    {
        Console.WriteLine($"  Compare x[{j}]={x[j]} and x[{j+1}]={x[j+1]}");
        if (x[j] > x[j+1])
        {
            int temp = x[j];
            x[j] = x[j+1];
            x[j+1] = temp;
            Console.WriteLine($"  Swap -> {string.Join(", ", x)}");
        }
    }
}
This way, you’ll see the outer pass number, the inner comparison values, and the array after each swap.


*/
