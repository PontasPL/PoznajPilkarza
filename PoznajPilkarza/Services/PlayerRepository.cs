using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IEnumerable<Player> GetPlayers()
        {

            return _context.Players.Where(p => p.Nationality.Name == "Poland")
                .Select(x => new Player{Name = x.Name,Surname = x.Surname}).ToList();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
