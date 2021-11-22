using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace _2_3Tree
{
    public partial class MainForm : Form
    {
        Tree tree;
        public MainForm()
        {
            InitializeComponent();
            StatusBar.Text = "Программа инициализирована";
            tree = new Tree();
        }

        void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxAdd.Text != "")
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                if (tree.Insert(textBoxAdd.Text))
                {
                    stopwatch.Stop();
                    StatusBar.Text = "Ключ: " + textBoxAdd.Text + " - успешно добавлен; Время: " + stopwatch.Elapsed.TotalMilliseconds * 1000000 + " нс";
                    TreeDrawingWithFoundBranch();
                }
                else
                {
                    stopwatch.Stop();
                    StatusBar.Text = "Ключ: " + textBoxAdd.Text + " - уже существует; Время: " + stopwatch.Elapsed.TotalMilliseconds * 1000000 + " нс";
                }
            }
            else
            {
                StatusBar.Text = "Поле с ключом пустое";
            }
        }

        void textBoxAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAdd_Click(sender, e);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                textBoxSearch.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                textBoxDel.Focus();
            }
        }

        void buttonDel_Click(object sender, EventArgs e)
        {
            if (textBoxDel.Text != "")
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                if (tree.Remove(textBoxDel.Text))
                {
                    stopwatch.Stop();
                    StatusBar.Text = "Ключ: " + textBoxDel.Text + " - удалён; Время: " + stopwatch.Elapsed.TotalMilliseconds * 1000000 + " нс";
                    TreeDrawingWithFoundBranch();
                }
                else
                {
                    stopwatch.Stop();
                    StatusBar.Text = "Ключ: " + textBoxDel.Text + " - не существует; Время: " + stopwatch.Elapsed.TotalMilliseconds * 1000000 + " нс";
                }
            }
            else
            {
                StatusBar.Text = "Поле с ключом пустое";
            }
        }

        void textBoxDel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonDel_Click(sender, e);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                textBoxAdd.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                textBoxSearch.Focus();
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
            else if (e.KeyCode == Keys.Up)
            {
                textBoxDel.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                textBoxAdd.Focus();
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
            textBoxAdd.Text = string.Empty;
            textBoxDel.Text = string.Empty;
            textBoxSearch.Text = string.Empty;
            StatusBar.Text = "Дерево полностью удалено";
            TreeDrawing();
        }

        void buttonRandom_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                if (!tree.Insert())
                {
                    i--;
                }
            }
            treeBox.SuspendLayout();
            TreeDrawingWithFoundBranch();
            treeBox.ResumeLayout();
            StatusBar.Text = "К дереву долбавлено 10 ключей";
        }
    }
}
