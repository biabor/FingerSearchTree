using Nodes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace FingerSearchTree
{
    public partial class Form1 : Form
    {
        Leaf lastLeaf = null;
        List<int> elements = new List<int>();

        public Form1()
        {
            InitializeComponent();
            lastLeaf = Tree.CreateList();
        }

        private void SearchBtn__Click(object sender, EventArgs e)
        {
            try
            {
                lastLeaf = Tree.Search(lastLeaf, int.Parse(textBox1.Text));
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void AddBtn__Click(object sender, EventArgs e)
        {
            try
            {
                int value = int.Parse(textBox1.Text);
                lastLeaf = Tree.Search(lastLeaf, value);
                if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                    lastLeaf = Tree.Insert(lastLeaf, value);
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void DeleteBtn__Click(object sender, EventArgs e)
        {
            try
            {
                int value = int.Parse(textBox1.Text);
                lastLeaf = Tree.Search(lastLeaf, value);
                if (lastLeaf.Value == value)
                    lastLeaf = Tree.Delete(lastLeaf);
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void RandomInsert__Click(object sender, EventArgs e)
        {
            try
            {
                int howMany = int.Parse(textBox1.Text);

                Random rnd = new Random();
                int value = int.MaxValue;

                while (elements.Count < howMany)
                {
                    lastLeaf = Tree.Search(lastLeaf, value);
                    if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                    {
                        lastLeaf = Tree.Insert(lastLeaf, value);
                        elements.Add(value);
                    }
                    value = rnd.Next();
                    //if (Test() == false)
                    //{
                    //    textBox1.Text = "Something went wrong: Either a left/right pointer or there are too few/too many elements";
                    //    return;
                    //}
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void RamdomDelete__Click(object sender, EventArgs e)
        {
            try
            {
                var searchTimmer = new Stopwatch();
                var insertTimmer = new Stopwatch();
                var deleteTimmer = new Stopwatch();
                int howMany = int.Parse(textBox1.Text);

                Random rnd = new Random();
                int value = int.MaxValue;

                while (elements.Count < howMany)
                {
                    searchTimmer.Start();
                    lastLeaf = Tree.Search(lastLeaf, value);
                    searchTimmer.Stop();
                    if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                    {
                        insertTimmer.Start();
                        lastLeaf = Tree.Insert(lastLeaf, value);
                        insertTimmer.Stop();
                        elements.Add(value);
                    }
                    value = rnd.Next();
                    //if (Test() == false)
                    //{
                    //    textBox1.Text = "Something went wrong: Either a left/right pointer or there are too few/too many elements";
                    //    return;
                    //}
                }

                while (elements.Count != 0)
                {
                    int index = rnd.Next(elements.Count);
                    value = elements[index];
                    elements.RemoveAt(index);
                    searchTimmer.Start();
                    lastLeaf = Tree.Search(lastLeaf, value);
                    searchTimmer.Stop();
                    if (lastLeaf.Value == value)
                    {
                        deleteTimmer.Start();
                        lastLeaf = Tree.Delete(lastLeaf);
                        deleteTimmer.Stop();
                    }
                    //if (Test() == false)
                    //{
                    //    textBox1.Text = "Something went wrong: Either a left/right pointer or there are too few/too many elements";
                    //    return;
                    //}
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void RamdomUpdate__Click(object sender, EventArgs e)
        {
            try
            {
                Random rnd = new Random();
                int howMany = int.Parse(textBox1.Text);

                for(int i = 0; i < howMany; i++)
                {
                    bool insert = false;
                    if (elements.Count == 0)
                        insert = true;
                    else
                        insert = rnd.Next(2) == 1;

                    if (insert)
                    {
                        int value = rnd.Next();
                        lastLeaf = Tree.Search(lastLeaf, value);
                        if (lastLeaf.Value < value && (lastLeaf.Right == null || (lastLeaf.Right as Leaf).Value > value))
                        {
                            lastLeaf = Tree.Insert(lastLeaf, value);
                            elements.Add(value);
                        }
                    }
                    else
                    {
                        int index = rnd.Next(elements.Count);
                        int value = elements[index];
                        lastLeaf = Tree.Search(lastLeaf, value);
                        if (lastLeaf.Value == value)
                        {
                            lastLeaf = Tree.Delete(lastLeaf);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private bool Test()
        {
            int count = 0;
            bool ok = true;
            while (lastLeaf.Left != null)
                lastLeaf = lastLeaf.Left as Leaf;
            while (lastLeaf.Right != null)
            {
                if (lastLeaf.Min > lastLeaf.Right.Min)
                    ok = false;
                lastLeaf = lastLeaf.Right as Leaf;
                count++;
            }
            if (count != elements.Count)
                ok = false;
            count = 0;
            while (lastLeaf.Left != null)
            {
                if (lastLeaf.Min < lastLeaf.Min)
                    ok = false;
                lastLeaf = lastLeaf.Left as Leaf;
                count++;
            }
            if (count != elements.Count)
                ok = false;

            return ok;
        }
    }
}
