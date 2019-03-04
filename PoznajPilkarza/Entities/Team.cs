using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPilkarza.Enitites
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int LeagueId { get; set; }
        public League League { get; set; }

        public int Formed { get; set; }
        public string PngImage { get; set; }

        public string Description { get; set; }

        public string WikiLink { get; set; }

        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public int StadiumId { get; set; }
        public virtual Stadium Stadium { get; set; }
        public virtual Player Player { get; set; }

    }
}
