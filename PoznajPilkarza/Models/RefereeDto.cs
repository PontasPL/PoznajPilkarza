namespace PoznajPilkarza.Models
{
    public class RefereeDto
    {
        public int RefereeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public NationalityDto Nationality { get; set; }

        public string PngImage { get; set; }

        public string Description { get; set; }

        public string WikiLink { get; set; }
    }
}