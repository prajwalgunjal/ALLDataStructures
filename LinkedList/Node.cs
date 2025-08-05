using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LinkedList
{
    public class Node
    {
        public int Value;
        public Node Nextnode;
        /*public Node(int data)
        {
            Value = data;
            Nextnode = null;
        }*/
    }
    public class DoublyNode
    {
        public int Value;
        public DoublyNode Nextnode;
        public DoublyNode Previousnode;
    }
}
