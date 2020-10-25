/******************************************************************************/
//  This code implements the recursive largest first (RLF) algorithm for graph colouring
//  The code was written by R. Lewis www.rhydLewis.eu
//	
//	See: Lewis, R. (2015) A Guide to Graph Colouring: Algorithms and Applications. Berlin, Springer. 
//       ISBN: 978-3-319-25728-0. http://www.springer.com/us/book/9783319257280
//	
//	for further details
/******************************************************************************/
#include <string.h>
#include <fstream>
#include <iostream>
#include <vector>
#include <stdlib.h>
#include <time.h>
#include <limits.h>
#include <iomanip>

using namespace std;

unsigned long long numConfChecks;

//-------------------------------------------------------------------------------------
void swap(int &a, int &b){
	int x=a; a=b; b=x;
}

//-------------------------------------------------------------------------------------
void readInputFile(ifstream &inStream, int &numNodes, int &numEdges, vector< vector<bool> > &adjacent, vector<int> &degree, vector< vector<int> > &adjList)
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
void removeElement(vector<int> &A, int i){
	//Constant time operation for removing an item from a vector (note that ordering is not maintained)
	swap(A[i],A.back());
	A.pop_back();
}	

//-------------------------------------------------------------------------------------
inline
void chooseVertex(vector<int> &X,  int &v, int &vPos, vector<int> &Deg){
	//Select the vertex in X that has the maximum corresponding value in Deg
	//Ties are broken randomly
	int i, max=Deg[0], numMax=1;
	v=X[0];
	vPos=0;
	for(i=1;i<X.size();i++){
		if(Deg[i]>=max){
			if(Deg[i]>max) numMax=0;
			if(rand()%(numMax+1)==0){
				max = Deg[i];
				v=X[i];
				vPos=i;
			}
			numMax++;
		}
	}
}

//-------------------------------------------------------------------------------------
inline
void updateX(vector<int> &X, vector<int> &XDeg, int v, int vPos, vector<int> &Y, vector<int> &YDeg, vector< vector<bool> > &adjacent, vector<int> &NInY){
	int i=0, j;
	//Remove v from X and update the relevant vectors
	removeElement(X,vPos);
	removeElement(XDeg,vPos);
	removeElement(NInY,vPos);
	//Transfer all vertices in X that are adjacent to v (which has already been removed) into Y. Also update the degree vectors
	while(i<X.size()){
		numConfChecks++;
		if(adjacent[X[i]][v]){
			//Move vertex at X[i] to Y. Also transfer X[i]'s degree minus 1 (because the edge between v and X[i] has been removed)
			Y.push_back(X[i]);
			YDeg.push_back(XDeg[i]-1);
			removeElement(X,i);
			removeElement(XDeg,i);
			removeElement(NInY,i);
			
			//Since a new vertex is being moved to Y, any vertex in X that is adjacent has its NInY entry updated
			for(j=0;j<X.size();j++){
				numConfChecks++;
				if(adjacent[X[j]][Y.back()]){
					NInY[j]++;
				}
			}
		}
		else{
			i++;
		}
	}
}

//-------------------------------------------------------------------------------------
inline 
void makeSolution(vector< vector<int> > &candSol, int verbose, vector<int> &degree, vector< vector<int> > &adjList, vector<int> &colNode, vector< vector<bool> > &adjacent, int numNodes)
{
	int i, c, v, vPos;
	candSol.clear();
	
	//X is a vector containing all unplaced vertices that can go into the current colour c (initially contains all unplaced vertices).
	//XDeg contains the degree of the vertices induced by the subgraph of X (i.e. XDeg[i] == degree of X[i])
	//Y is used to hold vertices that clash with vertices currently assigned to colour c (initially empty).
	//YDeg contains the degree of the vertices induced by the subgraph of Y (i.e. YDeg[i] == degree of Y[i])
	//NInY contains the number of neighbours vertex X[i] has in Y (initially zero because Y is empty at the start of each iteration)
	vector<int> X(numNodes), Y, XDeg, YDeg, NInY(numNodes,0);
	for (i=0;i<numNodes;i++) X[i]=i;
	XDeg = degree;
	
	//Run the RLF algorithm
	c=0;
	while(!X.empty()){
		//Open a new colour c
		candSol.push_back(vector<int>());
		//Choose the vertex v in X that has the largest degree in the subgraph induced by X, then add v to colour c
		chooseVertex(X,v,vPos,XDeg);
		candSol[c].push_back(v);
		colNode[v]=c;
		updateX(X,XDeg,v,vPos,Y,YDeg,adjacent,NInY);
		while(!X.empty()){
			//Choose the vertex v that has the largest number of neighbours in Y, then add v to colour c
			chooseVertex(X,v,vPos,NInY);
			candSol[c].push_back(v);
			colNode[v]=c;
			updateX(X,XDeg,v,vPos,Y,YDeg,adjacent,NInY);
		}
		X.swap(Y);
		XDeg.swap(YDeg);
		NInY.resize(X.size(),0);
		c++;
	}	
}

//-------------------------------------------------------------------------------------
inline
void prettyPrintSolution(vector< vector<int> > &candSol)
{
	int i, count = 0, group;
	cout<<"\n\n";
	for(group=0; group<candSol.size(); group++){
		cout<<"C-"<<group<<"\t= {";
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

//-------------------------------------------------------------------------------------
inline
void checkSolution(vector< vector<int> > &candSol, vector< vector<bool> > &adjacent, int numNodes)
{
	int j, i, count = 0, group;
	bool valid = true;

	//first check that the permutation is the right length
	for(group=0; group<candSol.size(); group++){
		count = count + candSol[group].size();
	}

	if(count != numNodes){ 
		cout<<"Error: Permutations length is not equal to the problem size\n";
		valid = false;
	}

	//Now check that all the nodes are in the permutation (EXPENSIVE)
	vector<int> a(numNodes,0);
	for(group=0; group<candSol.size(); group++){
		for(i=0; i<candSol[group].size(); i++){
			a[candSol[group][i]]++;
		}
	}
	for(i=0; i<numNodes; i++){
		if(a[i] != 1){
			cout<<"Error: Vertex "<<i<<" should be in the solution exactly once.\n";
			valid = false;
		}
	}
	
	//Finally, check for illegal colourings: I.e. check that each colour class contains non conflicting nodes
	for(group=0; group<candSol.size(); group++){
		for(i=0; i<candSol[group].size()-1; i++){
			for(j=i+1; j<candSol[group].size(); j++){
				if(adjacent[candSol[group][i]][candSol[group][j]]){
					cout<<"Error: Nodes "<<candSol[group][i]<<" and "<<candSol[group][j]<<" are in the same group, but they clash"<<endl;
					valid = false;
				}
			}
		}
	}
	if(!valid) cout<<"This solution is not valid"<<endl;
}

//-------------------------------------------------------------------------------------
int main(int argc, char ** argv) {

	if(argc <= 1){
		cout<<"Recursive Largest First Algorithm for Graph Colouring\n\n"
			<<"USAGE:\n"
			<<"<InputFile>     (Required. File must be in DIMACS format)\n"
			<<"-r <int>        (Random seed. DEFAULT = 1)\n"
			<<"-v              (Verbosity. If present, output is sent to screen. If -v is repeated, more output is given.)\n"
			<<"****\n";
		exit(1);
	}

	int i, verbose = 0, randomSeed = 1, numNodes, numEdges=0;
	vector<int> degree;
	vector< vector<int> > adjList;
	vector< vector<bool> > adjacent;
	numConfChecks=0;

	for (i=1; i<argc; i++) {
		if (strcmp("-r", argv[i]) == 0 ) {
			randomSeed = atoi(argv[++i]);
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

	//Set Random Seed
	srand(randomSeed);
	
	//Check to see if there are no edges. If so, exit straight away
	if(numEdges <= 0){
		if(verbose>=1) cout<<"Graph has no edges. Optimal solution is obviously using one colour. Exiting."<<endl;
		exit(1);
	}

	//Start the timer
	clock_t runStart = clock();

	//Declare strucures used for holding the solution
	vector< vector<int> > candSol;
	vector<int> colNode(numNodes, INT_MIN);

	makeSolution(candSol,verbose,degree,adjList,colNode,adjacent,numNodes);

	//Stop the timer.
	clock_t runFinish = clock();
	int duration = (int)(((runFinish-runStart)/double(CLOCKS_PER_SEC))*1000);
	
	if(verbose>=1) cout<<" COLS     CPU-TIME(ms)\tCHECKS"<<endl;
	if(verbose>=1) cout<<setw(5)<<candSol.size()<<setw(11)<<duration<<"ms\t"<<numConfChecks<<endl;
	if(verbose>=2){
		prettyPrintSolution(candSol);	
		checkSolution(candSol,adjacent,numNodes);
	}
	ofstream resultsLog("resultsLog.log", ios::app);
	resultsLog<<candSol.size()<<endl;
	resultsLog.close();
	
	//output the solution to a text file
	ofstream solStrm;
	solStrm.open("solution.txt");
	solStrm<<numNodes<<"\n";
	for(i=0;i<numNodes;i++) solStrm<<colNode[i]<<"\n";
	solStrm.close();
}
