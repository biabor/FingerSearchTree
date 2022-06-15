using Nodes;
using System;
using System.Windows.Forms;

namespace FingerSearchTree
{
    public partial class Form1 : Form
    {
        Leaf lastLeaf = null;

        public Form1()
        {
            InitializeComponent();
            lastLeaf = Tree.CreateList();
        }

        private void searchBtn__Click(object sender, EventArgs e)
        {
        }

        private void addBtn__Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            lastLeaf = Tree.Insert(lastLeaf, rnd.Next(lastLeaf.Value, int.MaxValue));
        }
    }
}
