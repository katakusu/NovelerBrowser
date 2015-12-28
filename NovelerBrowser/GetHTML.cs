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
        /// <summary>
        /// URL先の全文をUTF-8で取得する
        /// </summary>
        /// <param name="url">取得先URL</param>
        /// <returns></returns>
        public static string GetHTMLBody(string url)
        {
            //Cursor.Current = Cursors.WaitCursor;
            string bodyTask = "";
            using (WebClient wc = new WebClient())
            {
                wc.Proxy = null;
                using (Stream st = wc.OpenRead(url))
                {
                    using (StreamReader sr = new StreamReader(st, Encoding.GetEncoding("UTF-8")))
                    {
                        bodyTask = sr.ReadToEnd();
                    }
                }
            }
            //Cursor.Current = Cursors.Default;
            return bodyTask;
        }
    }
}
