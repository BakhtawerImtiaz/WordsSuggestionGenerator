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
                //parent->left = newNode(key);
            }
            else
            {
                parent.Right = myNewNode;
                //parent->right = newNode(key);
            }
        }
        /*
        public Node myNewNode(string data)
        {
            Node temp = new Node();

            temp.Data = data;

            temp.Left = null;
            temp.Right = null;

            return temp;
        }
        public Node Insert(Node root, string data)
        {
            Node newnode = myNewNode(data);
            Node x = root;
            Node y = null;
            while (x != null)
            {
                y = x;
                if (string.Compare(data , x.Data)<0)
                    x = x.Left;
                else
                    x = x.Right;
            } 
            if (y == null)
                y = newnode  
            else if (string.Compare(data , y.Data)<0)
                y.Left = newnode;

            // else assign the new node its right child  
            else
                y.Right = newnode;

            // Returns the pointer where the  
            // new node is inserted  
            return y;
        }
        /*
        public void Insert(string data)
        {
            if (Root == null)
            {
                Root = new Node(data);
                return;
            }
            InsertRecursive(Root, new Node(data));
        }
        private void InsertRecursive(Node root, Node newNode)
        {
            if (root == null)
                root = newNode;

            if (string.Compare(newNode.Data , root.Data) < 0)
            {
                if (root.Left == null)
                    root.Left = newNode;
                else
                    InsertRecursive(root.Left, newNode);

            }
            else
            {
                if (root.Right == null)
                    root.Right = newNode;
                else
                    InsertRecursive(root.Right, newNode);
            }
        }*/
    }

}
