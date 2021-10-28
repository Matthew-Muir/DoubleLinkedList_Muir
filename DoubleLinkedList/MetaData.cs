using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    public class MetaData
    {
        public bool Gender { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }

        public MetaData(bool gender, string name, int rank)
        {
            this.Gender = gender;
            this.Name = name;
            this.Rank = rank;
        }
    }
}
