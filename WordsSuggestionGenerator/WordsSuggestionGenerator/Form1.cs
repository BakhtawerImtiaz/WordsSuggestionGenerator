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
    }
}
