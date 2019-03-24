using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoznajPilkarza.Enitites;
using PoznajPilkarza.Entities.Contexts;

namespace PoznajPilkarza.Services
{
    public class TeamRepository :ITeamRepository
    {
        private TeamContext _context;

        public TeamRepository(TeamContext context)
        {
            _context = context;
        }

        public IEnumerable<Team> GetTeams()
        {
            return _context.Teams.Select(t => new Team
            {
                Name = t.Name,
                League = t.League,
                Formed = t.Formed,
                WikiLink = t.WikiLink,
                Stadium = new Stadium
                {
                    Name = t.Stadium.Name,
                    Capacity = t.Stadium.Capacity
                }
            });
        }

        public IEnumerable<Team> GetTeamsInLeague(string league)
        {
            var nameLeague = Regex.Replace(league, @"\-.*", "").Trim();
            var countryLeague = Regex.Match(league, @"\-.*").Value.Replace("-", "").Trim();
            return _context.Teams
                .Where(x=>x.League.Name==nameLeague&&
                          x.League.Nationality.Name==countryLeague)
                .Select(t => new Team
            {
                Name = t.Name,
                League = t.League,
                Formed = t.Formed,
                WikiLink = t.WikiLink,
                Stadium = new Stadium
                {
                    Name = t.Stadium.Name,
                    Capacity = t.Stadium.Capacity
                }
            });
        }
    }
}
