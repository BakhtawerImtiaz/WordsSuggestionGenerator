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
        int suggestionsReqWord = 0;
        string word = "";
        string preword = "";
        string[] listofwords;
        List<Words> listOfWrongWord = new List<Words>();
        List<string> listOfSuggesstions = new List<string>();

        private BinaryTree tree = new BinaryTree();
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadFunction()
        {
            string[] readtext = File.ReadAllLines("words.txt");
            foreach (string x in readtext)
            {
                tree.insertIterative(x);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFunction();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public string FindMyNodeIter(string key)
        {
            Node curr = tree.Root;
            Node parent = null;
            while (curr != null)
            {
                parent = curr;
                if (string.Compare(key, curr.Data) == 0)
                    return "Found";
                if (string.Compare(key, curr.Data) < 0)
                    curr = curr.Left;
                else
                    curr = curr.Right;
            }
            return "Not Found";
        }
        public void ProvideSuggestions(string key)
        {
            Node curr = tree.Root;
            Node parent = null;
            while (curr != null)
            {
                parent = curr;
                if (LevenshteinDistance(curr.Data, key) <= 3)
                {
                    word = word + curr.Data + " ";
                }
                if (string.Compare(key, curr.Data) < 0)
                    curr = curr.Left;
                else
                    curr = curr.Right;
            }
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
        private void button1_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(16, 55, 72);
            button3.ForeColor = Color.White;

            button2.BackColor = Color.FromArgb(245, 186, 66);
            button2.ForeColor = Color.FromArgb(16, 55, 72);
            string testString = richTextBox1.Text;
            listofwords = testString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            listOfWrongWord.Clear(); // to reset whole list clearing all previous data
            foreach (string x in listofwords)
            {
                Words MyWrongWord = new Words();
                MyWrongWord.Word = x + "\n";
                listOfWrongWord.Add(MyWrongWord);
            }
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = listOfWrongWord;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(245, 186, 66);
            button3.ForeColor = Color.FromArgb(16, 55, 72);
            ProvideSuggestions(listOfWrongWord[suggestionsReqWord].Word);
            Suggestions newForm = new Suggestions(word);
            newForm.Show();
            preword = word = "";
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            suggestionsReqWord = e.RowIndex;
            //dataGridView1.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.Red; 
            if (e.ColumnIndex == 1)
                dataGridView1.Rows[e.RowIndex].Selected = true;
            //e.Row.DefaultCellStyle.SelectionBackColor = Color.Red;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected)
                e.Row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 186, 66); ;

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
