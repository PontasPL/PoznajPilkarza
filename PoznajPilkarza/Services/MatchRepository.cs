using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoznajPilkarza.Enitites;
using PoznajPilkarza.Entities.Contexts;
using Match = PoznajPilkarza.Enitites.Match;

namespace PoznajPilkarza.Services
{
    public class MatchRepository:IMatchRepository
    {
        private MatchContext _context;

        public MatchRepository(MatchContext context)
        {
            _context = context;
        }

        public IEnumerable<Match> GetMatchWithDetails()
        {
            return _context.Matches
                .Include(md=>md.MatchDetails)
                .Select(x => new Match
                {
                    HomeTeam = x.HomeTeam,
                    AwayTeam = x.AwayTeam,
                    HTHomeGoals = x.HTHomeGoals,
                    HTAwayGoals = x.HTAwayGoals,
                    FTHomeGoals = x.FTHomeGoals,
                    FTAwayGoals = x.FTAwayGoals,
                    MatchDay = x.MatchDay,
                    League = x.League,
                    MatchDetails = new MatchDetails
                    {
                        Attendance = x.MatchDetails.Attendance,
                        Referee = x.MatchDetails.Referee,
                        HomeTeamCorners = x.MatchDetails.HomeTeamCorners,
                        AwayTeamCorners = x.MatchDetails.AwayTeamCorners,
                        HomeTeamShotsOnTarget = x.MatchDetails.HomeTeamShotsOnTarget,
                        AwayTeamShotsOnTarget = x.MatchDetails.AwayTeamShotsOnTarget,
                        HomeTeamOffsides = x.MatchDetails.HomeTeamOffsides,
                        AwayTeamOffsides = x.MatchDetails.AwayTeamOffsides,
                        HomeYellowCards = x.MatchDetails.HomeYellowCards,
                        AwayYellowCards = x.MatchDetails.AwayYellowCards,
                        HomeTeamFoulsCommitted = x.MatchDetails.HomeTeamFoulsCommitted,
                        AwayTeamFoulsCommitted = x.MatchDetails.AwayTeamFoulsCommitted,
                        HomeTeamShots = x.MatchDetails.HomeTeamShots,
                        AwayTeamShots = x.MatchDetails.AwayTeamShots,
                        HomeTeamRedCards = x.MatchDetails.HomeTeamRedCards,
                        AwayTeamRedCards = x.MatchDetails.AwayTeamRedCards,
                        HomeTeamWoodWork = x.MatchDetails.HomeTeamWoodWork,
                        AwayTeamWoodWork = x.MatchDetails.AwayTeamWoodWork,

                    },
                });
        }

        public IEnumerable<Match> GetMatches()
        {
            return _context.Matches.Select(x => new Match
            {
                HomeTeam = x.HomeTeam,
                AwayTeam = x.AwayTeam,
                HTHomeGoals = x.HTHomeGoals,
                HTAwayGoals = x.HTAwayGoals,
                FTHomeGoals = x.FTHomeGoals,
                FTAwayGoals = x.FTAwayGoals,
                MatchDay = x.MatchDay,
                League = x.League,
                MatchId = x.MatchId,
            }).ToList();
        }

        public IEnumerable<Match> GetMatchWithDetails(string league)
        {
            var nameLeague = Regex.Replace(league, @"\-.*", "").Trim();
            var countryLeague = Regex.Match(league, @"\-.*").Value.Replace("-", "").Trim();
            return _context.Matches
                .Where(x=>x.League.Name==nameLeague&&x.League.Nationality.Name==countryLeague)
                .Include(md => md.MatchDetails)
                .Select(x => new Match
                {
                    HomeTeam = x.HomeTeam,
                    AwayTeam = x.AwayTeam,
                    HTHomeGoals = x.HTHomeGoals,
                    HTAwayGoals = x.HTAwayGoals,
                    FTHomeGoals = x.FTHomeGoals,
                    FTAwayGoals = x.FTAwayGoals,
                    MatchDay = x.MatchDay,
                    League = x.League,
                    MatchDetails = new MatchDetails
                    {
                        Attendance = x.MatchDetails.Attendance,
                        Referee = x.MatchDetails.Referee,
                        HomeTeamCorners = x.MatchDetails.HomeTeamCorners,
                        AwayTeamCorners = x.MatchDetails.AwayTeamCorners,
                        HomeTeamShotsOnTarget = x.MatchDetails.HomeTeamShotsOnTarget,
                        AwayTeamShotsOnTarget = x.MatchDetails.AwayTeamShotsOnTarget,
                        HomeTeamOffsides = x.MatchDetails.HomeTeamOffsides,
                        AwayTeamOffsides = x.MatchDetails.AwayTeamOffsides,
                        HomeYellowCards = x.MatchDetails.HomeYellowCards,
                        AwayYellowCards = x.MatchDetails.AwayYellowCards,
                        HomeTeamFoulsCommitted = x.MatchDetails.HomeTeamFoulsCommitted,
                        AwayTeamFoulsCommitted = x.MatchDetails.AwayTeamFoulsCommitted,
                        HomeTeamShots = x.MatchDetails.HomeTeamShots,
                        AwayTeamShots = x.MatchDetails.AwayTeamShots,
                        HomeTeamRedCards = x.MatchDetails.HomeTeamRedCards,
                        AwayTeamRedCards = x.MatchDetails.AwayTeamRedCards,
                        HomeTeamWoodWork = x.MatchDetails.HomeTeamWoodWork,
                        AwayTeamWoodWork = x.MatchDetails.AwayTeamWoodWork,

                    },
                });
        }

        public IEnumerable<Match> GetMatches(string league)
        {
            var nameLeague = Regex.Replace(league, @"\-.*", "").Trim();
            var countryLeague = Regex.Match(league, @"\-.*").Value.Replace("-", "").Trim();
            return _context.Matches
                .Where(x=>x.League.Name==nameLeague&&x.League.Nationality.Name==countryLeague)
                .Select(x => new Match
            {
                HomeTeam = x.HomeTeam,
                AwayTeam = x.AwayTeam,
                HTHomeGoals = x.HTHomeGoals,
                HTAwayGoals = x.HTAwayGoals,
                FTHomeGoals = x.FTHomeGoals,
                FTAwayGoals = x.FTAwayGoals,
                MatchDay = x.MatchDay,
                League = x.League,
                MatchId = x.MatchId,
            }).ToList();
        }
    }
}
