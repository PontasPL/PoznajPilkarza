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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<League>().Property(b => b.Name).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<League>().Property(b => b.SeasonYear).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<League>().Property(b => b.Description).HasMaxLength(1000);
            modelBuilder.Entity<League>().Property(b => b.WikiLink).HasMaxLength(300);
        }

        public LeagueContext(DbContextOptions<LeagueContext> options) : base(options)
        {
        }

    }
}
