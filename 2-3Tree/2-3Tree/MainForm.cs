using System;
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
            
        }
        void buttonAdd_Click(object sender, EventArgs e)
        {
            if(textBoxAdd.Text!="")
            {
                tree.Insert(textBoxAdd.Text);
                TreeDrawingWithFoundBranch();
            }
        }
        void textBoxAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAdd_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }
        void buttonDel_Click(object sender, EventArgs e)
        {
            if (textBoxDel.Text != "")
            {
                tree.Remove(textBoxDel.Text);
                TreeDrawingWithFoundBranch();
            }
        }
        void textBoxDel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonDel_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }
        void textBox_TextChanged(object sender, EventArgs e)
        {
            RemoveSpecialSymbols(sender);
        }
        void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            TreeDrawingWithFoundBranch();
        }
        void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
        void RemoveSpecialSymbols(object sender)
        {
            TextBox textBox = (TextBox)sender;
            int cursor = textBox.SelectionStart;
            textBox.Text = textBox.Text.Replace("<", "");
            textBox.Text = textBox.Text.Replace(">", "");
            textBox.SelectionStart = cursor;
        }
        void buttonClear_Click(object sender, EventArgs e)
        {
            tree = new Tree();
            TreeDrawing();
        }

        void buttonRandom_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                tree.Insert();
            }
            treeBox.SuspendLayout();
            TreeDrawingWithFoundBranch();
            treeBox.ResumeLayout();
        }
    }
}
