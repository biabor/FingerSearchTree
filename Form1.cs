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
            lastLeaf = Tree.Search(lastLeaf, int.Parse(textBox1.Text));
        }

        private void addBtn__Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            while (true)
            {
                int value = rnd.Next(int.MinValue, int.MaxValue);
                lastLeaf = Tree.Search(lastLeaf, value);
                if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                    lastLeaf = Tree.Insert(lastLeaf, value);
            }
        }
    }
}
