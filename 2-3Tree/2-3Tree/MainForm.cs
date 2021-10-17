using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _2_3Tree
{
    public partial class MainForm : Form
    {
        Tree tree;
        public MainForm()
        {
            InitializeComponent();
            tree = new Tree();
            tree.Insert("10");
            tree.Insert("100");
            tree.Insert("150");
            tree.Insert("40");
            tree.Insert("30");
            tree.Insert("36");
            tree.Insert("20");
            tree.Insert("1");
            tree.Insert("13");
            tree.Insert("11");
            tree.Insert("119");
            tree.Insert("90");
            tree.Insert("300");
            TreeUpdate();
        }

        public void TreeUpdate()
        {
            treeBox.Nodes.Clear();
            if(tree.root!=null)
            {
                Branch currentBranch = tree.root;
                Queue<Branch> queue = new Queue<Branch>();
                queue.Enqueue(currentBranch);
                Code code = currentBranch.LeftCode;
                TreeNodeCollection node = treeBox.Nodes;

                if (currentBranch != null)
                {
                    while (queue.Count != 0)
                    {
                        currentBranch = queue.Dequeue();
                        if (code > currentBranch.LeftCode)
                        {
                            node = node[0].Nodes;
                        }
                        code = currentBranch.LeftCode;
                        if (currentBranch.ChildFirst != null)
                        {
                            queue.Enqueue(currentBranch.ChildFirst);
                        }
                        if (currentBranch.ChildSecond != null)
                        {
                            queue.Enqueue(currentBranch.ChildSecond);
                        }
                        if (currentBranch.ChildThird != null)
                        {
                            queue.Enqueue(currentBranch.ChildThird);
                        }
                        if (currentBranch.RightCode != null)
                        {
                            node.Add(currentBranch.LeftCode.str + "|" + currentBranch.RightCode.str);
                        }
                        else
                        {
                            node.Add(currentBranch.LeftCode.str);
                        }
                    }
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(textBoxAdd.Text!="")
            {
                tree.Insert(textBoxAdd.Text);
                TreeUpdate();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            tree = new Tree();
            TreeUpdate();
        }

        private void textBoxAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAdd_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }
        /*
         public void TreeUpdate()
        {
            treeBox.Nodes.Clear();
            if(tree.root!=null)
            {
                Branch currentBranch = tree.root;
                Queue<Branch> queue = new Queue<Branch>();
                queue.Enqueue(currentBranch);
                Code code = currentBranch.LeftCode;
                TreeNodeCollection node = treeBox.Nodes;
                if (currentBranch != null)
                {
                    while (queue.Count != 0)
                    {
                        currentBranch = queue.Dequeue();
                        if (code > currentBranch.LeftCode)
                        {
                            node = node[0].Nodes;
                        }
                        code = currentBranch.LeftCode;
                        if (currentBranch.ChildFirst != null)
                        {
                            queue.Enqueue(currentBranch.ChildFirst);
                        }
                        if (currentBranch.ChildSecond != null)
                        {
                            queue.Enqueue(currentBranch.ChildSecond);
                        }
                        if (currentBranch.ChildThird != null)
                        {
                            queue.Enqueue(currentBranch.ChildThird);
                        }
                        if (currentBranch.RightCode != null)
                        {
                            node.Add(currentBranch.LeftCode.str + "|" + currentBranch.RightCode.str);
                        }
                        else
                        {
                            node.Add(currentBranch.LeftCode.str);
                        }
                    }
                }
            }
        }*/
    }
}
