/******************************************************************************/
//  This code implements the DSatur algorithm of Brelaz.
//  The code was written by R. Lewis www.rhydLewis.eu
//	
//	See: Lewis, R. (2015) A Guide to Graph Colouring: Algorithms and Applications. Berlin, Springer. 
//       ISBN: 978-3-319-25728-0. http://www.springer.com/us/book/9783319257280
//	
//	for further details
/******************************************************************************/

#include <fstream>
#include <iostream>
#include <stdlib.h>
#include <vector>
#include <list>
#include <time.h>
#include <math.h>
#include <stdio.h>
#include <iomanip>
#include <string.h>
#include <limits.h>

using namespace std;

unsigned long long numConfChecks;

//-------------------------------------------------------------------------------------
inline
void swap(int &a, int &b)
{
	int temp;
	temp = a; a = b; b = temp;
}

//-------------------------------------------------------------------------------------
inline
void prettyPrintSolution(vector< vector<int> > &candSol)
{
	int i, count = 0, group;
	cout<<"\n";
	for(group=0; group<candSol.size(); group++){
		cout<<"Colour "<<group<<" = {";
		if(candSol[group].size() == 0) cout<<"empty}\n";
		else {
			for(i=0; i<candSol[group].size()-1; i++){
				cout << candSol[group][i]<< ", ";
			}
			cout<<candSol[group][candSol[group].size()-1]<<"}\n";
			count = count + candSol[group].size();
		}
	}
	cout<<"Total Number of Nodes = "<<count<<endl;
}

//---------------------------------------------------------------
inline
void checkSolution(vector< vector<int> > &candSol, int numItems, vector< vector<bool> > &adjacent)
{
	//Runs a series of checks to see if "candSol" represents a full, valid, clash-free solution.
	int j, i, count = 0, group;
	bool valid = true;
	
	//first check that the solution is the right size
	for(group=0; group<candSol.size(); group++){
		count = count + candSol[group].size();
	}
	
	if(count != numItems){ 
		cout<<"Error: solution size is not equal to the problem size\n";
		valid = false;
	}

	//Now check that all the nodes are in the permutation exactly once
	vector<int> a(numItems, 0);
	for(group=0; group<candSol.size(); group++){
		for(i=0; i<candSol[group].size(); i++){
			a[candSol[group][i]]++;
		}
	}
	for(i=0; i<numItems; i++){
		if(a[i] > 1){
			cout<<"Error: Vertex "<<i<<" occurs "<<a[i]<<" times in the solution\n";
			valid = false;
		}
		else if(a[i] < 1){
			cout<<"Error: Vertex "<<i<<" is not present in the solution\n";
			valid = false;
		}
	}
		
	//Finally, check for illegal colourings: I.e. check that each colour class contains only non conflicting nodes
	for(group=0; group<candSol.size(); group++){
		if(!candSol[group].empty()){
			for(i=0; i<candSol[group].size()-1; i++){
				for(j=i+1; j<candSol[group].size(); j++){
					if(adjacent[candSol[group][i]][candSol[group][j]]){
						cout<<"Error: Nodes "<<candSol[group][i]<<" and "<<candSol[group][j]<<" are in the same group, but they clash"<<endl;
						valid = false;
					}
				}
			}
		}
	}
	if(valid) cout<<"Solution is valid"<<endl;
	else cout<<"Warning: Solution is not valid"<<endl;
}

//-------------------------------------------------------------------------------------
void readInputFile(ifstream &inStream, int &numNodes, int &numEdges, vector< vector<bool> > &adjacent, vector<int> &degree,
	vector< vector<int> > &adjList)
{
	//Reads a DIMACS format file and creates the corresponding degree array and adjacency matrix
	char c;
	char str[1000];
	int line=0, i, j;
	numEdges=0;
	int edges=-1;
	int blem=1;
	int multiple = 0;
	while(!inStream.eof()) {
		line++;
		inStream.get(c);
		if (inStream.eof()) break;
		switch (c) {
		case 'p':
			inStream.get(c);
			inStream.getline(str,999,' ');
			if (strcmp(str,"edge") && strcmp(str,"edges")) {
				cerr << "Error reading 'p' line: no 'edge' keyword found.\n";
				cerr << "'" << str << "' found instead\n";
				exit(-1);
			}
			inStream >> numNodes;
			inStream >> numEdges;
			//Set up the 2d adjacency matrix
			adjacent.clear();
			adjacent.resize(numNodes, vector<bool>(numNodes));			
			for (i=0;i<numNodes;i++) for(j=0;j<numNodes;j++) {
				if(i==j)adjacent[i][j]=true; 
				else adjacent[i][j] = false;
			}
			blem=0;
			break;
		case 'n':
			if (blem) {
				cerr << "Found 'n' line before a 'p' line.\n";
				exit(-1);
			}
			int node;
			inStream >> node;
			if (node < 1 || node > numNodes) {
				cerr << "Node number " << node << " is out of range!\n";
				exit(-1);
			}
			node--;	
			cout << "Tags (n Lines) not implemented in g object\n";
			break;
		case 'e':
			int node1, node2;
			inStream >> node1 >> node2;
			if (node1 < 1 || node1 > numNodes || node2 < 1 || node2 > numNodes) {
				cerr << "Node " << node1 << " or " << node2 << " is out of range!\n";
				exit(-1);
			}
			node1--;
			node2--;
			if (!adjacent[node1][node2]) {
				edges++;
			} else {
				multiple++;
				if (multiple<5) {
					cerr << "Warning: in graph file at line " << line << ": edge is defined more than once.\n";
					if (multiple == 4) {
						cerr << "  No more multiple edge warnings will be issued\n";
					}
				}
			}
			adjacent[node1][node2] = true;
			adjacent[node2][node1] = true;
			break;
		case 'd':
		case 'v':
		case 'x':
			cerr << "File line " << line << ":\n";
			cerr << "'" << c << "' lines are not implemented yet...\n";
			inStream.getline(str,999,'\n');
			break;
		case 'c':
			inStream.putback('c');
			inStream.get(str,999,'\n');
			break;
		default:
			cerr << "File line " << line << ":\n";
			cerr << "'" << c << "' is an unknown line code\n";
			exit(-1);
		}
		inStream.get(); // Kill the newline;
	}
	inStream.close();
	if (multiple) {
		cerr << multiple << " multiple edges encountered\n";
	}
	//Now use the adjacency matrix to construct the degree array and adjacency list
	degree.resize(numNodes, 0);
	adjList.resize(numNodes, vector<int>());
	for(i=0; i<numNodes; i++){
		for(j=0; j<numNodes; j++){
			if(adjacent[i][j] && i!=j){
				adjList[i].push_back(j);
				degree[i]++;
			}
		}
	}
}

//-------------------------------------------------------------------------------------
inline
bool colourIsFeasible(vector< vector<int> > &sol, int c, int v, vector< vector<bool> > &adjacent,
					vector< vector<int> > &adjList, vector<int> &colNode)
{
	//Checks to see whether vertex v can be feasibly inserted into colour c in sol.	
	int i;
	numConfChecks++;
	if(sol[c].size() > adjList[v].size()){
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
void assignAColourDSatur(bool &foundColour, vector< vector<int> > &candSol, vector< vector<bool> > &adjacent, 
						vector<int> &permutation, int nodePos, vector<int> &satDeg, vector<int> &degree, int numNodes,
						vector< vector<int> > &adjList, vector<int> &colNode)
{
	int i, j, c=0, v=permutation[nodePos];
	bool alreadyAdj;

	while(c < candSol.size() && !foundColour){			
		//check if colour c is feasible for vertex v
		if(colourIsFeasible(candSol, c, v, adjacent, adjList, colNode)){
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
void DSaturCol(vector< vector<int> > &candSol, vector< vector<bool> > &adjacent, vector<int> &degree, int numNodes,
				vector< vector<int> > &adjList)
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

	//Also have a vector holding the colours of each node
	vector<int> colNode(numNodes,INT_MIN);

	//Initialise candSol
	candSol.clear();
	candSol.push_back(vector<int>());
	
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
		assignAColourDSatur(foundColour, candSol, adjacent, permutation, nodePos, satDeg, degree, numNodes, adjList, colNode);
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
int main(int argc, char ** argv){

	if(argc <= 1){
		cout<<"DSatur Algorithm for Graph Colouring\n\n"
		<<"USAGE:\n"
		<<"<InputFile>     (Required. File must be in DIMACS format)\n"
		<<"-r <int>        (Random seed. DEFAULT = 1)\n"
		<<"-v              (Verbosity. If present, output is sent to screen. If -v is repeated, more output is given.)\n"
		<<"****\n";
		exit(1);
	}
	
	//Variables
	vector< vector<bool> > adjacent;
	vector<int> degree;
	vector< vector<int> > adjList;
	int numNodes, numEdges=0, seed=1, duration, verbose = 0, i;
	numConfChecks = 0;
		  
	for(i=1; i<argc; i++){
		if (strcmp("-r", argv[i]) == 0 ) {
			seed = atoi(argv[++i]);
		} else if (strcmp("-v", argv[i]) == 0 ) {
			verbose++;
		} else {
			//Set up input file, read, and close (input must be in DIMACS format)
			ifstream inStream;
			inStream.open(argv[i]);
			readInputFile(inStream,numNodes,numEdges,adjacent,degree,adjList);
			inStream.close();
		}
	}

	//Set random seed
	srand(seed);
	
	//Do a check to see if we have the empty graph. If so, end immediately.
	if(numEdges <= 0){
		if(verbose>=1) cout<<"Graph has no edges. Optimal solution is obviously using one colour. Exiting."<<endl;
		exit(1);
	}
	

	//Start the timer
	clock_t runStart = clock();
	
	//Now form a solution called candSol (candidate solution)
	vector< vector<int> > candSol;
	DSaturCol(candSol, adjacent, degree, numNodes, adjList);
	
	//Stop the timer.
	clock_t runFinish = clock();
	duration = (int)(((runFinish-runStart)/double(CLOCKS_PER_SEC))*1000);
	
	//Produce some output
	if(verbose>=1) cout<<" COLS     CPU-TIME(ms)\tCHECKS"<<endl;
	if(verbose>=1) cout<<setw(5)<<candSol.size()<<setw(11)<<duration<<"ms\t"<<numConfChecks<<endl;
	if(verbose>=2){
		prettyPrintSolution(candSol);	
	}
	
		//output the solution to a text file
	ofstream solStrm;
	solStrm.open("solution.txt");
	vector<int> grp(numNodes);
	for(i=0;i<candSol.size();i++){for(int j=0;j<candSol[i].size();j++){grp[candSol[i][j]] = i;}}
	solStrm<<numNodes<<"\n";
	for(i=0;i<numNodes;i++) solStrm<<grp[i]<<"\n";
	solStrm.close();

	ofstream resultsLog("resultsLog.log", ios::app);
	resultsLog<<candSol.size()<<endl;
	resultsLog.close();

}
