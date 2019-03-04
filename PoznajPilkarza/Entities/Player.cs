using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPilkarza.Enitites
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }
        public int ShirtNumber { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public int NationalityId { get; set; }
        public virtual Nationality Nationality { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        public int Height { get; set; }

        public int Weight { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        public string PngImage { get; set; }

        public string Description { get; set; }

        public string WikiLink { get; set; }
    }
}
