using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _2_3Tree
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            Tree tree = new Tree();
            tree.Insert("фис");
            tree.Insert("1");
            tree.PrintRoot();
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
    }
}
