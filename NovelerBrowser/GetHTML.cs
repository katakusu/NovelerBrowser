using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace NovelerBrowser
{
    class GetHTML
    {
        //=================================================================
        // GetHTMLbody
        // 引数で指定したuriのページの全文をUTF-8で取得する
        //=================================================================
        public static string GetHTMLBody(string url)
        {
            Cursor.Current = Cursors.WaitCursor;
            string body = "";
            using (WebClient wc = new WebClient())
            {
                using (Stream st = wc.OpenRead(url))
                {
                    Encoding enc = Encoding.GetEncoding("UTF-8");
                    using (StreamReader sr = new StreamReader(st, enc))
                    {
                        body = sr.ReadToEnd();
                    }
                }
            }
            Cursor.Current = Cursors.Default;
            return body;
        }
    }
}
