using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FingerSearchTree
{
    public partial class Form1 : Form
    {
        private Tree tree_;

        public Form1()
        {
            InitializeComponent();
        }

        private void createBtn__Click(object sender, EventArgs e)
        {
            tree_ = new Tree();
        }

        private void searchBtn__Click(object sender, EventArgs e)
        {
            tree_.Search(int.MinValue);
            tree_.Search(5);
        }

        private void addBtn__Click(object sender, EventArgs e)
        {
            tree_.Add(100);
            tree_.Add(5000);
            tree_.Add(2500);
            tree_.Add(50);
            tree_.Add(4000);
            tree_.Add(75);

        }
    }
}
