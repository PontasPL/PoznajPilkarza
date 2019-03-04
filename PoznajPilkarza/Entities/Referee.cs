using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoznajPilkarza.Enitites
{
    public class Referee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RefereeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }

        public string PngImage { get; set; }

        public string Description { get; set; }

        public string WikiLink { get; set; }
        public virtual MatchDetails MatchDetails { get; set; }
    }
}