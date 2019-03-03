using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPilkarza.Enitites
{
    public class Nationality
    {
        public int NationalityID { get; set; }

        public string Name { get; set; }
        public string CodeCountryTwoChars { get; set; }
        public string CodeCountryThreeChars { get; set; }
        public long TotalPopulation { get; set; }

        public string PngImage { get; set; }

        public string Description { get; set; }

        public string WikiLink { get; set; }
    }
}
