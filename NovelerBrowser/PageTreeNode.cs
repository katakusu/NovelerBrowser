using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovelerBrowser
{
    class PageTreeNode : TreeNode
    {
        public string FilePath { get; set; }

        public PageTreeNode() { }

        public PageTreeNode(string BookName, string FilePath) 
        {
            this.Text = BookName;
            this.FilePath = FilePath;
        }
    }
}
