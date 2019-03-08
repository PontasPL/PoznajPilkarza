using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using PoznajPilkarza.Models;

namespace PoznajPilkarza.SeedDatabase
{
    public static class SeedWikipedia 
    {
        public static async Task<WikipediaData> GetWiki(string searchQuery)
        {
            var wiki = new WikipediaData();
            using (var client = new HttpClient())
            {
                try
                {
                    var stringJson =
                        await client.GetStringAsync(
                            $@"https://en.wikipedia.org/w/api.php?action=opensearch&search={searchQuery}&limit=1&namespace=0&format=json");
                    JToken token = JToken.Parse(stringJson);
                    const string quote = "\"";
                    string patternDesc = $@"\([^()]*\)|\r\n|{quote}|\\";
                    string patternBrackets = $@"[\[\]']|\r\n|{quote}|\\";
                    wiki.Description = Regex.Replace(
                        Regex.Replace(
                            Regex.Replace(HtmlEntity.DeEntitize(token[2].ToString()), patternDesc, ""),
                            patternDesc, "").Trim(),
                        patternBrackets, "");
                    wiki.Link = Regex.Replace(token[3].ToString(), patternBrackets, "").Trim();
                }
                catch
                {
                    wiki.Description = "";
                    wiki.Link = "";
                }
                

            }

            return wiki;
        }
    }
}
