namespace PoznajPilkarza.Models
{
    public class StadiumDto
    {
        public int StadiumId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }


        public string PngImage { get; set; }

        public string Description { get; set; }

        public string WikiLink { get; set; }
    }
}