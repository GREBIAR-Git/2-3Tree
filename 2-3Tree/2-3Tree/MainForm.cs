using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            tree.Insert("1");
            tree.Insert("2");
            tree.Insert("3");
            //tree.PrintRoot();
            TreeUpdate();
        }

        public void TreeUpdate()
        {
            treeBox.Nodes.Clear();
            Branch currentBranch = tree.root;
            Queue<Branch> queue = new Queue<Branch>();
            Queue<Branch> queue = new Queue<Branch>();//Куда
            queue.Enqueue(currentBranch);
            if (currentBranch != null)
            {
                while (queue.Count != 0)
                {
                    currentBranch = queue.Dequeue();
                    if (currentBranch.ChildFirst != null) queue.Enqueue(currentBranch.ChildFirst);
                    if (currentBranch.ChildSecond != null) queue.Enqueue(currentBranch.ChildSecond);
                    if (currentBranch.ChildThird != null) queue.Enqueue(currentBranch.ChildSecond);
                    if (tree.root.RightCode != null)
                    {
                        treeBox.Nodes.Add(currentBranch.LeftCode.str + ":" + currentBranch.RightCode.str);
                    }
                    else
                    {
                        treeBox.Nodes.Add(currentBranch.LeftCode.str);
                    }
                }
            }
        }

        void textBoxAdd_KeyPress_OnlyDigit(object sender, KeyPressEventArgs e)
        {
            /*if(Control.ModifierKeys != Keys.Control)
            {
                if (!(Char.IsDigit(e.KeyChar)))
                {
                    if (e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                }
            }*/
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            tree.Insert(textBoxAdd.Text);
            TreeUpdate();
        }
    }
}
