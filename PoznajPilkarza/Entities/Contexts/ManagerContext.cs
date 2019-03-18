using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoznajPilkarza.Enitites;

namespace PoznajPilkarza.Entities.Contexts
{
    public class ManagerContext :DbContext
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasMany(r => r.HomeTeams).WithOne(p => p.HomeTeam)
                .HasForeignKey(p => p.HomeTeamId);
            modelBuilder.Entity<Team>().HasMany(r => r.AwayTeams).WithOne(p => p.AwayTeam)
                .HasForeignKey(p => p.AwayTeamId);
        }

        public ManagerContext(DbContextOptions<ManagerContext> options) :base(options)
        {
        }
    }
}
