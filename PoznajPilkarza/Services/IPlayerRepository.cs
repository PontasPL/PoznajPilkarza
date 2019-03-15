using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoznajPilkarza.Enitites;

namespace PoznajPilkarza.Services
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetPlayers();
        IEnumerable<Player> GetPlayersFromCountry(string country);
        IEnumerable<Player> GetPlayersNames();
        bool Save();
    }
}
