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
using System.Web;

namespace NovelerBrowser
{
    public partial class MainForm : Form
    {
        private string WorkFolderPath = @"./Archive/";
        private int SpllitterDistance3 = 130;

        public MainForm()
        {
            InitializeComponent();

            if (!Directory.Exists(WorkFolderPath)) 
            {
                Directory.CreateDirectory(WorkFolderPath);
            }


        }

        //==========================================================================
        // InsertBookInBookshelfMenuItem_Click
        //  [本棚]-[本棚に格納]をクリックすると呼び出される
        //      ツリービューを更新する
        //==========================================================================
        public void UpdateTreeView() 
        {
            BookshelfTreeView.Nodes["BookshelfTreeNode"].Nodes.Clear();
            string[] Subfolders = Directory.GetDirectories(WorkFolderPath, "*", SearchOption.TopDirectoryOnly);
            foreach (string folder in Subfolders)
            {
                MatchCollection FolderNameMatchCollection = Regex.Matches(folder, @"Archive/(?<name>.+)$");
                Console.WriteLine();

                BookTreeNode Node = new BookTreeNode(this, FolderNameMatchCollection[0].Groups["name"].ToString().Trim(), folder);
                int id = BookshelfTreeView.Nodes["BookshelfTreeNode"].Nodes.Add(Node);

                int fileNum = 1;
                while (File.Exists(WorkFolderPath + Node.Text + "/" + fileNum.ToString() + ".txt"))
                {
                    using (StreamReader sr = new StreamReader(WorkFolderPath + Node.Text + "/" + fileNum.ToString() + ".txt", Encoding.Default)) 
                    {
                        string subTitle = sr.ReadLine().Trim();
                        sr.ReadLine();
                        sr.ReadLine();

                        PageTreeNode pageNode = new PageTreeNode(subTitle, WorkFolderPath + Node.Text + "/" + fileNum.ToString() + ".txt");
                        BookshelfTreeView.Nodes["BookshelfTreeNode"].Nodes[id].Nodes.Add(pageNode);
                    }
                    fileNum++;
                }
            }
        }


        private void LoadBookshelf()
        {
            UpdateTreeView();
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


        //==========================================================================
        // GetBookDataFromWeb
        //  指定されたurlから小説データを取得しファイルに保存する
        //==========================================================================
        private void GetBookDataFromWeb(String novelUrl) 
        {
            try
            {
                string body = "";
                using (WebClient wc = new WebClient())
                {
                    wc.Proxy = null;
                    using (Stream st = wc.OpenRead(novelUrl))
                    {
                        Encoding enc = Encoding.GetEncoding("UTF-8");
                        using (StreamReader sr = new StreamReader(st, enc))
                        {
                            body = sr.ReadToEnd();
                        }
                    }
                }

                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(body);
                Console.WriteLine("HTML Doc 構築完了");

                var NovelTitleNode = htmlDoc.DocumentNode.SelectNodes(@"//p[@class=""novel_title""]");
                var WriterNameNode = htmlDoc.DocumentNode.SelectNodes(@"//div[@class=""novel_writername""]//a");
                var NovelSynopsisNode = htmlDoc.DocumentNode.SelectNodes(@"//div[@id=""novel_ex""]");
                var articles = htmlDoc.DocumentNode.SelectNodes(@"//dl[@class=""novel_sublist2""]")
                    .Select(a => new
                    {
                        Subtitle = a.SelectNodes(@"//dd[@class=""subtitle""]"),
                        Url = a.InnerHtml.Trim(),
                        Title = a.InnerText.Trim(),
                    });

                string novelTitle = NovelTitleNode[0].InnerText.Trim();
                string WriterName = WriterNameNode[0].InnerText.Trim();
                string NovelSynopsis = NovelSynopsisNode[0].InnerText.Trim();

                Console.WriteLine("取り出し完了");

                if (!Directory.Exists(WorkFolderPath + novelTitle + "\\"))
                {
                    Directory.CreateDirectory(WorkFolderPath + novelTitle + "\\");
                }

                if (!File.Exists(WorkFolderPath + novelTitle + "\\" + "data.dat"))
                {
                    using (StreamWriter sw = new StreamWriter(WorkFolderPath + novelTitle + "\\" + "data.dat", true, Encoding.GetEncoding("shift_jis")))
                    {
                        sw.WriteLine(novelTitle);
                        sw.WriteLine(WriterName);
                        sw.WriteLine(novelUrl);
                        sw.WriteLine(HttpUtility.HtmlDecode(NovelSynopsis));
                    }
                }

                foreach (var a in articles)
                {
                    Regex TitleRegex = new Regex(@"(?<subtitle>.*)\n\n(?<date>\d\d\d\d年\d{1,2}月\d{1,2}日)\n\n.*");
                    Regex UrlRegex = new Regex(@"^<dd class=\""subtitle\""><a href=\""(?<href>[a-z0-9/])\"">");

                    MatchCollection TitleMatchCollection = Regex.Matches(a.Title, @"(?<subtitle>.*)\n?");
                    MatchCollection UrlMatchCollection = Regex.Matches(a.Url, @"<a href=\""(?<url>[a-z0-9/]*)\""");

                    MatchCollection novelTextNameNumberCollection = Regex.Matches(UrlMatchCollection[0].Groups["url"].ToString().Trim(), @".*/(?<num>[0-9]+)/$");

                    string novelTextName = novelTextNameNumberCollection[0].Groups["num"].ToString().Trim();

                    if (!File.Exists(WorkFolderPath + novelTitle + "\\" + novelTextName + ".txt"))
                    {
                        using (StreamWriter sw = new StreamWriter(WorkFolderPath + novelTitle + "\\" + novelTextName + ".txt",
                            true, Encoding.GetEncoding("shift_jis")))
                        {
                            sw.WriteLine(TitleMatchCollection[0].ToString().Trim());
                            sw.WriteLine(TitleMatchCollection[2].ToString().Trim());
                            sw.WriteLine(novelUrl + novelTextName + "/");

                            var bodyHtmlDoc = new HtmlAgilityPack.HtmlDocument();
                            bodyHtmlDoc.LoadHtml(GetHTML.GetHTMLBody(novelUrl + novelTextName + "\\"));
                            var honbun = bodyHtmlDoc.DocumentNode.SelectNodes(@"//div[@id=""novel_honbun""]")
                                    .Select(b => new
                                    {
                                        Text = b.InnerText.Trim(),
                                    });

                            foreach (var b in honbun)
                            {
                                sw.WriteLine(b.Text);
                            }

                        }
                    }

                }
            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.ToString());
            }
        }

        //==========================================================================
        // InsertBookInBookshelfMenuItem_Click
        //  [本棚]-[本棚に格納]をクリックすると呼び出される
        //==========================================================================
        private void InsertBookInBookshelfMenuItem_Click(object sender, EventArgs e)
        {
            using (InsertBookFromUriForm form = new InsertBookFromUriForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    GetBookDataFromWeb(form.GetTextBoxText());
                }
            }
            UpdateTreeView();
        }

        //=========================================================================
        // UpdateBookData
        // 既に取得済みのデータを削除して、もう一度取得する
        //=========================================================================
        public void UpdateBookData(string BookPath) 
        {
            MessageBox.Show(BookPath);
            
            // data.datから対象urlを取得
            String bookUrl = "";
            if (File.Exists(BookPath + "\\data.dat"))
            {
                using (StreamReader sr = new StreamReader(BookPath + "\\data.dat", Encoding.Default))
                {
                    sr.ReadLine();
                    sr.ReadLine();
                    bookUrl = sr.ReadLine().Trim();
                }
            }
            else 
            {
                MessageBox.Show("data.datが存在しません。");
                return;
            }

            // ファイルをすべて削除する
            String[] fileList = Directory.GetFiles(BookPath);
            foreach (String delFile in fileList) 
            {
                try
                {
                    File.Delete(delFile);
                }
                catch (Exception exce) 
                {
                    MessageBox.Show(exce.ToString());
                }
            }

            // 再取得
            GetBookDataFromWeb(bookUrl);

            UpdateTreeView();
        }

        //=========================================================================
        // BookshelfTreeView_AfterSelect
        // ツリービュー内のノードを選択したときに呼び出される
        //=========================================================================
        private async void BookshelfTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Level)
            {
                case 0:
                    BookmarkToolStripButton.Enabled = false;
                    break;

                case 1:
                    if (e.Node is BookTreeNode)
                    {
                        BookTreeNode bnode = (BookTreeNode)e.Node;
                        richTextBox1.ResetText();

                        using (StreamReader sr = new StreamReader(bnode.FolderPath + @"\\data.dat", System.Text.Encoding.Default))
                        {
                            richTextBox1.AppendText("[タイトル]：" + sr.ReadLine() + "\r\n");
                            richTextBox1.AppendText("[作者]：" + sr.ReadLine() + "\r\n");
                            richTextBox1.AppendText("[URL]：" + sr.ReadLine() + "\r\n");
                            richTextBox1.AppendText("================================\r\n");
                            while (sr.Peek() >= 0)
                            {
                                string buffer = sr.ReadLine();
                                richTextBox1.AppendText(buffer + "\r\n");
                            }
                        }
                        BookmarkToolStripButton.Enabled = false;

                    }
                    else if (e.Node is RankingTreeNode) 
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        RankingTreeNode rankingNode = (RankingTreeNode)e.Node;
                        HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

                        string body = "";
                        Cursor.Current = Cursors.Default;
                        using (WebClient wc = new WebClient())
                        {
                            wc.Proxy = null;
                            using (Stream st = await wc.OpenReadTaskAsync(rankingNode.url))
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                Encoding enc = Encoding.GetEncoding("UTF-8");
                                using (StreamReader sr = new StreamReader(st, enc))
                                {
                                    body = sr.ReadToEnd();
                                }
                            }
                        }
                        Cursor.Current = Cursors.Default;
                        htmlDoc.LoadHtml(body);
                        rankingNode.GetRankingInfo(htmlDoc);
                    }
                    break;

                case 2:
                    if (e.Node is PageTreeNode)
                    {
                        PageTreeNode bNode = (PageTreeNode)e.Node;
                        richTextBox1.ResetText();
                        using (StreamReader sr = new StreamReader(bNode.FilePath, Encoding.Default))
                        {
                            string pageText = "";
                            pageText += "[サブタイトル]：" + sr.ReadLine() + "\r\n";
                            sr.ReadLine();
                            pageText += "[URL]：" + sr.ReadLine() + "\r\n";
                            pageText += "===============\r\n";
                            while (sr.Peek() >= 0)
                            {
                                pageText += sr.ReadLine() + "\r\n";
                            }
                            richTextBox1.AppendText(pageText);
                        }

                        BookmarkToolStripButton.Enabled = true;
                    }
                    break;
            }
        }

        //=========================================================================
        // BookmarkToolStripButton_Click
        // 栞ボタンをクリックしたときに呼び出される
        //=========================================================================
        private void BookmarkToolStripButton_Click(object sender, EventArgs e)
        {
            if (BookmarkToolStripButton.Checked)
            {

            }
            else 
            {
                
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // [本棚]にノードを追加する
            LoadBookshelf();

            // [ランキング]にノードを追加する
            RankingTreeNode dailyRankingNode = new RankingTreeNode(this, "http://yomou.syosetu.com/rank/secondlist/type/daily_total/");
            dailyRankingNode.Name = "DailyRankingTreeNode";
            dailyRankingNode.Text = "日間ランキング";
            BookshelfTreeView.Nodes["RankingTreeNode"].Nodes.Add(dailyRankingNode);

            RankingTreeNode weeklyRankingNode = new RankingTreeNode(this, "http://yomou.syosetu.com/rank/secondlist/type/weekly_total/");
            weeklyRankingNode.Name = "WeeklyRankingTreeNode";
            weeklyRankingNode.Text = "週間ランキング";
            BookshelfTreeView.Nodes["RankingTreeNode"].Nodes.Add(weeklyRankingNode);

        }

        public void ClearListViewItems()
        {
            listView.Items.Clear();
        }

        public void AddListViewItem(bool gotten, String title, String author, String genre)
        {
            String mark = "○";
            if (!gotten)
                mark = "";
            ListViewItem item = new ListViewItem(mark);
            item.SubItems.Add(title);
            item.SubItems.Add(author);
            item.SubItems.Add(genre);
            listView.Items.Add(item);
        }


        private void ListViewHeightToolStripButton_Click(object sender, EventArgs e)
        {
            if (ListViewHeightToolStripButton.Checked)
            {
                this.SpllitterDistance3 = splitContainer3.SplitterDistance;
                splitContainer3.SplitterDistance = 0;
                ListViewHeightToolStripButton.Checked = false;
            }
            else 
            {
                splitContainer3.SplitterDistance = this.SpllitterDistance3;
                ListViewHeightToolStripButton.Checked = true;
            }
        }
    }
}
