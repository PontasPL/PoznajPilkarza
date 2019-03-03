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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nationality>().Property(b=>b.Name).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Nationality>().Property(b => b.CodeCountryTwoChars).HasMaxLength(2).IsRequired();
            modelBuilder.Entity<Nationality>().Property(b => b.CodeCountryThreeChars).HasMaxLength(3).IsRequired();
            modelBuilder.Entity<Nationality>().Property(b => b.Description).HasMaxLength(1000);
            modelBuilder.Entity<Nationality>().Property(b => b.WikiLink).HasMaxLength(300);
        }
        public NationalityContext(DbContextOptions<NationalityContext> options) :base(options)
        {

            Database.Migrate();
        }
    }
}
