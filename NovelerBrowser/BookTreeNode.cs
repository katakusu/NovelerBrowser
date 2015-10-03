using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovelerBrowser
{
    class BookTreeNode : TreeNode
    {
        public string FolderPath { get; set; }

        public BookTreeNode() { }

        public BookTreeNode(string BookName, string FolderPath) 
        {
            this.Text = BookName;
            this.FolderPath = FolderPath;
        }

        public BookTreeNode(string BookName, string path, int selectedNode) 
        {
        
        }

        //public void (object sender, EventArgs e)
    }

    class BookTreeNodeContextMenuStrip : ContextMenuStrip
    {
        
    }
}
