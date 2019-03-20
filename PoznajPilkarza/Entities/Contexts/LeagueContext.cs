using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoznajPilkarza.Enitites;

namespace PoznajPilkarza.Entities.Contexts
{
    public class LeagueContext :DbContext
    {
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Team>();
        }

        public LeagueContext(DbContextOptions<LeagueContext> options) : base(options)
        {

        }

    }
}
