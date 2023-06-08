using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace busca.entities
{
    internal class FordFukerson
    {
        public FordFukerson(){}
        public void run(ListGraph lg, MatrixGraph mg, Boolean isList, String origin, String destination) {
            if (isList ==  true) {
                this.runList(lg, origin, destination);
            } else {
                this.runMatix(mg, origin, destination);
            }
        }

        public void runList(ListGraph lg, String origin, String destination) {
            ListGraph lg2 = (ListGraph)lg.Clone();
            Search search = new Search();
            Double s = 0;
            do {
                List<String> path = search.deepSearch(lg2,null,origin,destination);
                if (path.Count() <= 1) break;

                Double a = 0;
                
                for (int i = 1; i < path.Count(); i++) {
                    Double a1 = lg2.linkWeight(lg2.getVertexIndex(path[i - 1]), lg2.getVertexIndex(path[i]));
                    if (a == 0 || a1 < a) {
                        a = a1;
                    }
                }
                s += a;
                for (int i = 1; i < path.Count(); i++) {
                    Double a1 = lg2.linkWeight(lg2.getVertexIndex(path[i - 1]), lg2.getVertexIndex(path[i]));
                    lg2.removeLink(lg2.getVertexIndex(path[i - 1]), lg2.getVertexIndex(path[i]));
                    if (a1 - a > 0) {
                        lg2.addLink(path[i - 1], path[i], a1 - a);
                    }
                }
            } while(true);
            lg.showGraph();
            lg2.showGraph();
            Console.WriteLine(" 'S' value " + s.ToString());
        }
        public void runMatix(MatrixGraph mg, String origin, String destination) {
            MatrixGraph mg2 = (MatrixGraph)mg.Clone();
            Search search = new Search();
            Double s = 0;
            do {
                List<String> path = search.deepSearch(null,mg2,origin,destination);
                if (path.Count() <= 1) break;

                Double a = 0;
                for (int i = 1; i < path.Count(); i++) {
                    Double a1 = mg2.linkWeight(mg2.getVertexIndex(path[i - 1]), mg2.getVertexIndex(path[i]));
                    if (a == 0 || a1 < a) {
                        a = a1;
                    }
                }
                s += a;
                for (int i = 1; i < path.Count(); i++) {
                    Double a1 = mg2.linkWeight(mg2.getVertexIndex(path[i - 1]), mg2.getVertexIndex(path[i]));
                    mg2.removeLink(mg2.getVertexIndex(path[i - 1]), mg2.getVertexIndex(path[i]));
                    if (a1 - a > 0) {
                        mg2.addLink(path[i - 1], path[i], a1 - a);
                    }
                }
            } while(true);
            mg.showGraph();
            mg2.showGraph();
            Console.WriteLine(" 'S' value " + s.ToString());
        }
    }
}