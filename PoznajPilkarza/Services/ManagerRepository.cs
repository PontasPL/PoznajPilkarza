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
    public class ManagerRepository :IMangerRepository
    {
        private ManagerContext _context;

        public ManagerRepository(ManagerContext context)
        {
            _context = context;
        }
        public IEnumerable<Manager> GetManagers()
        {
            return _context.Managers
                .Include(t => t.Team)
                .Select(x=>new Manager
                {
                    Name = x.Name,
                    Surname = x.Surname,
                    Nationality = x.Nationality,
                    Team = x.Team,
                    WikiLink = x.WikiLink
                }).ToList();
        }

        public IEnumerable<Manager> GetManagersFromCountry(string country)
        {
            return _context.Managers
                .Where(n=>n.Nationality.Name==country)
                .Include(t => t.Team)
                .Select(x => new Manager
                {
                    Name = x.Name,
                    Surname = x.Surname,
                    Nationality = x.Nationality,
                    Team = x.Team,
                    WikiLink = x.WikiLink
                }).ToList();
        }

        public IEnumerable<Manager> GetManagersFromLeague(string league)
        {
            var nameLeague = Regex.Replace(league, @"\-.*", "").Trim();
            var countryLeague = Regex.Match(league, @"\-.*").Value.Replace("-", "").Trim();
            return _context.Managers
                .Where(l=>l.Team.League.Name==nameLeague&&
                          l.Team.League.Nationality.Name==countryLeague)
                .Include(t => t.Team)
                .Select(x => new Manager
                {
                    Name = x.Name,
                    Surname = x.Surname,
                    Nationality = x.Nationality,
                    Team = x.Team,
                    WikiLink = x.WikiLink
                }).ToList();
        }

        public IEnumerable<Manager> GetManagersFromCountryWithLeague(string country, string league)
        {
            var nameLeague = Regex.Replace(league, @"\-.*", "").Trim();
            var countryLeague = Regex.Match(league, @"\-.*").Value.Replace("-", "").Trim();
            return _context.Managers
                .Where(l=>l.Team.League.Name==nameLeague&&
                          l.Team.League.Nationality.Name==countryLeague&&
                          l.Nationality.Name==country)
                .Include(t => t.Team)
                .Select(x => new Manager
                {
                    Name = x.Name,
                    Surname = x.Surname,
                    Nationality = x.Nationality,
                    Team = x.Team,
                    WikiLink = x.WikiLink
                }).ToList();
        }
    }
}
