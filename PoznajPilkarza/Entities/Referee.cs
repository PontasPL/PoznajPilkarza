﻿namespace PoznajPilkarza.Enitites
{
    public class Referee
    {
        public int RefereeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Nationality Nationality { get; set; }

        public string PngImage { get; set; }

        public string Description { get; set; }

        public string WikiLink { get; set; }
    }
}