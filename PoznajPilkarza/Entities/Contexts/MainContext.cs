using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoznajPilkarza.Enitites;

namespace PoznajPilkarza.Entities.Contexts
{
    public class MainContext :DbContext
    {
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Stadium> Stadium { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nationality>().Property(b => b.Name).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Nationality>().Property(b => b.CodeCountryTwoChars).HasMaxLength(2).IsRequired();
            modelBuilder.Entity<Nationality>().Property(b => b.CodeCountryThreeChars).HasMaxLength(3).IsRequired();
            modelBuilder.Entity<Nationality>().Property(b => b.Description).HasMaxLength(1000);
            modelBuilder.Entity<Nationality>().Property(b => b.WikiLink).HasMaxLength(300);

            modelBuilder.Entity<League>().HasOne<Nationality>(s => s.Nationality).WithOne(sa => sa.League)
                .HasForeignKey<League>(sa => sa.NationalityId);
            modelBuilder.Entity<League>().Property(b => b.Name).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<League>().Property(b => b.SeasonYear).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<League>().Property(b => b.Description).HasMaxLength(1000);
            modelBuilder.Entity<League>().Property(b => b.WikiLink).HasMaxLength(300);

            #region FluentApiTeam

            modelBuilder.Entity<Team>().HasOne<League>(s => s.League).WithOne(s => s.Team)
                .HasForeignKey<Team>(b => b.LeagueId);
            modelBuilder.Entity<Team>().HasOne<Manager>(s => s.Manager).WithOne(s => s.Team)
                .HasForeignKey<Team>(b => b.ManagerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Team>().HasOne<Stadium>(s => s.Stadium).WithOne(s => s.Team)
                .HasForeignKey<Team>(b => b.StadiumId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Team>().Property(b => b.Name).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Team>().Property(b => b.LeagueId).IsRequired();
            modelBuilder.Entity<Team>().Property(b => b.StadiumId).IsRequired();
            modelBuilder.Entity<Team>().Property(b => b.ManagerId).IsRequired();
            modelBuilder.Entity<Team>().Property(b => b.Description).HasMaxLength(1000);
            modelBuilder.Entity<Team>().Property(b => b.WikiLink).HasMaxLength(300);

            #endregion

            #region FluentApiPlayer
            modelBuilder.Entity<Player>().HasOne<Nationality>(s => s.Nationality).WithOne(s => s.Player)
                .HasForeignKey<Player>(b => b.NationalityId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Player>().HasOne<Position>(s => s.Position).WithOne(s => s.Player)
                .HasForeignKey<Player>(b => b.PositionId);
            modelBuilder.Entity<Player>().HasOne<Team>(s => s.Team).WithOne(s => s.Player)
                .HasForeignKey<Player>(b => b.TeamId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Player>().Property(b => b.Name).HasMaxLength(200);
            modelBuilder.Entity<Player>().Property(b => b.Surname).HasMaxLength(200);
            modelBuilder.Entity<Player>().Property(b => b.NationalityId).IsRequired();
            modelBuilder.Entity<Player>().Property(b => b.PositionId).IsRequired();
            modelBuilder.Entity<Player>().Property(b => b.TeamId).IsRequired();
            modelBuilder.Entity<Player>().Property(b => b.WikiLink).HasMaxLength(300);
            modelBuilder.Entity<Player>().Property(b => b.Description).HasMaxLength(1000);

            #endregion

            #region FluentApiManager

            modelBuilder.Entity<Manager>().HasOne<Nationality>(s => s.Nationality).WithOne(s => s.Manager)
                .HasForeignKey<Manager>(b => b.NationalityId);
            modelBuilder.Entity<Manager>().Property(b => b.Name).HasMaxLength(200);
            modelBuilder.Entity<Manager>().Property(b => b.Surname).HasMaxLength(200);
            modelBuilder.Entity<Manager>().Property(b => b.NationalityId).IsRequired();
            modelBuilder.Entity<Manager>().Property(b => b.WikiLink).HasMaxLength(300);
            modelBuilder.Entity<Manager>().Property(b => b.Description).HasMaxLength(1000);

            #endregion

            #region FluentApiPosition

            modelBuilder.Entity<Position>().Property(b => b.PositionName).HasMaxLength(3).IsRequired();
            modelBuilder.Entity<Position>().Property(b => b.ShortCode).HasMaxLength(3).IsRequired();

            #endregion

            #region FluentApiStadium
            modelBuilder.Entity<Stadium>().HasOne<Nationality>(s => s.Nationality).WithOne(s => s.Stadium)
                .HasForeignKey<Stadium>(b => b.NationalityId);
            modelBuilder.Entity<Stadium>().Property(b => b.Name).HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Stadium>().Property(b => b.Capacity).IsRequired();
            modelBuilder.Entity<Stadium>().Property(b => b.NationalityId).IsRequired();
            modelBuilder.Entity<Stadium>().Property(b => b.Description).HasMaxLength(1000);
            modelBuilder.Entity<Stadium>().Property(b => b.WikiLink).HasMaxLength(300);

            #endregion


        }
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }
    }
}
