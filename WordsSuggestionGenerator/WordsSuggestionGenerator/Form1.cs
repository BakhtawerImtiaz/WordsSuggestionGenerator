﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordsSuggestionGenerator
{
    public partial class Form1 : Form
    {
       
        private BinaryTree tree = new BinaryTree();
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadFunction()
        {
            string[] readtext = File.ReadAllLines("test.txt");
            foreach(string x in readtext)
            {
                tree.Insert(x);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFunction();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        public string FindNode(Node node, string s)
        {
            if (node == null)
                return "Not Found";
            else if (s.CompareTo(node.Data) < 0)
                return FindNode(node.Left, s);
            else if (s.CompareTo(node.Data) > 0)
                return FindNode(node.Right, s);

            return "Found";
        }
		
        public static int LevenshteinDistance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            return d[n, m];
        }
    }
}
