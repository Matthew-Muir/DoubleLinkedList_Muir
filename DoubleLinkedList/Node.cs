using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    public class Node
    {
        public Node Next { get; set; } = null;
        public Node Previous { get; set; } = null;
        public MetaData Data { get; set; }

        public Node(MetaData data)
        {
            this.Data = data;
        }
    }
}
