﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PoznajPilkarza.Entities.Contexts;

namespace PoznajPilkarza.Migrations.League
{
    [DbContext(typeof(LeagueContext))]
    partial class LeagueContextModelSnapshot : ModelSnapshot
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

            modelBuilder.Entity("PoznajPilkarza.Enitites.Nationality", b =>
                {
                    b.Property<int>("NationalityID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeCountryThreeChars");

                    b.Property<string>("CodeCountryTwoChars");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("PngImage");

                    b.Property<long>("TotalPopulation");

                    b.Property<string>("WikiLink");

                    b.HasKey("NationalityID");

                    b.ToTable("Nationalities");
                });

            modelBuilder.Entity("PoznajPilkarza.Enitites.League", b =>
                {
                    b.HasOne("PoznajPilkarza.Enitites.Nationality", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
