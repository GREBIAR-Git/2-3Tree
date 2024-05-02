using System.Diagnostics;

namespace _2_3Tree
{
    public partial class MainForm
    {
        void TreeDrawing()
        {
            treeBox.Nodes.Clear();
            if (tree.Root != null)
            {
                tree.ShowTree(treeBox.Nodes);
            }

            treeBox.ExpandAll();
        }

        void TreeDrawingWithFoundBranch()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Branch foundBranch = tree.Search(textBoxSearch.Text);
            stopwatch.Stop();
            if (foundBranch != null)
            {
                StatusBar.Text = @"Ключ: " + textBoxSearch.Text + @" - найден; Время: " +
                                 stopwatch.Elapsed.TotalMilliseconds * 1000000 + @" нс";
                Tree.Logger.Info(@"Ключ: " + textBoxSearch.Text + @" - найден; Время операции: " +
                                 stopwatch.Elapsed.TotalMilliseconds * 1000000 + @" нс");
                treeBox.Nodes.Clear();
                if (tree.Root != null)
                {
                    tree.ShowTreeWithFoundBranch(treeBox.Nodes, foundBranch);
                }

                treeBox.ExpandAll();
            }
            else
            {
                StatusBar.Text = @"Ключ: " + textBoxSearch.Text + @" - не найден; Время: " +
                                 stopwatch.Elapsed.TotalMilliseconds * 1000000 + @" нс";
                Tree.Logger.Info(@"Ключ: " + textBoxSearch.Text + @" - не найден; Время операции: " +
                                 stopwatch.Elapsed.TotalMilliseconds * 1000000 + @" нс");
                TreeDrawing();
            }
        }
    }
}