/*
https://algorithmia.com/algorithms/JaCoP/GraphColoring/source

This is an algorithm for graph coloring (http://en.wikipedia.org/wiki/Graph_coloring)
built on the JaCoP Constraint Programming Solver (https://github.com/radsz/jacop).
It takes a hash table, with each node name a key having the list of neighbors of that
node as the corresponding value (essentially an adjacency list) and outputs a hash
table of node names with the corresponding (integer) color as value.
*/

package algorithmia.JaCoP.GraphColoring;
import algorithmia.*;
import com.google.gson.*;
import java.util.*;

import org.jacop.core.*; 
import org.jacop.constraints.*; 
import org.jacop.search.*;

public class GraphColoring {

    public HashMap<String,String> apply(HashMap<String,List<String>> input) throws Exception {
        Store store = new Store();  // define FD store 
        int size = input.size(); 
        // define finite domain variables 
        IntVar[] v = new IntVar[size]; 
        //keeps track of where in the array each node node goes
        HashMap<Integer,String> arrayLoc = new HashMap<Integer,String>();
        int j = 0;
        for (Map.Entry<String,List<String>> entry : input.entrySet()) {
            String node = entry.getKey();
            v[j] = new IntVar(store, node, 1, size);
            arrayLoc.put(j,node);
            j++;
        }

        v = imposeConstraints(input, v, store,size);
        
        int n = v.length;
        int maxSumOfColors = (n*n+n)/2;
        IntVar cost = new IntVar(store,"costSum",1,maxSumOfColors);
        Constraint costCnstr = new Sum(v, cost);
        store.impose(costCnstr);
        
        //IndomainMin - implements enumeration method based on the selection of the
        //minimal value in the domain of variable
        IndomainMin<IntVar> indomain = new IndomainMin<IntVar>();
        SelectChoicePoint<IntVar> select = new InputOrderSelect<IntVar>(store, v, indomain); 
        Search<IntVar> search = new DepthFirstSearch<IntVar>(); 
        
        boolean result = search.labeling(store, select,cost);
        
        HashMap<String,String> out = new HashMap<String,String>();
        for (int i = 0; i < v.length; i++) {
            String node = arrayLoc.get(i);
            int color = v[i].domain.value();
            out.put(node,Integer.toString(color));
        }
        return out;
    }
    
    public IntVar[] imposeConstraints(HashMap<String,List<String>> input, IntVar[] v, Store store, int size) {
        HashMap<String,IntVar> varMap = new HashMap<String,IntVar>();
        int i = 0;
        for (Map.Entry<String,List<String>> entry : input.entrySet()) {
            String node = entry.getKey();
            if (!varMap.containsKey(node)) {
                IntVar newIntVar = new IntVar(store, node, 1, size);
                varMap.put(node,newIntVar);
            }
            List<String> nbors = input.get(node);
            for (String nbor : nbors) {
                if (!varMap.containsKey(nbor)) 
                    varMap.put(nbor,new IntVar(store, nbor, 1, size));
                store.impose(new XneqY(varMap.get(node),varMap.get(nbor)));
            }
            v[i] = varMap.get(node);
            i++;
        }
        return v;
    }

}