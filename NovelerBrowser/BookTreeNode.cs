using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovelerBrowser
{
    public class BookTreeNode : TreeNode
    {
        private MainForm Form { get; set; }
        public string FolderPath { get; set; }
        public string Url { get; set; }

        public BookTreeNode() { }

        public BookTreeNode(MainForm form, string BookName, string FolderPath) 
        {
            this.Text = BookName;
            this.FolderPath = FolderPath;

            this.ContextMenuStrip = new BookTreeNodeContextMenuStrip(form, this);
        }
    }

    class BookTreeNodeContextMenuStrip : ContextMenuStrip
    {
        private MainForm Form { set; get; }
        private BookTreeNode node { set; get; }

        public BookTreeNodeContextMenuStrip(MainForm form, BookTreeNode node) 
        {
            this.Form = form;
            this.node = node;

            ToolStripMenuItem updateToolStripMenuItem = new ToolStripMenuItem("更新");
            updateToolStripMenuItem.Click += UpdateToolStripMenuItem_Click;
            this.Items.Add(updateToolStripMenuItem);

            ToolStripMenuItem deleteToolStripMenuItem = new ToolStripMenuItem("削除");
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            this.Items.Add(deleteToolStripMenuItem);
            //this.Click += BookTreeNodeContextMenuStrip_Click;
        }

        void BookTreeNodeContextMenuStrip_Click(object sender, EventArgs e)
        {
            Form.UpdateBookData(node.FolderPath);
        }

        void UpdateToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            MessageBox.Show("更新がクリックされた");
        }

        void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("データフォルダごと削除されます。\r\nよろしいですか？",
                "削除", MessageBoxButtons.YesNoCancel))
            {
                System.IO.Directory.Delete(node.FolderPath);
                Form.UpdateTreeView();
            }
        }
    }
}
