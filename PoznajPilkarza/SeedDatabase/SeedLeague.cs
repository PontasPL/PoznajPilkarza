using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using PoznajPilkarza.Enitites;
using PoznajPilkarza.Entities.Contexts;

namespace PoznajPilkarza.SeedDatabase
{
    public static class SeedLeague
    {
        public static void EnsureSeedDataForContext(this PlayerContext context)
        {
            if (context.Players.Any())
            {
                return;
            }

            AddNoDataKeysToContexts(context);
            AddPositionToContext(context);
            GetLeague(context);
        }

        private static void AddNoDataKeysToContexts(PlayerContext context)
        {
            var noDataCountry = new Nationality
            {
                Name = "No data",
                CodeCountryThreeChars = "000",
                CodeCountryTwoChars = "00",
                Description = "",
                WikiLink = "",
                PngImage = "",
                TotalPopulation = 0,
                FifaCodeCountry = ""
            };
            context.Nationalities.Add(noDataCountry);
            context.SaveChanges();
            var noDataManager = new Manager
            {
                Name = "No data",
                Surname = "No data",
                Description = "",
                WikiLink = "",
                NationalityId = context.Nationalities.FirstOrDefault(n => n.CodeCountryThreeChars == "000")
                    .NationalityId
            };
            context.Managers.Add(noDataManager);

            var noStadium = new Stadium
            {
                Name = "No data",
                Description = "",
                NationalityId =
                    context.Nationalities.FirstOrDefault(n => n.CodeCountryThreeChars == "000").NationalityId,
                Capacity = 0,
                WikiLink = ""
            };
            context.Stadium.Add(noStadium);

            var noPosition = new Position {PositionName = "No data", ShortCode = "No"};
            context.Positions.Add(noPosition);
            context.SaveChanges();
        }

        private static void AddPositionToContext(PlayerContext context)
        {
            var positons = new List<Position>
            {
                new Position() {ShortCode = "G", PositionName = "Goalkeeper"},
                new Position() {ShortCode = "D", PositionName = "Defender"},
                new Position() {ShortCode = "M", PositionName = "Midfielder"},
                new Position() {ShortCode = "F", PositionName = "Forward"}
            };
            context.Positions.AddRange(positons);
            context.SaveChanges();
        }

        private static void GetLeague(PlayerContext context)
        {
            var html = @"http://www.footballsquads.co.uk/squads.htm";
            var web = new HtmlWeb {AutoDetectEncoding = false, OverrideEncoding = Encoding.GetEncoding("iso-8859-1")};
            var htmldoc = web.Load(html);
            var nodesLeagueRow = htmldoc.DocumentNode.SelectNodes(@"//table/tr/td/a");
            List<string> linkLeagues = new List<string>();
            List<string> nameLeagues = new List<string>();
            var linkToTeams = new List<string>();
            var patternLinkLeagues = $@"\/.+";
            var patternLinkTeams = $@"\/(?:.(?!\/))+$";
            html = Regex.Replace(html, patternLinkTeams, "/");
            foreach (var nodeLeagueRow in nodesLeagueRow)
            {
                linkLeagues.Add(Regex.Replace(nodeLeagueRow.Attributes["href"].Value, patternLinkLeagues, ""));
                nameLeagues.Add(nodeLeagueRow.InnerText);
                linkToTeams.Add(nodeLeagueRow.Attributes["href"].Value);
            }

            var leagues = new List<League>();
            for (int i = 0; i < linkLeagues.Count; i++)
            {
                var wiki = SeedWikipedia.GetWiki(nameLeagues[i]).Result;
                var idNationality = FixingCountry(context, linkLeagues[i]);
                //leagues.Add(new League
                //{
                //   Name = nameLeagues[i],
                //   NationalityId = idNationality,
                //   SeasonYear = "2018/2019",
                //   Description = wiki.Description,
                //   WikiLink = wiki.Link
                //});
                var selectedLeague = (new League
                {
                    Name = nameLeagues[i],
                    NationalityId = idNationality,
                    SeasonYear = "2018/2019",
                    Description = wiki.Description,
                    WikiLink = wiki.Link
                });
                context.Leagues.Add(selectedLeague);
                context.SaveChanges();
                TeamInLeague(context, html + linkToTeams[i], selectedLeague);

                i = linkLeagues.Count;
            }
        }

        public static int FixingCountry(PlayerContext context, string coutryLink)
        {
            coutryLink = Regex.Replace(coutryLink, "eng", "United Kingdom");
            coutryLink = Regex.Replace(coutryLink, "usa", "United States");
            int natId = context.Nationalities.Any(x => x.Name == coutryLink)
                ? context.Nationalities.FirstOrDefault(x => x.Name == coutryLink).NationalityId
                : context.Nationalities.FirstOrDefault(x => x.Name.Substring(0, 3) == coutryLink.Substring(0, 3))
                    .NationalityId;
            return natId;
        }

        public static void TeamInLeague(PlayerContext context, string leagueHtml, League selectedLeague)
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
            var list = new List<Team>();
            for (int i = 0; i < linkTeams.Count; i++)
            {
                PlayersInTeam(context, leagueHtml + linkTeams[i], nameTeams[i], selectedLeague);
            }
        }

        private static void PlayersInTeam(PlayerContext context, string html, string teamName, League selectedLeague)
        {
            //var html = @"http://www.footballsquads.co.uk/eng/2018-2019/engprem/arsenal.htm";
            HtmlWeb web = new HtmlWeb
            {
                AutoDetectEncoding = false, OverrideEncoding = Encoding.GetEncoding("iso-8859-1")
            };
            var htmlDoc = web.Load(html);

            var nodesTeams = htmlDoc.DocumentNode.SelectNodes($"//h3/text()");
            var patternClearHtml = $@"\r|\n|&nbsp+.";
            var team = AddTeamToContext(context, teamName, selectedLeague, nodesTeams, patternClearHtml);

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
                    var positionPlayer = Regex.Replace(nodes[3].InnerText, patternClearHtml, "");
                    var nationalityPlayer = Regex.Replace(nodes[2].InnerText, patternClearHtml, "");
                    int positionIdPlayer, nationalityIdPlayer;
                    if (positionPlayer == "")
                    {
                        positionIdPlayer = context.Positions.FirstOrDefault(p => p.ShortCode == "No").PositionId;
                    }
                    else
                    {
                        positionIdPlayer = context.Positions.FirstOrDefault(p => p.ShortCode == positionPlayer)
                            .PositionId;
                    }

                    if (nationalityPlayer == "")
                    {
                        nationalityIdPlayer = context.Nationalities
                            .FirstOrDefault(p => p.CodeCountryThreeChars == "000")
                            .NationalityId;
                    }
                    else
                    {
                        nationalityIdPlayer = context.Nationalities.FirstOrDefault(p =>
                                p.FifaCodeCountry == Regex.Replace(nationalityPlayer, "EMG", "ENG"))
                            .NationalityId;
                    }

                    var dateOfBirthPlayer = GetDateOfBirthPlayer(nodes, patternClearHtml);
                    footballer.ShirtNumber = Regex.Replace(nodes[0].InnerText.Trim(), patternNbsp, "") != ""
                        ? Convert.ToInt16(Regex.Match(nodes[0].InnerText.Trim(), @"\d+").Value)
                        : 0;
                    footballer.Name = Regex.Replace(nameNode, patternName, "");
                    footballer.Surname = Regex.Match(nameNode, patternName).ToString().Trim();
                    footballer.PositionId = positionIdPlayer;
                    footballer.NationalityId = nationalityIdPlayer;
                    footballer.Height = Regex.Replace(nodes[4].InnerText, patternNbsp, "") != ""
                        ? Convert.ToInt16(Regex.Replace(nodes[4].InnerText.Replace(".", ""), patternNbsp, ""))
                        : 0;
                    footballer.Weight = Regex.Replace(nodes[5].InnerText, patternNbsp, "") != ""
                        ? Convert.ToInt16(Regex.Replace(nodes[5].InnerText, patternNbsp, ""))
                        : 0;
                    footballer.DateOfBirth = dateOfBirthPlayer;
                    footballer.TeamId = team.TeamId;
                    var wikiSeed = SeedWikipedia.GetWiki(footballer.Name + " " + footballer.Surname).Result;
                    footballer.WikiLink = wikiSeed.Link;
                    footballer.Description = "0";
                    playerList.Add(footballer);
                }
            }

            context.Players.AddRange(playerList);
            context.SaveChanges();
            GC.Collect();
        }

        private static DateTime GetDateOfBirthPlayer(HtmlNodeCollection nodes, string patternClearHtml)
        {
            DateTime dateOfBirthPlayer;
            string nonParsedDateOfBirth = Regex.Replace(nodes[6].InnerText, patternClearHtml, "");
            if (nonParsedDateOfBirth == "")
            {
                dateOfBirthPlayer = new DateTime(1900, 01, 01);
            }
            else
            {
                var day = Convert.ToInt16(nonParsedDateOfBirth.Substring(0, 2));
                var month = Convert.ToInt16(nonParsedDateOfBirth.Substring(3, 2));
                var year = nonParsedDateOfBirth.Substring(6, 2);
                year = Convert.ToInt16(year) < 30 ? "20" + year : "19" + year;

                dateOfBirthPlayer = new DateTime(Convert.ToInt16(year), month, day);
            }

            return dateOfBirthPlayer;
        }

        private static Team AddTeamToContext(PlayerContext context, string teamName, League selectedLeague,
            HtmlNodeCollection nodesTeams, string patternClearHtml)
        {
            var manager = AddMangerToContext(context, nodesTeams);
            var stadium = AddStadiumToContext(context, nodesTeams, selectedLeague.NationalityId);
            var wikiTeam = SeedWikipedia.GetWiki(teamName).Result;
            var formed = Regex.Replace(nodesTeams[1].InnerText, patternClearHtml, "").Trim();
            if (formed == "")
            {
                formed = "0";
            }

            var selectedTeam = new Team
            {
                Name = teamName,
                Stadium = stadium,
                Manager = manager,
                League = selectedLeague,
                Formed = Convert.ToInt32(formed),
                Description = wikiTeam.Description,
                WikiLink = wikiTeam.Link
            };
            context.Teams.Add(selectedTeam);
            context.SaveChanges();
            return selectedTeam;
        }

        private static Stadium AddStadiumToContext(PlayerContext context, HtmlNodeCollection nodesTeams,
            int idNationality)
        {
            var patternStadiumCapacity = $@"(?<=\()\d.+?(?=\))|&nbsp;";
            var capacityStadium = Regex.Match(nodesTeams[2].InnerText, patternStadiumCapacity)
                .ToString()
                .Replace(",", "");
            if (capacityStadium == "")
            {
                capacityStadium = "0";
            }

            var nameStadium = Regex.Replace(nodesTeams[2].InnerText, patternStadiumCapacity, "")
                .Replace("()", "")
                .Trim();
            if (nameStadium == "")
            {
                return context.Stadium.FirstOrDefault(s => s.Name == "No data");
            }

            var wikiStadium = SeedWikipedia.GetWiki(nameStadium).Result;
            var selectedStadium = new Stadium
            {
                Name = nameStadium,
                Capacity = Convert.ToInt32(capacityStadium),
                NationalityId = idNationality,
                Description = wikiStadium.Description,
                WikiLink = wikiStadium.Link
            };
            return selectedStadium;
        }

        private static Manager AddMangerToContext(PlayerContext context, HtmlNodeCollection nodesTeams)
        {
            var patternNameManager = $@"\s(?s).*";
            var patternClearManager = $@"\r|\n|&nbsp+.|(?=\[).+?(?=\]).";
            var patternCountryManger = $@"(?<=\[).+?(?=\])";
            var countryManagerNode = nodesTeams[3].InnerText;
            var nameSurnameManager = Regex.Replace(nodesTeams[3].InnerText, patternClearManager, "").Trim();
            if (nameSurnameManager == "")
            {
                var patternTemporaryManager = @"(?<=Manager:.).+?(?=]).";
                nameSurnameManager = Regex.Match(nodesTeams[3].ParentNode.InnerText,patternTemporaryManager).ToString();
                countryManagerNode = nameSurnameManager;
                if (nameSurnameManager=="")
                {
                    return context.Managers.FirstOrDefault(m => m.Surname == "No data");
                }
            }

            string nameManager = Regex.Replace(nameSurnameManager, patternNameManager, "");
            string surnameManager = Regex.Match(nameSurnameManager, patternNameManager).ToString().Trim();
            var countryManager = Regex.Match(countryManagerNode, patternCountryManger).ToString();
            var wikiManager = SeedWikipedia.GetWiki(HtmlEntity.DeEntitize(nameSurnameManager)).Result;
            var selectedManager = new Manager
            {
                Name = nameManager,
                Surname = surnameManager,
                NationalityId =
                    context.Nationalities.FirstOrDefault(n => n.FifaCodeCountry == countryManager).NationalityId,
                Description = wikiManager.Description,
                WikiLink = wikiManager.Link
            };

            return selectedManager;
        }
    }
}
