using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoznajPilkarza.Enitites;
using PoznajPilkarza.Entities.Contexts;

namespace PoznajPilkarza.Services
{
    public class LeagueRepository :ILeagueRepository
    {
        private LeagueContext _context;

        public LeagueRepository(LeagueContext context)
        {
            _context = context;
        }
        public IEnumerable<League> GetLeagues()
        {
           return _context.Leagues
               .Select(l => new League{Name = l.Name,Nationality = l.Nationality})
               .ToList();
        }
    }
}
