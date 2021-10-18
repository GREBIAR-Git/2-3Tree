namespace _2_3Tree
{
    public partial class MainForm
    {
        public void TreeDrawing()
        {
            treeBox.Nodes.Clear();
            if (tree.root != null)
            {
                tree.ShowTree(treeBox.Nodes);
            }
            treeBox.ExpandAll();
        }
        public void TreeDrawingWithFoundBranch()
        {
            Branch foundBranch = tree.Search(textBoxSearch.Text);
            if (foundBranch != null)
            {
                treeBox.Nodes.Clear();
                if (tree.root != null)
                {
                    tree.ShowTreeWithFoundBranch(treeBox.Nodes, foundBranch);
                }
                treeBox.ExpandAll();
            }
            else
            {
                TreeDrawing();
            }
        }

    }
}
