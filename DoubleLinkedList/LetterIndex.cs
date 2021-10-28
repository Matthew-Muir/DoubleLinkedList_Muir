using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    public class LetterIndex
    {
        public char Letter { get; set; }
        public Node Start { get; set; } = null;
        public Node End { get; set; } = null;

        public LetterIndex(char letter)
        {
            this.Letter = letter;
        }
    }
}
