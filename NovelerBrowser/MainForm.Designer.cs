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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("舞い上がる黒焔");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("天啓");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("テストノード", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("月間ランキング");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("四半期ランキング");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("年間ランキング");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("ランキング", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Item1");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("item2");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.本棚BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertBookInBookshelfMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.browserButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ListViewHeightToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.localbookTabPage = new System.Windows.Forms.TabPage();
            this.BookshelfTreeView = new System.Windows.Forms.TreeView();
            this.pickupTabPage = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.BookmarkToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.localbookTabPage.SuspendLayout();
            this.pickupTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.本棚BToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(860, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
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
            this.insertBookInBookshelfMenuItem.Size = new System.Drawing.Size(136, 22);
            this.insertBookInBookshelfMenuItem.Text = "本棚に格納";
            this.insertBookInBookshelfMenuItem.Click += new System.EventHandler(this.InsertBookInBookshelfMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 557);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(860, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browserButton,
            this.toolStripSeparator1,
            this.ListViewHeightToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 26);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(860, 25);
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
            this.browserButton.Click += new System.EventHandler(this.BrowserButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ListViewHeightToolStripButton
            // 
            this.ListViewHeightToolStripButton.Checked = true;
            this.ListViewHeightToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ListViewHeightToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ListViewHeightToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ListViewHeightToolStripButton.Image")));
            this.ListViewHeightToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ListViewHeightToolStripButton.Name = "ListViewHeightToolStripButton";
            this.ListViewHeightToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ListViewHeightToolStripButton.Text = "toolStripButton2";
            this.ListViewHeightToolStripButton.Click += new System.EventHandler(this.ListViewHeightToolStripButton_Click);
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
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(860, 506);
            this.splitContainer1.SplitterDistance = 286;
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
            this.TabControl.Size = new System.Drawing.Size(286, 506);
            this.TabControl.TabIndex = 0;
            // 
            // localbookTabPage
            // 
            this.localbookTabPage.Controls.Add(this.BookshelfTreeView);
            this.localbookTabPage.Location = new System.Drawing.Point(4, 22);
            this.localbookTabPage.Name = "localbookTabPage";
            this.localbookTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.localbookTabPage.Size = new System.Drawing.Size(278, 480);
            this.localbookTabPage.TabIndex = 1;
            this.localbookTabPage.Text = "本棚";
            this.localbookTabPage.UseVisualStyleBackColor = true;
            // 
            // BookshelfTreeView
            // 
            this.BookshelfTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BookshelfTreeView.Location = new System.Drawing.Point(3, 3);
            this.BookshelfTreeView.Name = "BookshelfTreeView";
            treeNode1.Name = "BookshelfTreeNode";
            treeNode1.Text = "本棚";
            treeNode2.Name = "TestBookNode1";
            treeNode2.Text = "舞い上がる黒焔";
            treeNode3.Name = "TestBookNode2";
            treeNode3.Text = "天啓";
            treeNode4.Name = "TestNode";
            treeNode4.Text = "テストノード";
            treeNode5.Name = "MonthlyRankingTreeNode";
            treeNode5.Text = "月間ランキング";
            treeNode6.Name = "QuarterRankingTreeNode";
            treeNode6.Text = "四半期ランキング";
            treeNode7.Name = "YearlyRankingTreeNode";
            treeNode7.Text = "年間ランキング";
            treeNode8.Name = "RankingTreeNode";
            treeNode8.Text = "ランキング";
            this.BookshelfTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4,
            treeNode8});
            this.BookshelfTreeView.Size = new System.Drawing.Size(272, 474);
            this.BookshelfTreeView.TabIndex = 0;
            this.BookshelfTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.BookshelfTreeView_AfterSelect);
            // 
            // pickupTabPage
            // 
            this.pickupTabPage.Controls.Add(this.treeView1);
            this.pickupTabPage.Location = new System.Drawing.Point(4, 22);
            this.pickupTabPage.Name = "pickupTabPage";
            this.pickupTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.pickupTabPage.Size = new System.Drawing.Size(278, 480);
            this.pickupTabPage.TabIndex = 0;
            this.pickupTabPage.Text = "ピックアップ";
            this.pickupTabPage.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(272, 474);
            this.treeView1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.listView);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer3.Size = new System.Drawing.Size(570, 506);
            this.splitContainer3.SplitterDistance = 130;
            this.splitContainer3.TabIndex = 2;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(570, 130);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "タイトル";
            this.columnHeader2.Width = 300;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "作者";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ジャンル";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer2.Size = new System.Drawing.Size(570, 372);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BookmarkToolStripButton,
            this.toolStripButton1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(570, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // BookmarkToolStripButton
            // 
            this.BookmarkToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BookmarkToolStripButton.Enabled = false;
            this.BookmarkToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("BookmarkToolStripButton.Image")));
            this.BookmarkToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BookmarkToolStripButton.Name = "BookmarkToolStripButton";
            this.BookmarkToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.BookmarkToolStripButton.Text = "栞";
            this.BookmarkToolStripButton.Click += new System.EventHandler(this.BookmarkToolStripButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox1.Size = new System.Drawing.Size(570, 343);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 579);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "mainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.localbookTabPage.ResumeLayout(false);
            this.pickupTabPage.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
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
        private System.Windows.Forms.TreeView BookshelfTreeView;
        private System.Windows.Forms.ToolStripMenuItem 本棚BToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertBookInBookshelfMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton BookmarkToolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripButton ListViewHeightToolStripButton;
    }
}

