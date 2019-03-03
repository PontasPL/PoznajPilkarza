using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PoznajPilkarza.Enitites;
using PoznajPilkarza.Entities.Contexts;
using PoznajPilkarza.Models;

namespace PoznajPilkarza.SeedDatabase
{
    public static class SeedNationality
    {
        public static void EnsureSeedDataForContext(this NationalityContext context)
        {
            if (context.Nationalities.Any())
            {
                return;
            }


            var html = @"https://www.worldatlas.com/aatlas/ctycodes.htm";
            HtmlWeb web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.GetEncoding("iso-8859-1")
            };
            var htmldoc = web.Load(html);

            var nodesCountries = htmldoc.DocumentNode.SelectNodes($"//main/div/article/div/table//tr/td");

            var linkCoutries = new List<Nationality>();
            //string test = GetImageAsBase64Url("es").Result;
            //long population = GetPopulation("Brazil").Result;
            for (int i = 5; i < nodesCountries.Count - 1; i++)
            {

                WikipediaData wikiData =
                    GetWiki(Regex.Replace(nodesCountries[i].InnerText, $"\\r\\n\\s", "").Trim())
                    .Result;
                
                linkCoutries.Add(item: new Nationality
                {
                    Name = Regex.Replace(nodesCountries[i].InnerText, $"\\r\\n\\s", "").Trim(),
                    //TotalPopulation = GetPopulation(Regex.Replace(nodesCountries[i].InnerText, $"\\r\\n\\s", "").Trim()).Result,
                    CodeCountryTwoChars = Regex.Replace(nodesCountries[++i].InnerText, $"\\r\\n\\s", "").Trim(),
                    PngImage = GetImageAsBase64Url(Regex.Replace(nodesCountries[i].InnerText, $"\\r\\n\\s", "").Trim()).Result,
                    CodeCountryThreeChars = nodesCountries[++i].InnerText,
                    Description = wikiData.Description,
                    WikiLink = wikiData.Link
                    

                });
                i += 2;
            }

            context.Nationalities.AddRange(linkCoutries);
            context.SaveChanges();

        }
        public static async Task<string> GetImageAsBase64Url(string country)
        {
            using (var client = new HttpClient())
            {

                var bytes = await client.GetByteArrayAsync($@"https://www.countryflags.io/{country}/shiny/64.png");
                return "image/png;base64," + Convert.ToBase64String(bytes);
            }
        }

        public static async Task<WikipediaData> GetWiki(string searchQuery)
        {
            var wiki = new WikipediaData();
            using (var client = new HttpClient())
            {
                var stringJson =
                    await client.GetStringAsync(
                        $@"https://en.wikipedia.org/w/api.php?action=opensearch&search={searchQuery}&limit=1&namespace=0&format=json");
                JToken token = JToken.Parse(stringJson);
                string patternDesc = $@"\([^()]*\)";
                string patternBrackets = $@"[\[\]']";
                wiki.Description = Regex.Replace(
                    Regex.Replace(
                        Regex.Replace(token[2].ToString(), patternDesc, ""),
                        patternDesc, ""),
                    patternBrackets,"");
                wiki.Link = Regex.Replace(token[3].ToString(),patternBrackets,"");

            }

            return wiki;
        }
    }
}
