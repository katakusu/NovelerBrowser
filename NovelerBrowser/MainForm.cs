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
using System.Xml.Serialization;
using NovelerBrowser.data;

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

        /// <summary>
        /// �t�@�C�����Ď擾���ăc���[�r���[�̖{�I�̃m�[�h���ĕ`�悷��
        /// </summary>
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

        /// <summary>
        /// [�u���E�U�\��]�{�^�����N���b�N�����Ƃ��Ăяo�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// URL���珬���f�[�^���擾���ăt�@�C���ɕۑ�����
        /// </summary>
        /// <param name="body">�擾�����e�L�X�g</param>
        /// <param name="novelUrl">�擾����URL</param>
        private void GetBookDataFromWeb(String body, String novelUrl) 
        {
            try
            {
                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(body);
                Console.WriteLine("HTML Doc �\�z����");

                var NovelTitleNode = htmlDoc.DocumentNode.SelectNodes(@"//p[@class=""novel_title""]");
                var WriterNameNode = htmlDoc.DocumentNode.SelectSingleNode(@"//div[@class=""novel_writername""]//a");
                if (WriterNameNode == null) 
                {
                    WriterNameNode = htmlDoc.DocumentNode.SelectSingleNode(@"//div[@class=""novel_writername""]");
                    WriterNameNode.InnerText.Trim();
                }
                var NovelSynopsisNode = htmlDoc.DocumentNode.SelectNodes(@"//div[@id=""novel_ex""]");
                var articles = htmlDoc.DocumentNode.SelectNodes(@"//dl[@class=""novel_sublist2""]")
                    .Select(a => new
                    {
                        Subtitle = a.SelectNodes(@"//dd[@class=""subtitle""]"),
                        Url = a.InnerHtml.Trim(),
                        Title = a.InnerText.Trim(),
                    });

                string novelTitle = NovelTitleNode[0].InnerText.Trim();
                string WriterName = WriterNameNode.InnerText.Trim().Replace("��ҁF", "");
                string NovelSynopsis = NovelSynopsisNode[0].InnerText.Trim();

                Console.WriteLine("���o������");

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

                // �e�͂̕ۑ�
                int chapterId = 1;
                foreach (var a in articles)
                {
                    Regex TitleRegex = new Regex(@"(?<subtitle>.*)\n\n(?<date>\d\d\d\d�N\d{1,2}��\d{1,2}��)\n\n.*");
                    Regex UrlRegex = new Regex(@"^<dd class=\""subtitle\""><a href=\""(?<href>[a-z0-9/])\"">");

                    MatchCollection TitleMatchCollection = Regex.Matches(a.Title, @"(?<subtitle>.*)\n?");
                    MatchCollection UrlMatchCollection = Regex.Matches(a.Url, @"<a href=\""(?<url>[a-z0-9/]*)\""");

                    MatchCollection novelTextNameNumberCollection = Regex.Matches(UrlMatchCollection[0].Groups["url"].ToString().Trim(), @".*/(?<num>[0-9]+)/$");

                    string novelTextName = novelTextNameNumberCollection[0].Groups["num"].ToString().Trim();

                    string chapterTitle = TitleMatchCollection[0].ToString().Trim();
                    DateTime dateTime = DateTime.Parse(TitleMatchCollection[2].ToString().Trim()
                        , new System.Globalization.CultureInfo("ja-JP")
                        , System.Globalization.DateTimeStyles.AssumeLocal);

                    // XML�ŕۑ�===
                    if (!File.Exists(WorkFolderPath + novelTitle + "\\" + novelTextName + ".xml"))
                    {
                        Chapter chapter = new Chapter(chapterId, dateTime, novelUrl + novelTextName + "\\", chapterTitle);
                        chapterId++;
                        XmlSerializer xmls = new XmlSerializer(typeof(Chapter));
                        using (StreamWriter sw = new StreamWriter(WorkFolderPath + novelTitle + "\\" + novelTextName + ".xml", false, Encoding.GetEncoding("shift_jis")))
                        {
                            xmls.Serialize(sw, chapter);
                        }
                        
                    }//===XML END===

                    // TXT�ŕۑ�===
                    if (!File.Exists(WorkFolderPath + novelTitle + "\\" + novelTextName + ".txt"))
                    {
                        using (StreamWriter sw = new StreamWriter(WorkFolderPath + novelTitle + "\\" + novelTextName + ".txt",
                            true, Encoding.GetEncoding("shift_jis")))
                        {
                            sw.WriteLine(chapterTitle);
                            sw.WriteLine(dateTime.Year+"/"+dateTime.Month+"/"+dateTime.Day);
                            sw.WriteLine(novelUrl + novelTextName + "/");

                            var bodyHtmlDoc = new HtmlAgilityPack.HtmlDocument();
                            var chapterString = GetHTML.GetHTMLBody(novelUrl + novelTextName + "\\").Result;
                            bodyHtmlDoc.LoadHtml(chapterString);
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
                    }//===TXT END===

                }
            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.ToString());
            }
        }

        //==========================================================================
        // InsertBookInBookshelfMenuItem_Click
        //  [�{�I]-[�{�I�Ɋi�[]���N���b�N����ƌĂяo�����
        //==========================================================================
        private async void InsertBookInBookshelfMenuItem_Click(object sender, EventArgs e)
        {
            using (InsertBookFromUriForm form = new InsertBookFromUriForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.Proxy = null;
                        using (Stream st = await wc.OpenReadTaskAsync(form.GetTextBoxText()))
                        {
                            using (StreamReader sr = new StreamReader(st, Encoding.GetEncoding("UTF-8")))
                            {
                                GetBookDataFromWeb(sr.ReadToEnd(), form.GetTextBoxText());
                            }
                        }
                    }
                }
            }
            UpdateTreeView();
        }

        //=========================================================================
        // UpdateBookData
        // ���Ɏ擾�ς݂̃f�[�^���폜���āA������x�擾����
        //=========================================================================
        public async void UpdateBookData(string BookPath) 
        {
            MessageBox.Show(BookPath);
            
            // data.dat����Ώ�url���擾
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
                MessageBox.Show("data.dat�����݂��܂���B");
                return;
            }

            // �t�@�C�������ׂč폜����
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

            // �Ď擾
            using (WebClient wc = new WebClient())
            {
                wc.Proxy = null;
                using (Stream st = await wc.OpenReadTaskAsync(bookUrl))
                {
                    using (StreamReader sr = new StreamReader(st, Encoding.GetEncoding("UTF-8")))
                    {
                        GetBookDataFromWeb(sr.ReadToEnd(), bookUrl);
                    }
                }
            }

            // �c���[�m�[�h�X�V
            UpdateTreeView();
        }

        //=========================================================================
        // BookshelfTreeView_AfterSelect
        // �c���[�r���[���̃m�[�h��I�������Ƃ��ɌĂяo�����
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
                            richTextBox1.AppendText("[�^�C�g��]�F" + sr.ReadLine() + "\r\n");
                            richTextBox1.AppendText("[���]�F" + sr.ReadLine() + "\r\n");
                            richTextBox1.AppendText("[URL]�F" + sr.ReadLine() + "\r\n");
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
                            pageText += "[�T�u�^�C�g��]�F" + sr.ReadLine() + "\r\n";
                            sr.ReadLine();
                            pageText += "[URL]�F" + sr.ReadLine() + "\r\n";
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
        // �x�{�^�����N���b�N�����Ƃ��ɌĂяo�����
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
            // [�{�I]�Ƀm�[�h��ǉ�����
            UpdateTreeView();

            // [�����L���O]�Ƀm�[�h��ǉ�����
            RankingTreeNode dailyRankingNode = new RankingTreeNode(this, "http://yomou.syosetu.com/rank/secondlist/type/daily_total/");
            dailyRankingNode.Name = "DailyRankingTreeNode";
            dailyRankingNode.Text = "���ԃ����L���O";
            BookshelfTreeView.Nodes["RankingTreeNode"].Nodes.Add(dailyRankingNode);

            RankingTreeNode weeklyRankingNode = new RankingTreeNode(this, "http://yomou.syosetu.com/rank/secondlist/type/weekly_total/");
            weeklyRankingNode.Name = "WeeklyRankingTreeNode";
            weeklyRankingNode.Text = "�T�ԃ����L���O";
            BookshelfTreeView.Nodes["RankingTreeNode"].Nodes.Add(weeklyRankingNode);

        }

        public void ClearListViewItems()
        {
            listView.Items.Clear();
        }

        public void AddListViewItem(bool gotten, String title, String author, String genre)
        {
            String mark = "��";
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
