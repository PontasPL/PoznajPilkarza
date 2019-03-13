using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoznajPilkarza.Enitites;

namespace PoznajPilkarza.Services
{
    public interface INationalityRepository
    {
        IEnumerable<Nationality> GetNationalities();
        IEnumerable<Nationality> GetPlayersNationalities();
    }
}
