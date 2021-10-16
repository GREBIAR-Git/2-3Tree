
namespace _2_3Tree
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.treeBox = new System.Windows.Forms.TreeView();
            this.PanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.PanelMenuItem = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxAdd = new System.Windows.Forms.TextBox();
            this.textBoxDel = new System.Windows.Forms.TextBox();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.PanelMain.SuspendLayout();
            this.PanelMenuItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeBox
            // 
            this.treeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeBox.Location = new System.Drawing.Point(10, 10);
            this.treeBox.Margin = new System.Windows.Forms.Padding(10);
            this.treeBox.Name = "treeBox";
            this.treeBox.Size = new System.Drawing.Size(542, 430);
            this.treeBox.TabIndex = 0;
            // 
            // PanelMain
            // 
            this.PanelMain.ColumnCount = 2;
            this.PanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.PanelMain.Controls.Add(this.treeBox, 0, 0);
            this.PanelMain.Controls.Add(this.PanelMenuItem, 1, 0);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 0);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.RowCount = 1;
            this.PanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelMain.Size = new System.Drawing.Size(862, 450);
            this.PanelMain.TabIndex = 1;
            // 
            // PanelMenuItem
            // 
            this.PanelMenuItem.ColumnCount = 2;
            this.PanelMenuItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelMenuItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelMenuItem.Controls.Add(this.buttonAdd, 1, 0);
            this.PanelMenuItem.Controls.Add(this.textBoxAdd, 0, 0);
            this.PanelMenuItem.Controls.Add(this.textBoxDel, 0, 1);
            this.PanelMenuItem.Controls.Add(this.textBoxFind, 0, 2);
            this.PanelMenuItem.Controls.Add(this.buttonFind, 1, 2);
            this.PanelMenuItem.Controls.Add(this.buttonDel, 1, 1);
            this.PanelMenuItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMenuItem.Location = new System.Drawing.Point(572, 10);
            this.PanelMenuItem.Margin = new System.Windows.Forms.Padding(10);
            this.PanelMenuItem.Name = "PanelMenuItem";
            this.PanelMenuItem.RowCount = 4;
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PanelMenuItem.Size = new System.Drawing.Size(280, 430);
            this.PanelMenuItem.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(143, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(134, 39);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxAdd
            // 
            this.textBoxAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAdd.Location = new System.Drawing.Point(0, 8);
            this.textBoxAdd.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxAdd.Name = "textBoxAdd";
            this.textBoxAdd.Size = new System.Drawing.Size(140, 29);
            this.textBoxAdd.TabIndex = 1;
            this.textBoxAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAdd_KeyPress_OnlyDigit);
            // 
            // textBoxDel
            // 
            this.textBoxDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDel.Location = new System.Drawing.Point(0, 52);
            this.textBoxDel.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxDel.Name = "textBoxDel";
            this.textBoxDel.Size = new System.Drawing.Size(140, 29);
            this.textBoxDel.TabIndex = 3;
            // 
            // textBoxFind
            // 
            this.textBoxFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFind.Location = new System.Drawing.Point(0, 95);
            this.textBoxFind.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(140, 29);
            this.textBoxFind.TabIndex = 5;
            // 
            // buttonFind
            // 
            this.buttonFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFind.Location = new System.Drawing.Point(143, 92);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(134, 36);
            this.buttonFind.TabIndex = 4;
            this.buttonFind.Text = "Найти";
            this.buttonFind.UseVisualStyleBackColor = true;
            // 
            // buttonDel
            // 
            this.buttonDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDel.Location = new System.Drawing.Point(143, 48);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(134, 38);
            this.buttonDel.TabIndex = 2;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 450);
            this.Controls.Add(this.PanelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(550, 195);
            this.Name = "MainForm";
            this.Text = "2-3Tree";
            this.PanelMain.ResumeLayout(false);
            this.PanelMenuItem.ResumeLayout(false);
            this.PanelMenuItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeBox;
        private System.Windows.Forms.TableLayoutPanel PanelMain;
        private System.Windows.Forms.TableLayoutPanel PanelMenuItem;
        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.TextBox textBoxDel;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxAdd;
    }
}

