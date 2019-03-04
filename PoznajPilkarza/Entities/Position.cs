using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoznajPilkarza.Enitites
{
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PositionId { get; set; }
        public string ShortCode { get; set; }
        public string PositionName { get; set; }

        public virtual Player Player { get; set; }
    }
}