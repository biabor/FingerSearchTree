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
            tree_.Add(500);
            tree_.Add(250);
            tree_.Add(1000);
            tree_.Add(int.MaxValue);
            tree_.Add(10000);
            tree_.Add(3250);
            tree_.Add(2000);
            tree_.Add(200);
            tree_.Add(3000);
            tree_.Add(4357);
            tree_.Add(13);
            tree_.Add(38);
            tree_.Add(865);
            tree_.Add(807896);
            tree_.Add(6753);
            tree_.Add(2458);
            tree_.Add(6790);
            tree_.Add(9086);
            tree_.Add(800);
            tree_.Add(4568);
            tree_.Add(8675);
            tree_.Add(567);
            tree_.Add(999);
            tree_.Add(875);
            tree_.Add(123);
            tree_.Add(567);
            tree_.Add(799864);
            tree_.Add(9086);
            tree_.Add(6742);
            tree_.Add(87675);
            tree_.Add(789656);
            tree_.Add(3456);
            tree_.Add(9786);
            tree_.Add(55555);
            tree_.Add(666);
            tree_.Add(9853);
            tree_.Add(2379);
            tree_.Add(3);
            tree_.Add(1);
        }
    }
}
