using System;
using System.Collections.Generic;
using System.Linq;
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
            var web = new HtmlWeb();
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
                leagues.Add(new League
                {
                   Name = nameLeagues[i],
                   Nationality = context.Nationalities.FirstOrDefault
                   (x=>x.Name==linkLeagues[i] ||
                       x.Name==linkLeagues[i].Substring(0,3)),
                   SeasonYear = "2018/2019"
                });
            }

            return leagues;
            //var teams = TeamInLeague(html + league);
            //leaguePlayers.Add(teams);

        }
    }
}
