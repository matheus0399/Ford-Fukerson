using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busca.entities
{
    internal class ListItem : ICloneable
    {
        public String label;
        public double weight;
        public ListItem(String label, double weight)
        {
            this.label = label;
            this.weight = weight;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
    internal class Link : ICloneable
    {
        public String label;
        public List<ListItem> links = new List<ListItem>();
        public Link(String label)
        {
            this.label = label;
        }
        public object Clone()
        {
            var link = (Link)MemberwiseClone();
            link.links = new List<ListItem>();
            foreach(var l in this.links) {
                link.links.Add((ListItem)l.Clone());
            }
            return link;
        }
        public void addLink(String label, double weight)
        {
            this.links.Add(new ListItem(label, weight));
        }
    }
}
