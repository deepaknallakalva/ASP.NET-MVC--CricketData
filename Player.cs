using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketData.Models.Entities
{
    public class Player
    {
        public int PlayerId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String years { get; set; }
        public String Photo { get; set; }

        public virtual ICollection<CountryPlayer> CountryPlayers { get; set; }

        public void UpdateValues(Player player)
        {
            this.Name = player.Name;
            this.Description = player.Description;
            this.years = player.years;
            this.Photo = player.Photo;
            this.CountryPlayers = player.CountryPlayers;
        }

    }
}
