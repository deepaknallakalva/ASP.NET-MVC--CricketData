using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketData.Models.Entities
{
    public class CountryPlayer
    {
        public int CountryPlayerId { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

    }
}
