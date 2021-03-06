﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoznajPilkarza.Enitites
{
    public class Stadium
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StadiumId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }

        public string PngImage { get; set; }

        public string Description { get; set; }

        public string WikiLink { get; set; }
        public ICollection<Team> Team { get; set; }
    }
}