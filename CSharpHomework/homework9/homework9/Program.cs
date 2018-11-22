using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;

namespace homework9
{
    public class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;

        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();

            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];

            myCrawler.urls.Add(startUrl, false);

            Action[] actions = { new Action(myCrawler.Crawl), myCrawler.Crawl };
            Parallel.Invoke(actions);           
           
        }

        private void Crawl()
        {
            Crawler myCrawler = new Crawler();
            Console.WriteLine("要开始爬行了....");
            while(true)
            {
                string current = null;
                foreach(string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }
                if (current == null || count > 10) break;

                Console.WriteLine("爬行" + current + "页面!");
                
                Cra(current);

                urls[current] = true;
                count++;

                
            }
            Console.WriteLine("爬行结束");
        }

        public void Cra(string current)
        {
            string html = DownLoad(current);
            Parse(html);
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public void Parse(string html)
        {
            string strRef =@"(href|HREF)[]*[""'][^""'#>] + [""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach(Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=')+1).Trim('"','\"','#',' ','>');
                if(strRef.Length == 0)
                {
                    continue;
                }                  
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
