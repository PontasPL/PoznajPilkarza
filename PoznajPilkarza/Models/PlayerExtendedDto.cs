using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPilkarza.Models
{
    public class PlayerExtendedDto:PlayerDto
    {
        public string LeagueName { get; set; }
        public string NationalLeagueName { get; set; }
        public string FlagNational { get; set; }
        public int ShirtNumber { get; set; }
        public string Description { get; set; }
        public string WikiLink { get; set; }

    }
}
