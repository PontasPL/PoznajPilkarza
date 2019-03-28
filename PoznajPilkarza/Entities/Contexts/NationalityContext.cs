using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoznajPilkarza.Enitites;

namespace PoznajPilkarza.Entities.Contexts
{
    public class NationalityContext :DbContext
    {
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Player> Players { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Match> Matches { get; set; }
        public DbSet<League> Leagues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Team>();
        }

        public NationalityContext(DbContextOptions<NationalityContext> options) :base(options)
        {
        }
    }
}
