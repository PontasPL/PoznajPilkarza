using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoznajPilkarza.Enitites;

namespace PoznajPilkarza.Entities.Contexts
{
    public class PlayerContext:DbContext
    {
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Stadium> Stadium { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Team>().Ignore(p=>p.AwayTeams);
            //modelBuilder.Ignore<Team>();
            modelBuilder.Entity<Team>().HasMany(r => r.HomeTeams).WithOne(p => p.HomeTeam)
                .HasForeignKey(p => p.HomeTeamId);
            modelBuilder.Entity<Team>().HasMany(r => r.AwayTeams).WithOne(p => p.AwayTeam)
                .HasForeignKey(p => p.AwayTeamId);
        }

        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options)
        {
        }
    }
}
