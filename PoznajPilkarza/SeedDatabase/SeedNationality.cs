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
            var fifaCodes = AddFifaCodes();
            //long population = GetPopulation("Brazil").Result;
            for (int i = 5; i < nodesCountries.Count - 1; i++)
            {

               var wikiData =
                   SeedWikipedia.GetWiki(Regex.Replace(nodesCountries[i].InnerText, $"\\r\\n\\s", "").Trim()).Result;
                
                linkCoutries.Add(item: new Nationality
                {
                    
                    Name = Regex.Replace(nodesCountries[i].InnerText, $"\\r\\n\\s", "").Trim(),
                    //TotalPopulation = GetPopulation(Regex.Replace(nodesCountries[i].InnerText, $"\\r\\n\\s", "").Trim()).Result,
                    CodeCountryTwoChars = Regex.Replace(nodesCountries[++i].InnerText, $"\\r\\n\\s", "").Trim(),
                    PngImage = GetImageAsBase64Url(Regex.Replace(nodesCountries[i].InnerText, $"\\r\\n\\s", "").Trim()).Result,
                    CodeCountryThreeChars = nodesCountries[++i].InnerText,
                    Description = wikiData.Description,
                    WikiLink = wikiData.Link,
                    FifaCodeCountry = fifaCodes.FirstOrDefault(f => f.Key == nodesCountries[i].InnerText).Value


                });
                i += 2;
            }

            var wikiScot = SeedWikipedia.GetWiki("Scotland").Result;
            linkCoutries.Add(new Nationality
            {
                Name = "Scotland",
                CodeCountryThreeChars = "SCO",
                CodeCountryTwoChars = "SC",
                Description = wikiScot.Description,
                WikiLink = wikiScot.Link,
                PngImage = "No data",
                FifaCodeCountry = "SCO"
            });
            wikiScot = SeedWikipedia.GetWiki("Wales").Result;
            linkCoutries.Add(new Nationality
            {
                Name = "Wales",
                CodeCountryThreeChars = "WAL",
                CodeCountryTwoChars = "WL",
                Description = wikiScot.Description,
                WikiLink = wikiScot.Link,
                PngImage = "No data",
                FifaCodeCountry = "WAL"
            });
            wikiScot = SeedWikipedia.GetWiki("Northern Ireland").Result;
            linkCoutries.Add(new Nationality
            {
                Name = "Northern Ireland",
                CodeCountryThreeChars = "NIR",
                CodeCountryTwoChars = "NX",
                Description = wikiScot.Description,
                PngImage = "No data",
                WikiLink = wikiScot.Link,
                FifaCodeCountry = "NIR"
            });
            wikiScot = SeedWikipedia.GetWiki("Kosovo").Result;
            linkCoutries.Add(new Nationality
            {
                Name = "Kosovo",
                CodeCountryThreeChars = "KVX",
                CodeCountryTwoChars = "KV",
                Description = wikiScot.Description,
                PngImage = "No data",
                WikiLink = wikiScot.Link,
                FifaCodeCountry = "KVX"
            });
            context.Nationalities.AddRange(linkCoutries);
            context.SaveChanges();

        }

        public static Dictionary<string,string> AddFifaCodes()
        {
            var html = @"http://www.statoids.com/wab.html";
            HtmlWeb web = new HtmlWeb();
            var htmldoc = web.Load(html);
            Dictionary<string, string> countryCodes = new Dictionary<string, string>();
            var nodesCountries = htmldoc.DocumentNode.SelectNodes($"//div/div/table/tr/td");
            for (int i = 0; i < nodesCountries.Count - 4; i += 14)
            {

                var patternCountryCodeCleaner = @"<code>|<\/code>|&nbsp;";

                var fifaCode = Regex.Replace(nodesCountries[i + 7].InnerHtml, patternCountryCodeCleaner, "").Trim();
                var isoA2 = Regex.Replace(nodesCountries[i + 2].InnerHtml, patternCountryCodeCleaner, "").Trim();
                if (fifaCode != "")
                {
                    if (Regex.IsMatch(fifaCode, $@"note1"))
                    {
                        fifaCode = "ENG";
                    }
                    countryCodes.Add(isoA2, fifaCode.Substring(0, 3));
                }
            }

            return countryCodes;
        }


        public static async Task<string> GetImageAsBase64Url(string country)
        {
            using (var client = new HttpClient())
            {

                var bytes = await client.GetByteArrayAsync($@"https://www.countryflags.io/{country}/shiny/64.png");
                return "image/png;base64," + Convert.ToBase64String(bytes);
            }
        }

       
    }
}
