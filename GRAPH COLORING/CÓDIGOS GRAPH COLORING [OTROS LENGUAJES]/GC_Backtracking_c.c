// https://pencilprogrammer.com/algorithms/graph-coloring-problem/

#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

//Number of vertices
#define numOfVertices 4

//function Prototypes
bool canColorWith(int, int);

// 0 - Green
// 1 - Blue

char colors[][30] = { "Green","Blue" };
int color_used = 2;
int colorCount;

//Graph connections
int graph[numOfVertices][numOfVertices] = { {0, 1, 0, 1},
                                            {1, 0, 1, 0},
                                            {0, 1, 0, 1},
                                            {1, 0, 1, 0} };

typedef struct {
    char name;
    bool colored;
    int color;

} Vertex;

//VertexList
Vertex* vertexArray[numOfVertices];

int hasUncoloredNeighbours(int idx) {
    int i;
    for (i = 0; i < numOfVertices; i++) {
        if (graph[idx][i] == 1 && vertexArray[i]->colored == false)
            return i;
    }
    return -1;
}

bool setColors(int idx) {

    int colorIndex, unColoredIdx;

    for (colorIndex = 0; colorIndex < color_used; colorIndex++) {

        // Step-1 : checking validity
        if (!canColorWith(colorIndex, idx)) continue;  //Step-2 : Continue

        //Step-2 : coloring
        vertexArray[idx]->color = colorIndex;
        vertexArray[idx]->colored = true;
        colorCount++;

        //Step-4 : Whether all vertices colored?
        if (colorCount == numOfVertices) //Base Case
            return true;

        //Step-5 : Next uncolored vertex
        while ((unColoredIdx = hasUncoloredNeighbours(idx)) != -1) {
            if (setColors(unColoredIdx))
                return true;
        }

    }

    // Step-3 : Backtracking
    vertexArray[idx]->color = -1;
    vertexArray[idx]->colored = false;
    return false;
}

//Function to check whether it is valid to color with color[colorIndex]
bool canColorWith(int colorIndex, int vertex) {
    Vertex* neighborVertex;
    int i;

    for (i = 0; i < numOfVertices; i++) {

        //skipping if vertex are not connected
        if (graph[vertex][i] == 0) continue;

        neighborVertex = vertexArray[i];
        if (neighborVertex->colored && neighborVertex->color == colorIndex)
            return  false;
    }

    return true;
}


int main()
{
    int i;

    //Creating Vertex
    Vertex vertexA, vertexB, vertexC, vertexD;

    vertexA.name = 'A';
    vertexB.name = 'B';
    vertexC.name = 'C';
    vertexD.name = 'D';

    vertexArray[0] = &vertexA;
    vertexArray[1] = &vertexB;
    vertexArray[2] = &vertexC;
    vertexArray[3] = &vertexD;

    for (i = 0; i < numOfVertices; i++) {
        vertexArray[i]->colored = false;
        vertexArray[i]->color = -1;
    }

    bool hasSolution = setColors(0);

    if (!hasSolution)
        printf("No Solution");
    else {
        for (i = 0; i < numOfVertices; i++) {
            printf("%c %s \n", vertexArray[i]->name, colors[vertexArray[i]->color]);
        }
    }

    return 0;
}