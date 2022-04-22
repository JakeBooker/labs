using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CsvHelper;

namespace Program {
    public class Link {
        public string URL { get; set; }
        public int Level { get; set; }
        public Link(string _url, int _level) {
            URL = _url;
            Level = _level;
        }
    }


    public class WebScanner : IDisposable {
        private readonly HashSet<Uri> _procLinks = new HashSet<Uri>();
        private readonly WebClient _webClient = new WebClient();
        private int passedPages = 0;
        private readonly HashSet<string> _ignoreFiles = new HashSet<string> { ".ico", ".xml", ".css" };
        private void OnTargetFound(Uri page, Uri[] links, int level) {
            passedPages++;
            TargetFound?.Invoke(page, links, level);
        }
        private void Process(string domain, Uri page, int depth, int maxPages) {
            if (depth <= 0 || _procLinks.Contains(page) || passedPages >= maxPages) return;
            _procLinks.Add(page);

            string html = _webClient.DownloadString(page);
            var hrefs = (from href in Regex.Matches(html, @"href=""[\/\w\.:]+""").Cast<Match>()
                         let url = href.Value.Replace("href=", "").Trim('"')
                         let loc = url.StartsWith("/")
                         select new {
                             Ref = new Uri(loc ? $"{domain}{url}" : url),
                             IsLocal = loc || url.StartsWith(domain)
                         }
                          ).ToList();
            var externals = (from href in hrefs
                             where !href.IsLocal
                             select href.Ref).ToArray();
            if (externals.Length > 0) OnTargetFound(page, externals, depth);
            var locals = (from href in hrefs
                          where href.IsLocal
                          select href.Ref).ToList();
            foreach (var href in locals) {
                string fileEx = Path.GetExtension(href.LocalPath).ToLower();
                if (_ignoreFiles.Contains(fileEx)) continue;
                try {
                    Process(domain, href, depth - 1, maxPages);
                } catch (System.Net.WebException) {
                    continue;
                } catch (System.UriFormatException) {
                    continue;
                }
            }


        }
        public event Action<Uri, Uri[], int> TargetFound;
        public void scan(Uri startPage, int recDepth, int maxPages) {
            _procLinks.Clear();

            string domain = $"{startPage.Scheme}://{startPage.Host}";
            Process(domain, startPage, recDepth, maxPages);
        }
        public void Dispose() {
            _webClient.Dispose();
        }
    }
    class Program {
        public static void Main(string[] args) {
            string fileName = @"C:\Users\Veize\source\repos\laba4\Excel.csv";
            //Console.WriteLine("URL:");
            string Url = "https://www.susu.ru/"; //Console.ReadLine();
            //Console.WriteLine("Максимальное количество страниц для печати: "); 
            int max = 5; // Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Максимальная глубина рекурсии: "); 
            int recursionDepth = 5; // Convert.ToInt32(Console.ReadLine());
            List<Link> arr = new List<Link>();
            using (WebScanner scanner = new WebScanner()) {
                scanner.TargetFound += (page, links, lev) => {
                    int num = recursionDepth - lev;
                    Console.WriteLine($"\nСтраница (Уровень = {num}): \n\t{page}\nСсылки (Уровень = {num + 1}): ");
                    arr.Add(new Link(page.ToString(), num));

                    foreach (var link in links) {
                        Console.WriteLine($"\t{link}");
                        arr.Add(new Link(link.ToString(), num + 1));
                    }
                };

                scanner.scan(new Uri(Url), recursionDepth, max);
                using (var stream = new StreamWriter(fileName))
                using (var csvReader = new CsvWriter(stream, System.Globalization.CultureInfo.InvariantCulture)) {
                    //csvReader.Configuration.Delimiter = ";";
                    csvReader.WriteRecords(arr);
                    stream.Flush();
                }
                Console.WriteLine("Завершено.");


            }

        }
    }


}