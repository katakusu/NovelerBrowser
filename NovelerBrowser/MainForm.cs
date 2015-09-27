using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace NovelerBrowser
{
    public partial class MainForm : Form
    {
        private string WorkFolderPath = @"./Archive/";


        public MainForm()
        {
            InitializeComponent();

            if (!Directory.Exists(WorkFolderPath)) 
            {
                Directory.CreateDirectory(WorkFolderPath);
            }

            LoadBookshelf();
        }


        // getHTMLbody
        // 引数で指定したuriのページの全文をUTF-8で取得する
        private string GetHTMLBody(string url) 
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

        private bool LoadBookshelf()
        {
            string[] Subfolders = Directory.GetDirectories(WorkFolderPath, "*", SearchOption.TopDirectoryOnly);
            foreach (string folder in Subfolders) 
            {
                MatchCollection FolderNameMatchCollection = Regex.Matches(folder, @"Archive/(?<name>.+)$");
                Console.WriteLine();

                TreeNode Node = new TreeNode(FolderNameMatchCollection[0].Groups["name"].ToString().Trim());
                BookshelfTreeView.Nodes["BookshelfTreeNode"].Nodes.Add(Node);

            }
            return true;
        }

        


        private void BrowserButton_Click(object sender, EventArgs e)
        {
            using (WebBrowserForm webf = new WebBrowserForm(@"http://syosetu.com/")) 
            {
                webf.ShowDialog();
            }
        }

        private void TreeviewEnabledButton_Click(object sender, EventArgs e)
        {

        }

        private void InsertBookInBookshelfMenuItem_Click(object sender, EventArgs e)
        {
            using (InsertBookFromUriForm form = new InsertBookFromUriForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // 
                    try
                    {
                        string NovelUrl = form.GetTextBoxText();
                        var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                        htmlDoc.LoadHtml(GetHTMLBody(NovelUrl));
                        Console.WriteLine("HTML Doc 構築完了");

                        var NovelTitleNode = htmlDoc.DocumentNode.SelectNodes(@"//p[@class=""novel_title""]");
                        var WriterNameNode = htmlDoc.DocumentNode.SelectNodes(@"//div[@class=""novel_writername""]//a");
                        var NovelSynopsisNode = htmlDoc.DocumentNode.SelectNodes(@"//div[@id=""novel_ex""]");
                        var articles = htmlDoc.DocumentNode.SelectNodes(@"//dl[@class=""novel_sublist2""]")
                            .Select(a => new
                            {
                                Subtitle = a.SelectNodes(@"//dd[@class=""subtitle""]"),
                                //Url = a.Attributes["href"].Value.Trim(),
                                Url = a.InnerHtml.Trim(),
                                Title = a.InnerText.Trim(),
                            });

                        string NovelTitle = NovelTitleNode[0].InnerText.Trim();
                        string WriterName = WriterNameNode[0].InnerText.Trim();
                        string NovelSynopsis = NovelSynopsisNode[0].InnerText.Trim();

                        Console.WriteLine("取り出し完了");

                        if (!Directory.Exists(WorkFolderPath+NovelTitle+"\\")) 
                        {
                            Directory.CreateDirectory(WorkFolderPath+NovelTitle+"\\");
                        }

                        if (!File.Exists(WorkFolderPath + NovelTitle + "\\" + "data.dat"))
                        {
                            using (StreamWriter sw = new StreamWriter(WorkFolderPath + NovelTitle + "\\" + "data.dat", true, Encoding.GetEncoding("shift_jis")))
                            {
                                sw.WriteLine(NovelTitle);
                                sw.WriteLine(WriterName);
                                sw.WriteLine(NovelUrl);
                                sw.WriteLine(NovelSynopsis);
                            }
                        }

                        foreach (var a in articles)
                        {
                            richTextBox1.Text += "==========\n\r";
                            richTextBox1.Text += a.Title;
                            richTextBox1.Text += "------\n\r";
                            richTextBox1.Text += a.Url;

                            Regex TitleRegex = new Regex(@"(?<subtitle>.*)\n\n(?<date>\d\d\d\d年\d{1,2}月\d{1,2}日)\n\n.*");
                            Regex UrlRegex = new Regex(@"^<dd class=\""subtitle\""><a href=\""(?<href>[a-z0-9/])\"">");

                            MatchCollection TitleMatchCollection = Regex.Matches(a.Title, @"(?<subtitle>.*)\n?");
                            MatchCollection UrlMatchCollection = Regex.Matches(a.Url, @"<a href=\""(?<url>[a-z0-9/]*)\""");

                            Console.WriteLine("Subtitle:{0}", TitleMatchCollection[0].ToString().Trim());
                            Console.WriteLine("Date:{0}", TitleMatchCollection[2].ToString().Trim());
                            Console.WriteLine("Url:{0}", UrlMatchCollection[0].Groups["url"].ToString().Trim());
                            Console.WriteLine();
                        }
                    }
                    catch(Exception exce)
                    {
                        MessageBox.Show("InsertBookInBookshelfMenuItem_Click:エラー");   
                    }

                }
            }

        }
    }
}
