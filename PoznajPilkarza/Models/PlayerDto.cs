using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPilkarza.Models
{
    public class PlayerDto
    {
        public int PlayerId { get; set; }
        public int ShirtNumber { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public int NationalityID { get; set; }
        public NationalityDto Nationality { get; set; }
        public int PositionId { get; set; }
        public PositionDto Position { get; set; }
        public int Height { get; set; }

        public int Weight { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int TeamId { get; set; }
        public TeamDto Team { get; set; }
        public string PngImage { get; set; }

        public string Description { get; set; }

        public string WikiLink { get; set; }
    }
}
