using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovelerBrowser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void browserButton_Click(object sender, EventArgs e)
        {
            using (WebBrowserForm webf = new WebBrowserForm(@"http://syosetu.com/")) 
            {
                webf.ShowDialog();
            }
        }

        private void treeviewEnabledButton_Click(object sender, EventArgs e)
        {

        }

        private void insertBookInBookshelfMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
