using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace NovelerBrowser
{
    class RankingTreeNode : TreeNode
    {
        MainForm form { set; get; }
        public String url { set; get; }

        public RankingTreeNode(MainForm form, String url) 
        {
            this.form = form;
            this.url = url;
        }

        public void GetRankingInfo(HtmlAgilityPack.HtmlDocument htmlDoc)
        {

            var TitleNodeCollection = htmlDoc.DocumentNode.SelectNodes(@"//div[@class=""rank_h""]");
            var LeftNodeCollection = htmlDoc.DocumentNode.SelectNodes(@"//td[@class=""left""]");
            var ExNodeCollection = htmlDoc.DocumentNode.SelectNodes(@"//td[@class=""ex""]");
            var SNodeCollection = htmlDoc.DocumentNode.SelectNodes(@"//td[@class=""s""]");

            if (TitleNodeCollection.Count + LeftNodeCollection.Count + ExNodeCollection.Count + SNodeCollection.Count
                    != TitleNodeCollection.Count*4)
            {
                MessageBox.Show("Countの値が不正です");
                return;
            }

            form.ClearListViewItems();

            for (int count = 0; count < TitleNodeCollection.Count;count++)
            {
                String title = TitleNodeCollection[count].InnerText;

                MatchCollection titleMatchCollection = Regex.Matches(title, @"\n[0-9]*位*\n&nbsp;(?<title>.+)\n&nbsp;&nbsp;作者：(?<author>.+)\n&nbsp;&nbsp;ジャンル：(?<genre>\w+)");//@".*&nbsp;(?<title>\w+)\n.*作者：(?<author>\w+)\n.*ジャンル：(?<genre>\w+)"
                String titleString = titleMatchCollection[0].Groups["title"].ToString().Trim();
                String author = titleMatchCollection[0].Groups["author"].ToString().Trim();
                String genre = titleMatchCollection[0].Groups["genre"].ToString().Trim();

                String left = LeftNodeCollection[count].InnerText;

                String ex = ExNodeCollection[count].InnerText;

                String snode = SNodeCollection[count].InnerText;

                form.AddListViewItem(false, titleString, author, genre);
            }
        }
    }
}
