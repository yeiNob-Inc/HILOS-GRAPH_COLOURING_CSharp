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
using GRAPH_COLORING;
using System;
using System.Collections.Generic;
using System.Drawing;

class Coloring
{
	readonly int vertexNumber;
	int[] color;
	Vertex[,] vertexSet;
	Color[] realColors;
	public Coloring(int vertexNumber, Vertex[,] vertexSet)
	{
		this.vertexNumber = vertexNumber;
		this.vertexSet = vertexSet;
	}
	/* A utility function to check if the current
	color assignment is safe for vertex v */
	bool isSafe(int v, bool[,] graph, int[] color, int c)
	{
		for (int i = 0; i < vertexNumber; i++)
			if (graph[i, v] && c == color[i])
				return false;
		return true;
	}

	/* A recursive utility function to solve m
	coloring problem */
	bool graphColoringUtil(bool[,] graph, int numberOfColors, int[] color, int v)
	{
		/* base case: If all vertices are assigned
		a color then return true */
		if (v == vertexNumber)
			return true;

		/* Consider this vertex v and try different
		colors */
		for (int c = 1; c <= numberOfColors; c++)
		{
			/* Check if assignment of color c to v
			is fine*/
			if (isSafe(v, graph, color, c))
			{
				color[v] = c;
				vertexSet[0, v].Color = realColors[c];

				/* recur to assign colors to rest
				of the vertices */
				if (graphColoringUtil(graph, numberOfColors,
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
	public bool graphColoring(bool[,] graph, int numberOfColors)
	{
		// Initialize all color values as 0. This
		// initialization is needed correct functioning
		// of isSafe()
		color = new int[vertexNumber];
		AssignRealColors(color);
		for (int i = 0; i < vertexNumber; i++)
			color[i] = 0;

		// Call graphColoringUtil() for vertex 0
		if (!graphColoringUtil(graph, numberOfColors, color, 0))
		{
			//Console.WriteLine("Solution does not exist");
			return false;
		}

		// Print the solution
		printSolution(color);
		return true;
	}
	// Método para asignar colores reales y no solo números.
	private Color[] AssignRealColors(int[] color)
    {
		realColors = new Color[color.Length];
		Random r = new Random();
		for (int i = 0; i < realColors.Length; i++)
			realColors[i] = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
		return realColors;
    }

	/* A utility function to print solution */
	void printSolution(int[] color)
	{
		Console.WriteLine("Solution Exists: Following"
						+ " are the assigned colors");
		for (int i = 0; i < vertexNumber; i++)
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
	//	int numberOfColors = 3; // Number of colors
	//	Coloring.graphColoring(graph, numberOfColors);
	//}
}

// This code is contributed by PrinciRaj1992
