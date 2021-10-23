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
            tree.Insert("10");
            tree.Insert("40");
            tree.Insert("50");
            tree.Insert("60");
            tree.Insert("70");
            tree.Insert("80");
            tree.Insert("90");
            tree.Insert("100");
            tree.Insert("120");
            tree.Insert("130");
            tree.Insert("140");
            tree.Insert("150");
            tree.Insert("160");
            tree.Remove("70");
            tree.Insert("85");
            tree.Remove("140");
            tree.Remove("160");
            tree.Remove("150");
            tree.Remove("60");
            tree.Remove("80");
            tree.Remove("120");
            TreeDrawingWithFoundBranch();
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
    }
}
