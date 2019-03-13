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

        public IEnumerable<Nationality> GetPlayersNationalities()
        {
            var playersNatioanlityId = _context.Players.Select(x => x.Nationality.Name).Distinct().ToList();

            //var listNationality = new List<Nationality>();
            //foreach (var natioanlityId in playersNatioanlityId)
            //{
            //    listNationality.Add(_context.Nationalities.FirstOrDefault(n => n.NationalityId == natioanlityId));
            //}
            var listNationality = new List<Nationality>();
            foreach (var natioanlityId in playersNatioanlityId)
            {
                listNationality.Add(new Nationality{Name = natioanlityId});
            }

            return listNationality.OrderBy(n=>n.Name);
        }
    }
}
