using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace busca.entities
{
    internal class Search
    {
        public String origin = "";
        public Search() { }

        public List<String> deepSearch(ListGraph lGp, MatrixGraph mGp, String origin, String destination) {
            if (origin == destination) {
                Console.WriteLine("Choose different vertices to navigate");
                return new List<String>();
            }
            this.origin = origin;
            if (lGp == null)
            {
                if (mGp.getVertexIndex(origin) == -1)
                {
                    Console.WriteLine("origin vertex does not exists");
                    return new List<String>();
                }
                return this.deepSearchMethod1(mGp, new List<String>(), origin, destination, new List<String>());
            }
            if (lGp.getVertexIndex(origin) == -1)
            {
                Console.WriteLine("origin vertex does not exists");
                return new List<String>();
            }
            return this.deepSearchMethod2(lGp, new List<String>(), origin, destination, new List<String>());
        }

        public List<String> deepSearchMethod1(MatrixGraph mGp, List<String> ret, String origin, String destination, List<String> visited) {
            visited.Add(origin);

            List<String> labels = mGp.getNeighbors(mGp.getVertexIndex(origin));

            foreach (String label in labels) {
                if (visited.Contains(label))
                {
                    continue;
                }
                if (label == destination)
                {
                    ret.Insert(0, label);
                    if (this.origin != origin) {
                        return ret;
                    }
                    else {
                        ret.Insert(0, origin);
                        return ret;
                    }
                }
                if (this.deepSearchMethod1(mGp, ret, label, destination, visited).Count() != 0)
                {
                    ret.Insert(0, label);
                    if (this.origin != origin) {
                        return ret;
                    }
                    else {
                        ret.Insert(0, origin);
                        return ret;
                    }
                }
            }
            
            return new List<String>();
        }

        public List<String> deepSearchMethod2(ListGraph lGp, List<String> ret, String origin, String destination, List<String> visited) {
            visited.Add(origin);

            List<String> labels = lGp.getNeighbors(lGp.getVertexIndex(origin));
            
            foreach (String label in labels)
            {
                if (visited.Contains(label))
                {
                    continue;
                }
                if (label == destination)
                {
                    ret.Insert(0, label);
                    if (this.origin != origin) {
                        return ret;
                    }
                    else {
                        ret.Insert(0, origin);
                        return ret;
                    }
                }
                if (this.deepSearchMethod2(lGp, ret, label, destination, visited).Count() != 0)
                {
                    ret.Insert(0, label);
                    if (this.origin != origin) {
                        return ret;
                    }
                    else {
                        ret.Insert(0, origin);
                        return ret;
                    }
                }
            }

            return new List<String>();
        }
    }
}
