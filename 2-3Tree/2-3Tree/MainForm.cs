using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace _2_3Tree
{
    public partial class MainForm : Form
    {
        Tree tree;

        public MainForm()
        {
            InitializeComponent();
            var config = new LoggingConfiguration();

            var logfile = new FileTarget("logfile") { FileName = "file.txt" };


            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            //config.AddRule(LogLevel.Info, LogLevel.Info, logfile);
 
            LogManager.Configuration = config;

            StatusBar.Text = @"Программа инициализирована";
            Tree.Logger.Debug("Программа инициализирована");
            tree = new Tree();
            //timeTest();
            //sizeTest();
        }

        void TimeTest()
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int f = 1; f < 4000; f++)
            {
                TestInsert(f);
                stopwatch.Start();
                TestSearch(f);
                stopwatch.Stop();
                tree = new Tree();
                File.AppendAllText("time.txt", stopwatch.Elapsed.TotalMilliseconds * 1000000 + Environment.NewLine);
                stopwatch.Reset();
            }
        }

        void SizeTest()
        {
            int r = 0;
            for (int f = 1; f < 4000; f++)
            {
                TestInsert(f);
                r += TestSearchS(f);
                tree = new Tree();
                File.AppendAllText("size.txt", r + Environment.NewLine);
                r = 0;
            }
        }

        void TestInsert(int count)
        {
            for (int i = 1; i < count + 1; i++)
            {
                tree.Insert(i.ToString());
            }
        }

        int TestSearchS(int count)
        {
            int countBranch = 0, s = 0;
            for (int i = 1; i < count + 1; i++)
            {
                tree.Search(new Key(i.ToString()), tree.Root, ref countBranch, ref s);
            }

            return countBranch;
        }

        void TestSearch(int count)
        {
            for (int i = 1; i < count + 1; i++)
            {
                tree.Search(new Key(i.ToString()), tree.Root);
            }
        }

        void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxAdd.Text != "")
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                if (tree.Insert(textBoxAdd.Text))
                {
                    stopwatch.Stop();
                    StatusBar.Text = @"Ключ: " + textBoxAdd.Text + @" - успешно добавлен; Время: " +
                                     stopwatch.Elapsed.TotalMilliseconds * 1000000 + @" нс";
                    Tree.Logger.Info("Ключ: " + textBoxAdd.Text + @" - успешно добавлен; Время операции: " +
                                     stopwatch.Elapsed.TotalMilliseconds * 1000000 + @" нс");
                    TreeDrawing();
                }
                else
                {
                    stopwatch.Stop();
                    StatusBar.Text = @"Ключ: " + textBoxAdd.Text + @" - уже существует; Время: " +
                                     stopwatch.Elapsed.TotalMilliseconds * 1000000 + @" нс";
                    Tree.Logger.Info(@"Ключ: " + textBoxAdd.Text + @" - уже существует; Время операции: " +
                                     stopwatch.Elapsed.TotalMilliseconds * 1000000 + @" нс");
                }
            }
            else
            {
                StatusBar.Text = @"Поле с ключом пустое";
                Tree.Logger.Warn("Поле с ключом пустое");
            }
        }

        void TextBoxAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonAdd_Click(sender, e);
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

        void ButtonDel_Click(object sender, EventArgs e)
        {
            if (textBoxDel.Text != "")
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                if (tree.Remove(textBoxDel.Text))
                {
                    stopwatch.Stop();
                    StatusBar.Text = @"Ключ: " + textBoxDel.Text + @" - удалён; Время: " +
                                     stopwatch.Elapsed.TotalMilliseconds * 1000000 + @" нс";
                    Tree.Logger.Info(@"Ключ: " + textBoxDel.Text + @" - удалён; Время операции: " +
                                     stopwatch.Elapsed.TotalMilliseconds * 1000000 + @" нс");
                    TreeDrawing();
                }
                else
                {
                    stopwatch.Stop();
                    StatusBar.Text = @"Ключ: " + textBoxDel.Text + @" - не существует; Время: " +
                                     stopwatch.Elapsed.TotalMilliseconds * 1000000 + @" нс";
                    Tree.Logger.Info("Ключ: " + textBoxDel.Text + @" - не существует; Время операции: " +
                                     stopwatch.Elapsed.TotalMilliseconds * 1000000 + @" нс");
                }
            }
            else
            {
                StatusBar.Text = @"Поле с ключом пустое";
                Tree.Logger.Warn("Поле с ключом пустое");
            }
        }

        void TextBoxDel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonDel_Click(sender, e);
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

        void TextBox_TextChanged(object sender, EventArgs e)
        {
            RemoveSpecialSymbols(sender);
        }

        void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch.Text != string.Empty)
            {
                TreeDrawingWithFoundBranch();
            }
            else
            {
                TreeDrawing();
            }
        }

        void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
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

        void ButtonClear_Click(object sender, EventArgs e)
        {
            tree = new Tree();
            textBoxAdd.Text = string.Empty;
            textBoxDel.Text = string.Empty;
            textBoxSearch.Text = string.Empty;
            StatusBar.Text = @"Дерево полностью удалено";
            Tree.Logger.Info("Дерево полностью удалено");
            TreeDrawing();
        }

        void ButtonRandom_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                if (!tree.Insert())
                {
                    i--;
                }
            }

            treeBox.SuspendLayout();
            TreeDrawing();
            treeBox.ResumeLayout();
            StatusBar.Text = @"К дереву добавлено 10 ключей";
            Tree.Logger.Info("К дереву добавлено 10 ключей");
        }

        void TextBoxSearch_Enter(object sender, EventArgs e)
        {
            if (textBoxSearch.Text != string.Empty)
            {
                TreeDrawingWithFoundBranch();
            }
        }
    }
}