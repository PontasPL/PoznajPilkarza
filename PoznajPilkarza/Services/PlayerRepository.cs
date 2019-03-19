using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Diacritics.Extensions;
using Microsoft.EntityFrameworkCore;
using PoznajPilkarza.Enitites;
using PoznajPilkarza.Entities.Contexts;

namespace PoznajPilkarza.Services
{
    public class PlayerRepository:IPlayerRepository
    {
        private PlayerContext _context;

        public PlayerRepository(PlayerContext context)
        {
            _context = context;
        }

        public Player GetPlayer(string name,string surname)
        {
            return _context.Players
                .Where(x => x.Name.ToLower() == name && x.Surname.ToLower() == surname)
                .Include(t => t.Team)
                .Include(l=>l.Team.League)
                .Include(n=>n.Team.League.Nationality)
                .Include(p=>p.Position)
                .Select(x=>new Player
                {
                    Name = x.Name,
                    Surname = x.Surname,
                    DateOfBirth = x.DateOfBirth,
                    Description = x.Description,
                    Height = x.Height,
                    Weight = x.Weight,
                    Position = x.Position,
                    Nationality = new Nationality{Name = x.Nationality.Name,PngImage = x.Nationality.PngImage},
                    Team = new Team
                    {
                        Name = x.Team.Name,
                        League = new League
                        {
                            Name = x.Team.League.Name,
                            Nationality = new Nationality
                            {
                                Name = x.Team.League.Nationality.Name,
                            }

                        },
                    },
                    WikiLink = x.WikiLink,
                    ShirtNumber = x.ShirtNumber,
                    PngImage = x.PngImage,
                }).Single();

        }

        public IEnumerable<Player> GetPlayers()
        {



            return _context.Players.Include(t=>t.Team).Include(n=>n.Nationality)
                .Include(p=>p.Position)
               .Select(x => new Player
                {
                    Name = x.Name,
                    Surname = x.Surname,
                    Team = x.Team,
                    Nationality = x.Nationality,
                    DateOfBirth =x.DateOfBirth,
                    Height = x.Height,
                    Weight = x.Weight,
                    Position = x.Position,
                    ShirtNumber = x.ShirtNumber,
                 
                    

                }).ToList();
        }

    

        public IEnumerable<Player> GetPlayersFromCountry(string country)
        {
            return _context.Players.Where(p => p.Nationality.Name == country)
                .Include(x=>x.Position)
                .Include(t=>t.Team)
                .Select(x => new Player
                {
                    Name = x.Name,
                    Surname = x.Surname,
                    DateOfBirth =x.DateOfBirth.Date,
                    Height = x.Height,
                    Weight = x.Weight,
                    Position = x.Position,
                    Nationality = x.Nationality,
                    Team =x.Team
                    
                }).ToList();
        }

        public IEnumerable<Player> GetPlayersNames()
        {
            return _context.Players.Select(x => new Player { Name = x.Name, Surname = x.Surname }).ToList();
        }

        public IEnumerable<Player> GetPlayersFromLeague(string league)
        {
            var nameLeague = Regex.Replace(league, @"\-.*", "").Trim();
            var countryLeague = Regex.Match(league, @"\-.*").Value.Replace("-", "").Trim();
            return _context.Players
                .Where(p =>p.Team.League.Name == nameLeague && p.Team.League.Nationality.Name == countryLeague)
                .Select(x => new Player
                {
                    Name = x.Name,
                    Surname = x.Surname,
                    DateOfBirth = x.DateOfBirth.Date,
                    Height = x.Height,
                    Weight = x.Weight,
                    Position = x.Position,
                    Nationality = x.Nationality,
                    Team = x.Team
                });
        }

        public IEnumerable<Player> GetPlayersFromCountryWithLeague(string country, string league)
        {
            var nameLeague = Regex.Replace(league, @"\-.*", "").Trim();
            var countryLeague = Regex.Match(league, @"\-.*").Value.Replace("-","").Trim();
            return _context.Players
                .Where(p => p.Nationality.Name == country && p.Team.League.Name == nameLeague &&
                            p.Team.League.Nationality.Name == countryLeague)
                .Select(x => new Player
                {
                    Name = x.Name,
                    Surname = x.Surname,
                    DateOfBirth = x.DateOfBirth.Date,
                    Height = x.Height,
                    Weight = x.Weight,
                    Position = x.Position,
                    Nationality = x.Nationality,
                    Team = x.Team
                }).ToList();
        }

        
       
    }
}
