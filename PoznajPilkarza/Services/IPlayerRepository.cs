using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoznajPilkarza.Enitites;

namespace PoznajPilkarza.Services
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetPlayersNames();
        IEnumerable<Player> GetPlayer(string name, string surname);
        IEnumerable<Player> GetPlayers();
        IEnumerable<Player> GetPlayersFromCountry(string country);
        IEnumerable<Player> GetPlayersFromLeague(string league);
        IEnumerable<Player> GetPlayersFromCountryWithLeague(string country, string league);
    }
}
