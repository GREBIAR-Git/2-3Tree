﻿
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
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.textBoxDel = new System.Windows.Forms.TextBox();
            this.textBoxAdd = new System.Windows.Forms.TextBox();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.PanelMain.SuspendLayout();
            this.PanelMenuItem.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeBox
            // 
            this.treeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeBox.HideSelection = false;
            this.treeBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.treeBox.Location = new System.Drawing.Point(10, 10);
            this.treeBox.Margin = new System.Windows.Forms.Padding(10);
            this.treeBox.Name = "treeBox";
            this.treeBox.Size = new System.Drawing.Size(542, 390);
            this.treeBox.TabIndex = 100;
            this.treeBox.TabStop = false;
            // 
            // PanelMain
            // 
            this.PanelMain.ColumnCount = 2;
            this.PanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.PanelMain.Controls.Add(this.treeBox, 0, 0);
            this.PanelMain.Controls.Add(this.PanelMenuItem, 1, 0);
            this.PanelMain.Controls.Add(this.statusStrip, 0, 1);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 0);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.RowCount = 2;
            this.PanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.PanelMain.Size = new System.Drawing.Size(862, 450);
            this.PanelMain.TabIndex = 1;
            // 
            // PanelMenuItem
            // 
            this.PanelMenuItem.ColumnCount = 2;
            this.PanelMenuItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelMenuItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelMenuItem.Controls.Add(this.buttonClear, 0, 4);
            this.PanelMenuItem.Controls.Add(this.labelSearch, 0, 0);
            this.PanelMenuItem.Controls.Add(this.textBoxSearch, 0, 1);
            this.PanelMenuItem.Controls.Add(this.buttonAdd, 1, 2);
            this.PanelMenuItem.Controls.Add(this.buttonDel, 1, 3);
            this.PanelMenuItem.Controls.Add(this.textBoxDel, 0, 3);
            this.PanelMenuItem.Controls.Add(this.textBoxAdd, 0, 2);
            this.PanelMenuItem.Controls.Add(this.buttonRandom, 0, 5);
            this.PanelMenuItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMenuItem.Location = new System.Drawing.Point(572, 10);
            this.PanelMenuItem.Margin = new System.Windows.Forms.Padding(10);
            this.PanelMenuItem.Name = "PanelMenuItem";
            this.PanelMenuItem.RowCount = 7;
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelMenuItem.Size = new System.Drawing.Size(280, 390);
            this.PanelMenuItem.TabIndex = 1;
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelMenuItem.SetColumnSpan(this.buttonClear, 2);
            this.buttonClear.Location = new System.Drawing.Point(0, 153);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(277, 45);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // labelSearch
            // 
            this.labelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSearch.AutoSize = true;
            this.PanelMenuItem.SetColumnSpan(this.labelSearch, 2);
            this.labelSearch.Location = new System.Drawing.Point(3, 0);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(274, 25);
            this.labelSearch.TabIndex = 8;
            this.labelSearch.Text = "Поиск";
            this.labelSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelMenuItem.SetColumnSpan(this.textBoxSearch, 2);
            this.textBoxSearch.Location = new System.Drawing.Point(0, 25);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(280, 29);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.TextBoxSearch_TextChanged);
            this.textBoxSearch.Enter += new System.EventHandler(this.TextBoxSearch_Enter);
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxSearch_KeyDown);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(143, 64);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(134, 39);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDel.Location = new System.Drawing.Point(143, 109);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(134, 38);
            this.buttonDel.TabIndex = 4;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.ButtonDel_Click);
            // 
            // textBoxDel
            // 
            this.textBoxDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDel.Location = new System.Drawing.Point(0, 113);
            this.textBoxDel.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxDel.Name = "textBoxDel";
            this.textBoxDel.Size = new System.Drawing.Size(140, 29);
            this.textBoxDel.TabIndex = 3;
            this.textBoxDel.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.textBoxDel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxDel_KeyDown);
            // 
            // textBoxAdd
            // 
            this.textBoxAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAdd.Location = new System.Drawing.Point(0, 69);
            this.textBoxAdd.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.textBoxAdd.Name = "textBoxAdd";
            this.textBoxAdd.Size = new System.Drawing.Size(140, 29);
            this.textBoxAdd.TabIndex = 1;
            this.textBoxAdd.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.textBoxAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxAdd_KeyDown);
            // 
            // buttonRandom
            // 
            this.buttonRandom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelMenuItem.SetColumnSpan(this.buttonRandom, 2);
            this.buttonRandom.Location = new System.Drawing.Point(0, 204);
            this.buttonRandom.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(277, 70);
            this.buttonRandom.TabIndex = 6;
            this.buttonRandom.Text = "Добавить 10 случайных значений";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.ButtonRandom_Click);
            // 
            // statusStrip
            // 
            this.PanelMain.SetColumnSpan(this.statusStrip, 2);
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 410);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(862, 40);
            this.statusStrip.TabIndex = 101;
            this.statusStrip.Text = "statusStrip1";
            // 
            // StatusBar
            // 
            this.StatusBar.Margin = new System.Windows.Forms.Padding(0);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(0, 0);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 450);
            this.Controls.Add(this.PanelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(620, 385);
            this.Name = "MainForm";
            this.Text = "2-3Tree";
            this.PanelMain.ResumeLayout(false);
            this.PanelMain.PerformLayout();
            this.PanelMenuItem.ResumeLayout(false);
            this.PanelMenuItem.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeBox;
        private System.Windows.Forms.TableLayoutPanel PanelMain;
        private System.Windows.Forms.TableLayoutPanel PanelMenuItem;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.TextBox textBoxDel;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxAdd;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar;
    }
}

