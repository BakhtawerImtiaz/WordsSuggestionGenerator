using System;
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
        string word = "";
        string preword = "";
        string[] listofwords;
        List<string> listOfWrongWord = new List<string>();
        List<string> listOfSuggesstions = new List<string>();
       
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
        void wordsuggestioner(Node root,string wrongword)
        {
            //word = preword = "";
            if (root == null)
                return;
           else
            {
                if(FindNode(tree.Root, wrongword) == "Not Found")
                {
                    if(LevenshteinDistance(root.Data, wrongword) <3 && preword!=root.Data)
                    {
                        word = word + root.Data + " ";
                    }
                    preword = root.Data;
                }
                wordsuggestioner(root.Left, wrongword);
                wordsuggestioner(root.Right, wrongword);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(16, 55, 72);
            button3.ForeColor = Color.White;

            button2.BackColor = Color.FromArgb(245, 186, 66);
            button2.ForeColor = Color.FromArgb(16, 55, 72);
            string testString = richTextBox1.Text;
            listofwords = testString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string x in listofwords)
            {
                if(FindNode(tree.Root,x)== "Found")
                {
                    MessageBox.Show("Correct Word");
             
                }
                else
                {
                    MessageBox.Show("Not Found");
                    wordsuggestioner(tree.Root, x);
                    listOfWrongWord.Add(x);
                    listOfSuggesstions.Add(word);
                    MessageBox.Show(word);
                    preword = word = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(245, 186, 66);
            button3.ForeColor = Color.FromArgb(16, 55, 72);


            button2.BackColor = Color.FromArgb(16, 55, 72);
            button2.ForeColor = Color.White;

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(245, 186, 66);
            button2.ForeColor = Color.FromArgb(16, 55, 72);

            button3.BackColor = Color.FromArgb(16, 55, 72);
            button3.ForeColor = Color.White;
        }
    }
}
