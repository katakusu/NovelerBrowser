namespace NovelerBrowser
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("本棚");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.browserButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.pickupTabPage = new System.Windows.Forms.TabPage();
            this.localbookTabPage = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.本棚BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertBookInBookshelfMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.pickupTabPage.SuspendLayout();
            this.localbookTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.本棚BToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1069, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 557);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1069, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browserButton,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 26);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1069, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // browserButton
            // 
            this.browserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.browserButton.Image = ((System.Drawing.Image)(resources.GetObject("browserButton.Image")));
            this.browserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.browserButton.Name = "browserButton";
            this.browserButton.Size = new System.Drawing.Size(23, 22);
            this.browserButton.Text = "browserButton";
            this.browserButton.Click += new System.EventHandler(this.browserButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 51);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TabControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1069, 506);
            this.splitContainer1.SplitterDistance = 356;
            this.splitContainer1.TabIndex = 3;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.localbookTabPage);
            this.TabControl.Controls.Add(this.pickupTabPage);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(356, 506);
            this.TabControl.TabIndex = 0;
            // 
            // pickupTabPage
            // 
            this.pickupTabPage.Controls.Add(this.treeView1);
            this.pickupTabPage.Location = new System.Drawing.Point(4, 22);
            this.pickupTabPage.Name = "pickupTabPage";
            this.pickupTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.pickupTabPage.Size = new System.Drawing.Size(348, 480);
            this.pickupTabPage.TabIndex = 0;
            this.pickupTabPage.Text = "ピックアップ";
            this.pickupTabPage.UseVisualStyleBackColor = true;
            // 
            // localbookTabPage
            // 
            this.localbookTabPage.Controls.Add(this.treeView2);
            this.localbookTabPage.Location = new System.Drawing.Point(4, 22);
            this.localbookTabPage.Name = "localbookTabPage";
            this.localbookTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.localbookTabPage.Size = new System.Drawing.Size(348, 480);
            this.localbookTabPage.TabIndex = 1;
            this.localbookTabPage.Text = "本棚";
            this.localbookTabPage.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(709, 506);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(342, 474);
            this.treeView1.TabIndex = 0;
            // 
            // treeView2
            // 
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.Location = new System.Drawing.Point(3, 3);
            this.treeView2.Name = "treeView2";
            treeNode1.Name = "bookshelf";
            treeNode1.Text = "本棚";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView2.Size = new System.Drawing.Size(342, 474);
            this.treeView2.TabIndex = 0;
            // 
            // 本棚BToolStripMenuItem
            // 
            this.本棚BToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertBookInBookshelfMenuItem});
            this.本棚BToolStripMenuItem.Name = "本棚BToolStripMenuItem";
            this.本棚BToolStripMenuItem.Size = new System.Drawing.Size(62, 22);
            this.本棚BToolStripMenuItem.Text = "本棚(&B)";
            // 
            // insertBookInBookshelfMenuItem
            // 
            this.insertBookInBookshelfMenuItem.Name = "insertBookInBookshelfMenuItem";
            this.insertBookInBookshelfMenuItem.Size = new System.Drawing.Size(152, 22);
            this.insertBookInBookshelfMenuItem.Text = "本棚に格納";
            this.insertBookInBookshelfMenuItem.Click += new System.EventHandler(this.insertBookInBookshelfMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 579);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "mainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.pickupTabPage.ResumeLayout(false);
            this.localbookTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton browserButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage pickupTabPage;
        private System.Windows.Forms.TabPage localbookTabPage;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.ToolStripMenuItem 本棚BToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertBookInBookshelfMenuItem;
    }
}

