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
            var linkToTeams=new List<string>();
            var patternLinkLeagues = $@"\/.+";
            var patternLinkTeams = $@"\/(?:.(?!\/))+$";
            html = Regex.Replace(html, patternLinkTeams, "/");
            foreach (var nodeLeagueRow in nodesLeagueRow)
            {
                linkLeagues.Add(Regex.Replace(nodeLeagueRow.Attributes["href"].Value,patternLinkLeagues,""));
                nameLeagues.Add(nodeLeagueRow.InnerText);
                linkToTeams.Add(nodeLeagueRow.Attributes["href"].Value);
            }

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
                TeamInLeague(html + linkToTeams[i]);
            }

            return leagues;
            //var teams = TeamInLeague(html + leagueHtml);
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
        public static void TeamInLeague(string leagueHtml)
        {
            //var html = $@"http://www.footballsquads.co.uk/eng/{leagueHtml}";

            HtmlWeb web = new HtmlWeb { };
            var htmldoc = web.Load(leagueHtml);
            var nodesTeams = htmldoc.DocumentNode.SelectNodes($"//h5/a");
            List<string> linkTeams = new List<string>();
            var nameTeams = new List<string>();
            foreach (var teams in nodesTeams)
            {
                linkTeams.Add(teams.Attributes["href"].Value);
                nameTeams.Add(teams.InnerText);
            }

            var patternLinkTeam = $@"\/(?:.(?!\/))+$";
            leagueHtml = Regex.Replace(leagueHtml, patternLinkTeam, "/");
            //List<JsonResult> players = new List<JsonResult>();
            for (int i = 0; i < linkTeams.Count; i++)
            {
                PlayersInTeam(leagueHtml + linkTeams[i],nameTeams[i]);
            }


                //players.Add(footballers);

            //var storedLinkTeams = new JsonResult(linkTeams);
            //var storedFootballers = new JsonResult(players);
            //return storedFootballers;
            //return Ok(storedFootballers.Value);
            //return Ok(storedLinkTeams.Value);
        }


        private static void PlayersInTeam(string html,string teamName)
        {
            //var html = @"http://www.footballsquads.co.uk/eng/2018-2019/engprem/arsenal.htm";

            HtmlWeb web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.GetEncoding("iso-8859-1")
            };
            var htmlDoc = web.Load(html);

            var nodesTeams = htmlDoc.DocumentNode.SelectNodes($"//h3/text()");
            var listFormed = new List<string>();
            for (int i = 1; i < nodesTeams.Count - 1; i++)
            {
                listFormed.Add(nodesTeams[i].InnerText);

                var capacity = Regex.Match(nodesTeams[2].InnerText, @"(?<=\()\d.+?(?=\))");
                var nameManager = Regex.Replace(Regex.Match(
                    Regex.Replace(nodesTeams[3].InnerText, @"\\r|\\n|&nbsp+.", "").Trim(),
                    @"\s(?s).*").ToString(), $@"(?=\[).+?(?=\]).", "");
                var coutryManager = Regex.Match(nodesTeams[3].InnerText, $@"(?<=\[).+?(?=\])");
            }


            var nodesPlayerInTeam = htmlDoc.DocumentNode.SelectNodes("//table/tr");
            List<Player> playerList = new List<Player>();
            foreach (var player in nodesPlayerInTeam.Skip(1))
            {
                Player footballer = new Player();
                if (Regex.IsMatch(player.InnerText, @"no longer"))
                {
                    break;
                }

                var nodes = player.SelectNodes(".//td");
                var nameNode = HtmlEntity.DeEntitize(nodes[1].InnerText);
                if (nameNode != "")
                {
                    var patternName = @"\s(?s).*";
                    var patternNbsp = @"<[^>]+>|&nbsp;";
                    footballer.ShirtNumber = Regex.Replace(nodes[0].InnerText.Trim(), patternNbsp, "") != ""
                        ? Convert.ToInt16(Regex.Match(nodes[0].InnerText.Trim(), @"\d+").Value)
                        : 0;
                    footballer.Name = Regex.Replace(nameNode, patternName, "");
                    footballer.Surname = Regex.Match(nameNode, patternName).ToString().Trim();
                    footballer.Position = nodes[3].InnerText;
                    footballer.Height = Regex.Replace(nodes[4].InnerText, patternNbsp, "") != ""
                        ? Convert.ToInt16(Regex.Replace(nodes[4].InnerText.Replace(".", ""), patternNbsp, ""))
                        : 0;
                    footballer.Weight = Regex.Replace(nodes[5].InnerText, patternNbsp, "") != ""
                        ? Convert.ToInt16(Regex.Replace(nodes[5].InnerText, patternNbsp, ""))
                        : 0;
                    footballer.DateOfBirth = nodes[6].InnerText;
                    playerList.Add(footballer);
                }
            }

            //var storedFootballers = new JsonResult(playerList);
            GC.Collect();

            //return storedFootballers;
        }
    }
   
}
