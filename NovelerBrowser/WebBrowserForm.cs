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
    public partial class WebBrowserForm : Form
    {
        private string url { set; get; }

        public WebBrowserForm()
        {
            InitializeComponent();
        }

        public WebBrowserForm(string url) 
        {
            InitializeComponent();
            this.url = url;
        }

        private void WebBrowserForm_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(url);
        }
    }
}
