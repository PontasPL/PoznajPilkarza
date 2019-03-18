using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoznajPilkarza.Enitites;

namespace PoznajPilkarza.Services
{
    public interface IMangerRepository
    {
        IEnumerable<Manager> GetManagers();
        IEnumerable<Manager> GetManagersFromCountry(string country);
        IEnumerable<Manager> GetManagersFromLeague(string league);
        IEnumerable<Manager> GetManagersFromCountryWithLeague(string country, string league);
    }
}
