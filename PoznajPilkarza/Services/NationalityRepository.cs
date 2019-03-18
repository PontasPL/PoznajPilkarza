using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoznajPilkarza.Enitites;
using PoznajPilkarza.Entities.Contexts;

namespace PoznajPilkarza.Services
{
    public class NationalityRepository:INationalityRepository
    {
        private NationalityContext _context;

        public NationalityRepository(NationalityContext context)
        {
            _context = context;
        }
        public IEnumerable<Nationality> GetNationalities()
        {
            return _context.Nationalities.Select(n=> new Nationality{Name =n.Name} ).ToList();
        }

        private static IEnumerable<Nationality> GetDistinctNationalities(List<string> playersNationalityId)
        {
            var listNationality = new List<Nationality>();
            foreach (var nationalityId in playersNationalityId)
            {
                listNationality.Add(new Nationality {Name = nationalityId});
            }

            return listNationality.OrderBy(n => n.Name);
        }

        public IEnumerable<Nationality> GetPlayersNationalities()
        {
            var playersNationalityId = _context.Players.Select(x => x.Nationality.Name).Distinct().ToList();

            return GetDistinctNationalities(playersNationalityId);
        }

        public IEnumerable<Nationality> GetManagersNationalities()
        {
            var managersNationalityId = _context.Managers.Select(x => x.Nationality.Name)
                .Distinct().ToList();
            return GetDistinctNationalities(managersNationalityId);
        }
    }
}
