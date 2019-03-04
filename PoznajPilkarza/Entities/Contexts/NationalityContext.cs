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
        
        public NationalityContext(DbContextOptions<NationalityContext> options) :base(options)
        {
        }
    }
}
