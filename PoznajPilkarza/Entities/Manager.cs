using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoznajPilkarza.Enitites
{
    public class Manager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManagerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int NationalityId { get; set; }
        public virtual Nationality Nationality { get; set; }

        public string PngImage { get; set; }


        public string Description { get; set; }

        public string WikiLink { get; set; }
        public Team Team { get; set; }
    }
}