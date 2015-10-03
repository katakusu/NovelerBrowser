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

        //=================================================================
        // GetHTMLbody
        // �����Ŏw�肵��uri�̃y�[�W�̑S����UTF-8�Ŏ擾����
        //=================================================================
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

        //==========================================================================
        // InsertBookInBookshelfMenuItem_Click
        //  [�{�I]-[�{�I�Ɋi�[]���N���b�N����ƌĂяo�����
        //      �c���[�r���[���X�V����
        //==========================================================================
        private void UpdateTreeView() 
        {
            BookshelfTreeView.Nodes["BookshelfTreeNode"].Nodes.Clear();
            string[] Subfolders = Directory.GetDirectories(WorkFolderPath, "*", SearchOption.TopDirectoryOnly);
            foreach (string folder in Subfolders)
            {
                MatchCollection FolderNameMatchCollection = Regex.Matches(folder, @"Archive/(?<name>.+)$");
                Console.WriteLine();

                BookTreeNode Node = new BookTreeNode(FolderNameMatchCollection[0].Groups["name"].ToString().Trim(), folder);
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
        // InsertBookInBookshelfMenuItem_Click
        //  [�{�I]-[�{�I�Ɋi�[]���N���b�N����ƌĂяo�����
        //==========================================================================
        private void InsertBookInBookshelfMenuItem_Click(object sender, EventArgs e)
        {
            using (InsertBookFromUriForm form = new InsertBookFromUriForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string NovelUrl = form.GetTextBoxText();
                        var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                        htmlDoc.LoadHtml(GetHTMLBody(NovelUrl));
                        Console.WriteLine("HTML Doc �\�z����");

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

                        Console.WriteLine("���o������");

                        if (!Directory.Exists(WorkFolderPath+novelTitle+"\\")) 
                        {
                            Directory.CreateDirectory(WorkFolderPath+novelTitle+"\\");
                        }

                        if (!File.Exists(WorkFolderPath + novelTitle + "\\" + "data.dat"))
                        {
                            using (StreamWriter sw = new StreamWriter(WorkFolderPath + novelTitle + "\\" + "data.dat", true, Encoding.GetEncoding("shift_jis")))
                            {
                                sw.WriteLine(novelTitle);
                                sw.WriteLine(WriterName);
                                sw.WriteLine(NovelUrl);
                                sw.WriteLine(NovelSynopsis);
                            }
                        }

                        foreach (var a in articles)
                        {
                            Regex TitleRegex = new Regex(@"(?<subtitle>.*)\n\n(?<date>\d\d\d\d�N\d{1,2}��\d{1,2}��)\n\n.*");
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
                                        sw.WriteLine(NovelUrl+novelTextName+"/");

                                        var bodyHtmlDoc = new HtmlAgilityPack.HtmlDocument();
                                        bodyHtmlDoc.LoadHtml(GetHTMLBody(NovelUrl + novelTextName + "\\"));
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
                    catch(Exception exce)
                    {
                        MessageBox.Show("InsertBookInBookshelfMenuItem_Click:�G���[");   
                    }

                }
            }
            UpdateTreeView();
        }

        
        private void BookshelfTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }


        //=========================================================================
        // BookshelfTreeView_AfterSelect
        // �c���[�r���[���̃m�[�h��I�������Ƃ��ɌĂяo�����
        //=========================================================================
        private void BookshelfTreeView_AfterSelect(object sender, TreeViewEventArgs e)
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
                    break;

                case 2:
                    if (e.Node is PageTreeNode)
                    {
                        PageTreeNode bNode = (PageTreeNode)e.Node;
                        richTextBox1.ResetText();
                        using (StreamReader sr = new StreamReader(bNode.FilePath, Encoding.Default))
                        {
                            richTextBox1.AppendText("[�T�u�^�C�g��]�F" + sr.ReadLine() + "\r\n");
                            sr.ReadLine();
                            richTextBox1.AppendText("[URL]�F" + sr.ReadLine() + "\r\n");
                            richTextBox1.AppendText("===============\r\n");
                            while (sr.Peek() >= 0)
                            {
                                richTextBox1.AppendText(sr.ReadLine() + "\r\n");
                            }
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
    }
}
