using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NovelerBrowser.data
{
    public class Chapter
    {
        public int id { set; get; }
        public DateTime date { set; get; }
        public string url { set; get; }
        public string title { set; get; }
        public string body { set; get; }

        public Chapter() { }

        public Chapter(int id, DateTime date, string url, string title) 
        {
            this.id = id;
            this.date = date;
            this.url = url;
            this.title = title;

            var bodyHtmlDoc = new HtmlAgilityPack.HtmlDocument();
            string webBody = "";
            using(WebClient wc = new WebClient())
            {
                wc.Proxy = null;
                using (Stream st = wc.OpenRead(url))
                {
                    Encoding enc = Encoding.GetEncoding("UTF-8");
                    using (StreamReader sr = new StreamReader(st, enc))
                    {
                        webBody = sr.ReadToEnd();
                    }
                }
            }
            bodyHtmlDoc.LoadHtml(webBody);
            body = bodyHtmlDoc.DocumentNode.SelectSingleNode(@"//div[@id=""novel_honbun""]").InnerText.Trim();
        }
    }
}
