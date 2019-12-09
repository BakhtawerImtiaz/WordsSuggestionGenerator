using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsSuggestionGenerator
{
    public class Node
    {
        public string Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node()
        {
            this.Data = "";
            this.Left = null;
        }
        public Node(string data)
        {
            this.Data = data;
        }
    }
    public class BinaryTree
    {
        public Node Root;
        public BinaryTree()
        {
            Root = null;
        }
        public void insertIterative(string key)
        {
            Node myNewNode = new Node(key);
            Node curr = this.Root;
            Node parent = null;
            if (this.Root == null)
            {
                this.Root = myNewNode;
                return;
            }
            while (curr != null)
            {
                parent = curr;
                if (string.Compare(key, curr.Data) < 0)
                    curr = curr.Left;
                else
                    curr = curr.Right;
            }
            if (string.Compare(key, parent.Data) < 0)
            {
                parent.Left = myNewNode;
            }
            else
            {
                parent.Right = myNewNode;
            }

        }

    }
}