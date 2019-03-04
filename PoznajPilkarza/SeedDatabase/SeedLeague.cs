using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PoznajPilkarza.Enitites;
using PoznajPilkarza.Entities.Contexts;

namespace PoznajPilkarza.SeedDatabase
{
    public static class SeedLeague
    {
        public static void EnsureSeedDataForContext(this LeagueContext context)
        {
            if (context.Leagues.Any())
            {
                return;
            }

            var leagues =GetLeague(context);
            context.AddRange(leagues);
            context.SaveChanges();
        }

        private static List<League> GetLeague(LeagueContext context)
        {
            var html = @"http://www.footballsquads.co.uk/squads.htm";
            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.GetEncoding("iso-8859-1")
            };
            var htmldoc = web.Load(html);
            var nodesLeagueRow = htmldoc.DocumentNode.SelectNodes(@"//table/tr/td/a");
            List<string> linkLeagues = new List<string>();
            List<string> nameLeagues = new List<string>();
            var patternLinkTeam = $@"\/.+";
            foreach (var nodeLeagueRow in nodesLeagueRow)
            {
                linkLeagues.Add(Regex.Replace(nodeLeagueRow.Attributes["href"].Value,patternLinkTeam,""));
                nameLeagues.Add(nodeLeagueRow.InnerText);
            }

            //var patternLinkTeam = $@"\/(?:.(?!\/))+$";
            var leagues = new List<League>();
            for (int i = 0; i < linkLeagues.Count; i++)
            {
                var wiki = SeedWikipedia.GetWiki(nameLeagues[i]).Result;
                leagues.Add(new League
                {
                   Name = nameLeagues[i],
                   NationalityId = FixingCountry(context,linkLeagues[i]),
                   SeasonYear = "2018/2019",
                   Description = wiki.Description,
                   WikiLink = wiki.Link
                });
            }

            return leagues;
            //var teams = TeamInLeague(html + league);
            //leaguePlayers.Add(teams);

        }

        public static int FixingCountry(LeagueContext context,string coutryLink)
        {
            coutryLink=Regex.Replace(coutryLink, "eng", "United Kingdom");
            coutryLink=Regex.Replace(coutryLink, "usa", "United States");
            int natId = context.Nationalities.Any(x => x.Name == coutryLink )?
                context.Nationalities.FirstOrDefault(x=>x.Name==coutryLink).NationalityId:
                context.Nationalities.FirstOrDefault(x=>x.Name.Substring(0,3)
                                                        == coutryLink.Substring(0, 3)).NationalityId;
            return natId;
        }
    }
   
}
