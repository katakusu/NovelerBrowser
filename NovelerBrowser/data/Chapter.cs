using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelerBrowser.data
{
    class Chapter
    {
        private int id { set; get; }
        private DateTime date { set; get; }
        private string url { set; get; }
        private string title { set; get; }
        private string body { set; get; }

        public Chapter(DateTime date, string url) 
        {
            this.date = date;
            this.url = url;
        }
    }
}
