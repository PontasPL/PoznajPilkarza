using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoznajPilkarza.Enitites;

namespace PoznajPilkarza.Services
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetTeams();
        IEnumerable<Team> GetTeamsInLeague(string league);
    }
}
