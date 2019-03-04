using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPilkarza.Enitites
{
    public class League
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeagueId { get; set; }


        public string Name { get; set; }
        public int NationalityId { get; set; }
        public virtual Nationality Nationality { get; set; }
        public string SeasonYear { get; set; }

        public string WikiLink { get; set; }
        public string Description { get; set; }
    }
}
