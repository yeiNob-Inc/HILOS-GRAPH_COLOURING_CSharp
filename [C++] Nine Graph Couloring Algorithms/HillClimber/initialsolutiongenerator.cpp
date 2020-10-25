#include "initialsolutiongenerator.h"
#include <limits.h>

extern unsigned long long numConfChecks;
extern vector< vector<bool> > adjacent;
extern vector< vector<int> > adjList;
extern vector<int> degree;


//-------------------------------------------------------------------------------------
void makeInitSolution( int numNodes, vector< vector<int> > &candSol, vector< vector<int> > &tempSol, vector<int> &colNode)
{
	//Colour the nodes using the DSatur algorithm
	DSaturCol(candSol,numNodes,colNode);

	//Also copy candSol to TempSol
	tempSol = candSol;
}

//-------------------------------------------------------------------------------------
inline
void DSaturCol(vector< vector<int> > &candSol, int numNodes, vector<int> &colNode)
{
	int i, j, r;
	bool foundColour;
	
	//Make a vector representing all the nodes
	vector<int> permutation(numNodes);
	for (i=0;i<numNodes;i++)permutation[i]=i;
	//Randomly permute the nodes, and then arrange by increasing order of degree
	//(this allows more than 1 possible outcome from the sort procedure)
	for(i=permutation.size()-1; i>=0; i--){
		r = rand()%(i+1);
		swap(permutation[i],permutation[r]);
	}
	//Bubble sort is used here. This could be made more efficent
	for(i=(permutation.size()-1); i>=0; i--){
		for(j=1; j<=i; j++){
			numConfChecks+=2;
			if(degree[permutation[j-1]] > degree[permutation[j]]){
				swap(permutation[j-1],permutation[j]);
			}
		}
	}
	
	//We also have a vector to hold the saturation degrees of each node
	vector<int> satDeg(permutation.size(), 0);

	//Initialise candSol and colNode
	candSol.clear();
	candSol.push_back(vector<int>());
	for(i=0; i<colNode.size(); i++) colNode[i] = INT_MIN;
	
	//Colour the rightmost node first (it has the highest degree), and remove it from the permutation
	candSol[0].push_back(permutation.back());
	colNode[permutation.back()] = 0;
	permutation.pop_back();
	//..and update the saturation degree array
	satDeg.pop_back();
	for(i=0; i<satDeg.size(); i++){
		numConfChecks++;
		if(adjacent[candSol[0][0]][permutation[i]]){
			satDeg[i]++;
		}
	}
	
	//Now colour the remaining nodes.
	int nodePos = 0, maxSat;
	while(!permutation.empty()){
		//choose the node to colour next (the rightmost node that has maximal satDegree)
		maxSat = INT_MIN;
		for(i=0; i<satDeg.size(); i++){
			if(satDeg[i] >= maxSat){
				maxSat = satDeg[i];
				nodePos = i;
			}
		}
		//now choose which colour to assign to the node
		foundColour = false;
		assignAColourDSatur(foundColour, candSol, permutation, nodePos, satDeg, numNodes, colNode);
		if(!foundColour){	
			//If we are here we have to make a new colour as we have tried all the other ones and none are suitable
			candSol.push_back(vector<int>());
			candSol.back().push_back(permutation[nodePos]);
			colNode[permutation[nodePos]] = candSol.size()-1;
			//Remember to update the saturation degree array
			for(i=0; i<permutation.size(); i++){
				numConfChecks++;
				if(adjacent[permutation[nodePos]][permutation[i]]){
					satDeg[i]++;
				}
			}
		}
		//Finally, we remove the node from the permutation
		permutation.erase(permutation.begin() + nodePos);
		satDeg.erase(satDeg.begin() + nodePos);
	}
}

//-------------------------------------------------------------------------------------
inline
bool colourIsFeasible(int v, vector< vector<int> > &sol, int c, vector<int> &colNode)
{
	//Checks to see whether vertex v can be feasibly inserted into colour c in sol.	
	int i;
	numConfChecks++;
	if(sol[c].size() > degree[v]){
		//check if any neighbours of v are currently in colour c
		for(i=0; i<adjList[v].size(); i++){
			numConfChecks++;
			if(colNode[adjList[v][i]] == c) return false;
		}
		return true;
	}
	else {
		//check if any vertices in colour c are adjacent to v
		for(i=0; i<sol[c].size(); i++){
			numConfChecks++;
			if(adjacent[v][sol[c][i]]) return false;
		}
		return true;
	}
}

//-------------------------------------------------------------------------------------
inline
void assignAColourDSatur(bool &foundColour, vector< vector<int> > &candSol, 
				vector<int> &permutation, int nodePos, vector<int> &satDeg, int numNodes, vector<int> &colNode)
{
	int i, j, c=0, v=permutation[nodePos];
	bool alreadyAdj;

	while(c < candSol.size() && !foundColour){			
		//check if colour c is feasible for vertex v
		if(colourIsFeasible(v, candSol, c, colNode)){
			//v can be added to this colour
			foundColour = true;
			candSol[c].push_back(v);
			colNode[v] = c;
			//We now need to update satDeg. To do this we identify the uncloured nodes i that are adjacent to
			//this newly coloured node v. If i is already adjacent to a node in colour c we do nothing, 
			//otherwise its saturation degree is increased...
			for(i=0; i<satDeg.size(); i++){
				numConfChecks++;
				if(adjacent[v][permutation[i]]){
					alreadyAdj = false;
					j=0;
					while(j<candSol[c].size()-1 && !alreadyAdj){
						numConfChecks++;
						if(adjacent[candSol[c][j]][permutation[i]]) alreadyAdj = true;
						j++;
					}
					if (!alreadyAdj)
						satDeg[i]++;
				}
			}
		}
		c++;
	}
}


//-------------------------------------------------------------------------------------
inline
void swap(int &a, int &b) {
	int temp;
	temp = a; a = b; b = temp;
}

