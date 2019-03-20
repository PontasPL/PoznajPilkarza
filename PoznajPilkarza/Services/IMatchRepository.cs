using System.Collections.Generic;
using Match = PoznajPilkarza.Enitites.Match;

namespace PoznajPilkarza.Services
{
    public interface IMatchRepository
    {
        IEnumerable<Match> GetMatchWithDetails();
        IEnumerable<Match> GetMatches();
        IEnumerable<Match> GetMatchWithDetails(string league);
        IEnumerable<Match> GetMatches(string league);
    }
}
