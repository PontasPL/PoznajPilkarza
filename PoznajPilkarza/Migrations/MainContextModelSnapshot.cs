﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PoznajPilkarza.Entities.Contexts;

namespace PoznajPilkarza.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PoznajPilkarza.Enitites.League", b =>
                {
                    b.Property<int>("LeagueId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("NationalityId");

                    b.Property<string>("SeasonYear")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("WikiLink")
                        .HasMaxLength(300);

                    b.HasKey("LeagueId");

                    b.HasIndex("NationalityId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("PoznajPilkarza.Enitites.Manager", b =>
                {
                    b.Property<int>("ManagerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<int>("NationalityId");

                    b.Property<string>("PngImage");

                    b.Property<string>("Surname")
                        .HasMaxLength(200);

                    b.Property<string>("WikiLink")
                        .HasMaxLength(300);

                    b.HasKey("ManagerId");

                    b.HasIndex("NationalityId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("PoznajPilkarza.Enitites.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwayTeamId");

                    b.Property<int>("FTAwayGoals");

                    b.Property<int>("FTHomeGoals");

                    b.Property<int>("HTAwayGoals");

                    b.Property<int>("HTHomeGoals");

                    b.Property<int>("HomeTeamId");

                    b.Property<int>("LeagueId");

                    b.Property<DateTime>("MatchDay");

                    b.Property<int>("MatchDetailsId");

                    b.HasKey("MatchId");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("LeagueId");

                    b.HasIndex("MatchDetailsId")
                        .IsUnique();

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("PoznajPilkarza.Enitites.MatchDetails", b =>
                {
                    b.Property<int>("MatchDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attendance");

                    b.Property<int>("AwayTeamCorners");

                    b.Property<int>("AwayTeamFoulsCommitted");

                    b.Property<int>("AwayTeamOffsides");

                    b.Property<int>("AwayTeamRedCards");

                    b.Property<int>("AwayTeamShots");

                    b.Property<int>("AwayTeamShotsOnTarget");

                    b.Property<int>("AwayTeamWoodWork");

                    b.Property<int>("AwayYellowCards");

                    b.Property<int>("HomeTeamCorners");

                    b.Property<int>("HomeTeamFoulsCommitted");

                    b.Property<int>("HomeTeamOffsides");

                    b.Property<int>("HomeTeamRedCards");

                    b.Property<int>("HomeTeamShots");

                    b.Property<int>("HomeTeamShotsOnTarget");

                    b.Property<int>("HomeTeamWoodWork");

                    b.Property<int>("HomeYellowCards");

                    b.Property<int>("RefereeId");

                    b.HasKey("MatchDetailsId");

                    b.HasIndex("RefereeId")
                        .IsUnique();

                    b.ToTable("MatchesDetails");
                });

            modelBuilder.Entity("PoznajPilkarza.Enitites.Nationality", b =>
                {
                    b.Property<int>("NationalityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeCountryThreeChars")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<string>("CodeCountryTwoChars")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("FifaCodeCountry")
                        .HasMaxLength(4);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("PngImage");

                    b.Property<long>("TotalPopulation");

                    b.Property<string>("WikiLink")
                        .HasMaxLength(300);

                    b.HasKey("NationalityId");

                    b.ToTable("Nationalities");
                });

            modelBuilder.Entity("PoznajPilkarza.Enitites.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<int>("Height");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<int>("NationalityId");

                    b.Property<string>("PngImage");

                    b.Property<int>("PositionId");

                    b.Property<int>("ShirtNumber");

                    b.Property<string>("Surname")
                        .HasMaxLength(200);

                    b.Property<int>("TeamId");

                    b.Property<int>("Weight");

                    b.Property<string>("WikiLink")
                        .HasMaxLength(300);

                    b.HasKey("PlayerId");

                    b.HasIndex("NationalityId");

                    b.HasIndex("PositionId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("PoznajPilkarza.Enitites.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("ShortCode")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.HasKey("PositionId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("PoznajPilkarza.Enitites.Referee", b =>
                {
                    b.Property<int>("RefereeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("NationalityId");

                    b.Property<string>("PngImage");

                    b.Property<string>("Surname")
                        .HasMaxLength(80);

                    b.Property<string>("WikiLink")
                        .HasMaxLength(300);

                    b.HasKey("RefereeId");

                    b.HasIndex("NationalityId");

                    b.ToTable("Referees");
                });

            modelBuilder.Entity("PoznajPilkarza.Enitites.Stadium", b =>
                {
                    b.Property<int>("StadiumId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("NationalityId");

                    b.Property<string>("PngImage");

                    b.Property<string>("WikiLink")
                        .HasMaxLength(300);

                    b.HasKey("StadiumId");

                    b.HasIndex("NationalityId");

                    b.ToTable("Stadium");
                });

            modelBuilder.Entity("PoznajPilkarza.Enitites.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<int>("Formed");

                    b.Property<int>("LeagueId");

                    b.Property<int>("ManagerId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("PngImage");

                    b.Property<int>("StadiumId");

                    b.Property<string>("WikiLink")
                        .HasMaxLength(300);

                    b.HasKey("TeamId");

                    b.HasIndex("LeagueId");

                    b.HasIndex("ManagerId")
                        .IsUnique();

                    b.HasIndex("StadiumId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("PoznajPilkarza.Enitites.League", b =>
                {
                    b.HasOne("PoznajPilkarza.Enitites.Nationality", "Nationality")
                        .WithMany("Leagues")
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PoznajPilkarza.Enitites.Manager", b =>
                {
                    b.HasOne("PoznajPilkarza.Enitites.Nationality", "Nationality")
                        .WithMany("Managers")
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PoznajPilkarza.Enitites.Match", b =>
                {
                    b.HasOne("PoznajPilkarza.Enitites.Team", "AwayTeam")
                        .WithMany("AwayTeams")
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PoznajPilkarza.Enitites.Team", "HomeTeam")
                        .WithMany("HomeTeams")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PoznajPilkarza.Enitites.League", "League")
                        .WithMany("Matches")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PoznajPilkarza.Enitites.MatchDetails", "MatchDetails")
                        .WithOne("Match")
                        .HasForeignKey("PoznajPilkarza.Enitites.Match", "MatchDetailsId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PoznajPilkarza.Enitites.MatchDetails", b =>
                {
                    b.HasOne("PoznajPilkarza.Enitites.Referee", "Referee")
                        .WithOne("MatchDetails")
                        .HasForeignKey("PoznajPilkarza.Enitites.MatchDetails", "RefereeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PoznajPilkarza.Enitites.Player", b =>
                {
                    b.HasOne("PoznajPilkarza.Enitites.Nationality", "Nationality")
                        .WithMany("Players")
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PoznajPilkarza.Enitites.Position", "Position")
                        .WithMany("Players")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PoznajPilkarza.Enitites.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PoznajPilkarza.Enitites.Referee", b =>
                {
                    b.HasOne("PoznajPilkarza.Enitites.Nationality", "Nationality")
                        .WithMany("Referee")
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PoznajPilkarza.Enitites.Stadium", b =>
                {
                    b.HasOne("PoznajPilkarza.Enitites.Nationality", "Nationality")
                        .WithMany("Stadium")
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PoznajPilkarza.Enitites.Team", b =>
                {
                    b.HasOne("PoznajPilkarza.Enitites.League", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PoznajPilkarza.Enitites.Manager", "Manager")
                        .WithOne("Team")
                        .HasForeignKey("PoznajPilkarza.Enitites.Team", "ManagerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PoznajPilkarza.Enitites.Stadium", "Stadium")
                        .WithMany("Team")
                        .HasForeignKey("StadiumId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
