using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoznajPilkarza.Enitites;

namespace PoznajPilkarza.Entities.Contexts
{
    public class MatchContext :DbContext
    {
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchDetails> MatchesDetails { get; set; }

        public DbSet<Referee> Referees { get; set; }

        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }

        public DbSet<Nationality> Nationalities { get; set; }

        public DbSet<Stadium> Stadium { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasMany(r => r.HomeTeams).WithOne(p => p.HomeTeam)
                .HasForeignKey(p => p.HomeTeamId);
            modelBuilder.Entity<Team>().HasMany(r => r.AwayTeams).WithOne(p => p.AwayTeam)
                .HasForeignKey(p => p.AwayTeamId);
            //modelBuilder.Entity<Match>().HasOne<League>(s => s.League).WithMany(s => s.Matches)
            //    .HasForeignKey(sa => sa.LeagueId).IsRequired();
            ////modelBuilder.Entity<Match>().HasOne<Team>(s => s.HomeTeam).WithOne(s => s.HomeMatch)
            ////    .HasForeignKey<Match>(sa => sa.HomeTeamId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            ////modelBuilder.Entity<Match>().HasOne<Team>(s => s.AwayTeam).WithOne(s => s.AwayMatch)
            ////    .HasForeignKey<Match>(sa => sa.AwayTeamId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Match>().HasOne<MatchDetails>(s => s.MatchDetails).WithOne(s => s.Match)
            //    .HasForeignKey<Match>(sa => sa.MatchDetailsId).IsRequired();
            //modelBuilder.Entity<Match>().Property(b => b.FTHomeGoals).IsRequired();
            //modelBuilder.Entity<Match>().Property(b => b.FTAwayGoals).IsRequired();

            //modelBuilder.Entity<MatchDetails>().HasOne<Referee>(s => s.Referee).WithOne(s => s.MatchDetails)
            //    .HasForeignKey<MatchDetails>(sa => sa.MatchDetailsId).IsRequired();

            //modelBuilder.Entity<Referee>().HasOne<Nationality>(s => s.Nationality).WithMany(s => s.Referee)
            //    .HasForeignKey(sa => sa.NationalityId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Referee>().Property(b => b.Name).HasMaxLength(50);
            //modelBuilder.Entity<Referee>().Property(b => b.Surname).HasMaxLength(80);
            //modelBuilder.Entity<Referee>().Property(b => b.WikiLink).HasMaxLength(300);
            //modelBuilder.Entity<Referee>().Property(b => b.Description).HasMaxLength(1000);
        }


        public MatchContext(DbContextOptions<MatchContext> options) : base(options)
        {
        }
    }
}
