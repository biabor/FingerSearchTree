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
            test();
            //    int value = int.Parse(textBox1.Text);
            //    lastLeaf = Tree.Search(lastLeaf, value);
            //    if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
            //        lastLeaf = Tree.Insert(lastLeaf, value);
        }

        private void deleteBtn__Click(object sender, EventArgs e)
        {
            int value = int.Parse(textBox1.Text);
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value == value)
                lastLeaf = Tree.Delete(lastLeaf);
        }

        private void test()
        {
            int value = -100000;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 100000;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 0;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -100;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 100;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -50;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 50;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5000;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 10000;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -5000;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -10000;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 2000;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -2000;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -5678;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 98763;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 777;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -89458;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 25476;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -1111;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 80987;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 56489;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 23455;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -76594;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -9073;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 13;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -13;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -642;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 99999;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 457;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -562;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 88743;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -7890;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 152;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 33;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 784;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -764;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -19;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 87;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -576;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -24;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 7651;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 56823;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -652;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 982;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -8;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 1432356;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 4563;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 625261;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 874252;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -245;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 7;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -3;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -54;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -8769;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 23;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -87;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 321;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -4325;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 8762;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 71;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 55;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -347;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -990;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 24;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -905;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -145;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5461;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 873;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -23;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 97;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -1;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 256;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 666;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 624;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -872;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -51;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 9;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -5;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 658;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 6665;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -69;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 12;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 458;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 987;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 4573;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -852;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 485;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -910;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -150;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5460;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 875;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -25;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 970;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -10;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 250;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 670;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 625;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -800;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -20;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 8;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -9;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5823;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 487;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -61;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 16;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -4;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 58;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -45;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -128;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 4;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -916;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -156;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5466;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 8764;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -264;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 976;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -16;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 676;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 626;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -806;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -26;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5826;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 486;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -66;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 14;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -6;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 56;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 984;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 986;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -46;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -126;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 6;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -10900;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 10800;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 15;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -101;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 105;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -53;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 58;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5070;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 10200;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -5200;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -10900;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 2100;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -27700;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -54578;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 99963;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 7577;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -81458;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 21476;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -1221;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 87987;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5689;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 2345;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -765094;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -9043;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 11;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -11;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -682;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 9799;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 4657;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -5692;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 8843;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -790;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 192;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 333;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 884;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -784;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -39;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 89;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -596;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -22;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 7691;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 56423;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -654;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 972;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -7;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 14356;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 4763;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 62261;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 87652;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -2435;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 6;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -2;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -564;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -8779;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 26;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -86;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 326;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -4326;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 8766;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 61;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 65;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -367;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -996;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 26;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -965;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -146;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5466;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 876;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -26;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 96;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -19;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 266;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 666;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 694;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -672;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -56;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 76;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -97;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 6768;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 6965;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -68;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 14;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 468;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 986;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 45673;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -856;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 4667;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -960;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -156;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5466;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 8765;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -28;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 960;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -60;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 255;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 676;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 629;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -869;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -269;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 4374;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -74298;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5826;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 687;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -661;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 156;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -334;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 508;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -4525;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -168;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 98;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -976;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -177;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5726;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 8664;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -2624;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 9736;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -136;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 636;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 6086;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -8716;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -219;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5876;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 4866;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -76;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 57;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 924;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 586;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 94;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 96;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -4756;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -1286;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 43;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -888;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 108880;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 87;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -108;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 180;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -58;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 58;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5080;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 10800;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -5800;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -18800;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 2080;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -2800;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -5878;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 98783;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 787;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -89858;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 25876;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -1881;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 88887;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 56889;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 23885;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -78894;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -9883;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -183;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -6882;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 98889;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 488;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -588;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 88788;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -7888;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 882;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 38;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 78984;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -788;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -89;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 847;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -288;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 7981;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 58823;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -688;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 9882;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -867;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 1888356;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 4889;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 628861;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 874882;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -248;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 78968;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -874568;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -5884;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -8869;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 2883;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -87878;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 38721;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -43885;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 87688;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 7881;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5885;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -348;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -988;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 2885;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -885;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -1845;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 58861;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 8788;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 9887;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -1887;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 28897;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 68866;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 62884;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -878782;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 988987;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -5875;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 65888;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 68865;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -6889;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 1828;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 48858;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 4773;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -822;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -918;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -158;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 58860;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 87885;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -2885;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 9798;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -188;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 25880;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 6888;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 62885;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -80880;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 656788;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -89796889;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 588823;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 487888;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -6188;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 1688;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -4848;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5858;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -455887;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -126788;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 4887;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -918876;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -15886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 546886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 876884;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -26884;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 97886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -16887;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 67886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 62688;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -80886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -2886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 582886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 48689;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -6688;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 1487;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -6897;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 56886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 984897;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 98688;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -4688;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -12688;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 687649;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -10988;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 10808;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 18588;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 10885;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -5387;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5688;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5870;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 1087200;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -5280;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 21088;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -27788;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -58578;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 98963;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 7578;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -81858;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 214786;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -12821;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 878987;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 23485;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -765894;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -9943;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 1188;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -1199;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -68882;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 88987;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 468857;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -568892;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 884883;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -78890;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 19882;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 38383;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 84584;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -78684;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -3889;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 869;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -96;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -282;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 76891;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 568423;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -6854;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 9782;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 143856;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 4783;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 88261;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -248835;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 688;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -8889;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 2876;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -87886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 36;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -4886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 87886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 681;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 6885;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -3678;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -98896;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 28;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -968;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -1886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 9886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -1889;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 26886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 66886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 69884;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -67288;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -5886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 7886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -9887;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 678868;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 698865;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -8868;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 184;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 4868;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 98986;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 48873;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -8586;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 4867;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -9890;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -856;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 546886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 878865;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -8728;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 8830;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -80;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 2855;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 6786;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 6289;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -8689;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -8269;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 43874;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -74898;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5886;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 68987;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 1587;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -3384;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5808;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -48725;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 88;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -876;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -187;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5926;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 8694;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -2824;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 9738;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -138;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 638;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 6088;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -8718;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -218;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 5878;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 4869;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -78;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 928;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 588;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 98;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -4758;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = -1288;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            value = 48;
            lastLeaf = Tree.Search(lastLeaf, value);
            if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                lastLeaf = Tree.Insert(lastLeaf, value);

            Random rnd = new Random();
            value = rnd.Next();
            while (lastLeaf.FatherNode.Degree <= Helpers.Bi(1))
            {
                lastLeaf = Tree.Search(lastLeaf, value);
                if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                    lastLeaf = Tree.Insert(lastLeaf, value);
                value = rnd.Next();
            }
            while (lastLeaf.FatherNode.FatherNode.Blocks2.Count <=2)
            {
                lastLeaf = Tree.Search(lastLeaf, value);
                if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                    lastLeaf = Tree.Insert(lastLeaf, value);
                value = rnd.Next();
            }
            while (lastLeaf.FatherNode.FatherNode.FatherNode == null)
            {
                lastLeaf = Tree.Search(lastLeaf, value);
                if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                    lastLeaf = Tree.Insert(lastLeaf, value);
                value = rnd.Next();
            }
            int b = 9;
        }
    }
}
