using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CricketData.Models.Entities
{
    public class Country
    {
        public int CountryId { get; set; }
        public String Name { get; set; }
        public String photo { get; set; }
        public virtual IEnumerable<CountryPlayer> CountryPlayers { get; set; }
    }
}
