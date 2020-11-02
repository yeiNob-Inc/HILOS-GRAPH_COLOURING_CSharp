/*
 https://www.geeksforgeeks.org/m-coloring-problem-backtracking-5/

	Method 2: Backtracking.
Approach: The idea is to assign colors one by one to different vertices,
starting from the vertex 0. Before assigning a color, check for safety by
considering already assigned colors to the adjacent vertices i.e check if the
adjacent vertices have the same color or not. If there is any color assignment
that does not violate the conditions, mark the color assignment as part of the
solution. If no assignment of color is possible then backtrack and return false.
Algorithm:

Create a recursive function that takes the graph, current index, number of vertices and output color array.
If the current index is equal to number of vertices. Print the color configuration in output array.
Assign color to a vertex (1 to m).
For every assigned color, check if the configuration is safe, (i.e. check if the adjacent vertices do not have the same color) recursively call the function with next index and number of vertices
If any recursive function returns true break the loop and return true.
If no recusive function returns true then return false.
filter_none
 */


/* C# program for solution of M Coloring problem
using backtracking */
using System;

class GFG
{
	readonly int V = 4;
	int[] color;

	/* A utility function to check if the current
	color assignment is safe for vertex v */
	bool isSafe(int v, int[,] graph,
				int[] color, int c)
	{
		for (int i = 0; i < V; i++)
			if (graph[v, i] == 1 && c == color[i])
				return false;
		return true;
	}

	/* A recursive utility function to solve m
	coloring problem */
	bool graphColoringUtil(int[,] graph, int m,
						int[] color, int v)
	{
		/* base case: If all vertices are assigned
		a color then return true */
		if (v == V)
			return true;

		/* Consider this vertex v and try different
		colors */
		for (int c = 1; c <= m; c++)
		{
			/* Check if assignment of color c to v
			is fine*/
			if (isSafe(v, graph, color, c))
			{
				color[v] = c;

				/* recur to assign colors to rest
				of the vertices */
				if (graphColoringUtil(graph, m,
									color, v + 1))
					return true;

				/* If assigning color c doesn't lead
				to a solution then remove it */
				color[v] = 0;
			}
		}

		/* If no color can be assigned to this vertex
		then return false */
		return false;
	}

	/* This function solves the m Coloring problem using
	Backtracking. It mainly uses graphColoringUtil()
	to solve the problem. It returns false if the m
	colors cannot be assigned, otherwise return true
	and prints assignments of colors to all vertices.
	Please note that there may be more than one
	solutions, this function prints one of the
	feasible solutions.*/
	bool graphColoring(int[,] graph, int m)
	{
		// Initialize all color values as 0. This
		// initialization is needed correct functioning
		// of isSafe()
		color = new int[V];
		for (int i = 0; i < V; i++)
			color[i] = 0;

		// Call graphColoringUtil() for vertex 0
		if (!graphColoringUtil(graph, m, color, 0))
		{
			Console.WriteLine("Solution does not exist");
			return false;
		}

		// Print the solution
		printSolution(color);
		return true;
	}

	/* A utility function to print solution */
	void printSolution(int[] color)
	{
		Console.WriteLine("Solution Exists: Following"
						+ " are the assigned colors");
		for (int i = 0; i < V; i++)
			Console.Write(" " + color[i] + " ");
		Console.WriteLine();
	}

	// Driver Code
	//public static void Main(String[] args)
	//{
	//	GFG Coloring = new GFG();

	//	/* Create following graph and test whether it is
	//	3 colorable
	//	(3)---(2)
	//	| / |
	//	| / |
	//	| / |
	//	(0)---(1)
	//	*/
	//	int[,] graph = { { 0, 1, 1, 1 },
	//					{ 1, 0, 1, 0 },
	//					{ 1, 1, 0, 1 },
	//					{ 1, 0, 1, 0 } };
	//	int m = 3; // Number of colors
	//	Coloring.graphColoring(graph, m);
	//}
}

// This code is contributed by PrinciRaj1992
