using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPilkarza.Enitites
{
    public class Nationality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NationalityId { get; set; }

        public string Name { get; set; }
        public string CodeCountryTwoChars { get; set; }
        public string CodeCountryThreeChars { get; set; }
        public long TotalPopulation { get; set; }

        public string PngImage { get; set; }

        public string Description { get; set; }

        public string WikiLink { get; set; }

        public virtual League League { get; set; }
        public virtual Player Player { get; set; }

        public virtual Manager Manager { get; set; }
        public virtual Stadium Stadium { get; set; }
        public virtual Referee Referee { get; set; }
    }
}
