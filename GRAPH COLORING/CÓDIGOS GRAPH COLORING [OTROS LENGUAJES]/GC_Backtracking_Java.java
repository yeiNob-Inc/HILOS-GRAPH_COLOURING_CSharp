// https://pencilprogrammer.com/algorithms/graph-coloring-problem/
 
import java.util.ArrayList;
import java.util.List;
 
public class Vertex {
    String name;
    List<Edge> adjacentEdges;
    boolean colored;
    String color;
 
    public Vertex(String name) {
        this.name = name;
        this.adjacentEdges = new ArrayList<>();
        this.colored =false;
        this.color = "";
    }
 
    public void addNeighbor(Edge edge){
        this.adjacentEdges.add(edge);
    }
}
 
public class Edge {
 
    Vertex startVertex;
    Vertex targetVertex;
 
    public Edge(Vertex startVertex, Vertex targetVertex) {
        this.startVertex = startVertex;
        this.targetVertex = targetVertex;
    }
}
 
public class Coloring {
 
    String colors[];
    int colorCount;
    int numberOfVertices;
 
    public Coloring(String[] colors, int N) {
        this.colors = colors;
        this.numberOfVertices = N;
 
    }
 
    public boolean setColors(Vertex vertex){
 
        for (int colorIndex=0; colorIndex<colors.length; colorIndex++){
 
            // Step-1 : checking validity
            if(!canColorWith(colorIndex, vertex)) continue;  //Step-2 : Continue
 
            //Step-2 : coloring
            vertex.color = colors[colorIndex];
            vertex.colored = true;
            colorCount++;
 
            //Step-4 : Whether all vertices colored?
            if(colorCount == numberOfVertices ) //Base Case
                return true;
 
            //Step-5 : Next uncolored vertex
            for(Edge edge:vertex.adjacentEdges){
                if (!edge.targetVertex.colored){
 
                    if(setColors(edge.targetVertex))
                        return true;
                }
 
            }
        }
 
        // Step-3 : Backtracking
        vertex.color = "";
        vertex.colored = false;
        return false;
    }
 
    //Function to check whether it is valid to color with color[colorIndex]
    private boolean canColorWith(int colorIndex, Vertex vertex) {
        Vertex neighborVertex;
        for(Edge edge:vertex.adjacentEdges){
            neighborVertex = edge.targetVertex;
            if(neighborVertex.colored && neighborVertex.color == colors[colorIndex])
                return  false;
        }
 
        return true;
    }
}
 
public class App {
 
    public static  void main(String args[]){
 
        //Creating Vertices
        Vertex vertexA =(new Vertex("A"));
        Vertex vertexB =(new Vertex("B"));
        Vertex vertexC =(new Vertex("C"));
        Vertex vertexD =(new Vertex("D"));
 
        List<Vertex> vertexList = new ArrayList<>();
 
        //Adding all vertices into single list
        vertexList.add(vertexA);
        vertexList.add(vertexB);
        vertexList.add(vertexC);
        vertexList.add(vertexD);
 
        //Joining verices with edge
        vertexA.addNeighbor(new Edge(vertexA,vertexB));
        vertexB.addNeighbor(new Edge(vertexB,vertexC));
        vertexC.addNeighbor(new Edge(vertexC,vertexD));
        vertexA.addNeighbor(new Edge(vertexA,vertexD));
 
        //bi-directional
        vertexB.addNeighbor(new Edge(vertexB,vertexA));
        vertexC.addNeighbor(new Edge(vertexC,vertexB));
        vertexD.addNeighbor(new Edge(vertexD,vertexC));
        vertexD.addNeighbor(new Edge(vertexD,vertexA));
 
 
        String colors[] = {"Green","Blue"};
 
        Coloring coloring = new Coloring(colors,vertexList.size());
        boolean hasSolution = coloring.setColors(vertexA);
 
        if (!hasSolution)
            System.out.println("No Solution");
        else {
            for (Vertex vertex: vertexList){
                System.out.println(vertex.name + " "+ vertex.color +"\n");
            }
        }
    }
}