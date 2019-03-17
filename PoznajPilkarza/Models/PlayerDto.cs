using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPilkarza.Models
{
    public class PlayerDto
    {
        
        public string Name { get; set; }

        public string Surname { get; set; }

        public string NationalityName { get; set; }

        public string PositionName { get; set; }
        public int Height { get; set; }

        public int Weight { get; set; }
        public string DateOfBirth { get; set; }

        public string NameTeam { get; set; }

        //public string nameLeague { get; set; }


    }
}
