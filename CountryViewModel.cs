using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using CricketData.Models.Entities;


namespace CricketData.Models.ViewModels
{
    public class CountryViewModel
    {
        private Country country;
        public List<PlayerViewModel> Players { get; protected set; }
        public String Name { get; protected set; }
        public int Id { get; protected set; }
        public String photo { get; protected set; }
        public CountryViewModel(int id, String name,String pic)
        {
            this.Id = id;
            Players = new List<PlayerViewModel>();
            this.Name = name;
            this.photo = pic;
        }

        public CountryViewModel(int id, String name, String photo,IEnumerable<Player> Players):this(id, name,photo)
        {
            foreach (Player player in Players)
            {
                this.Players.Add(new PlayerViewModel(player));
            }
        }

        public CountryViewModel(Country country, Boolean populatePlayers = false)
        {
            this.Id = country.CountryId;
            this.Name = country.Name;
            this.photo = country.photo;
            Players = new List<PlayerViewModel>();
            if (populatePlayers)
            {
                foreach (CountryPlayer countryPlayer in country.CountryPlayers)
                {
                    Players.Add(new PlayerViewModel(countryPlayer.Player, false));
                }
            }
        }
        public CountryViewModel(Country country, IEnumerable<CountryPlayer> countryPlayers, IEnumerable<Player> players)
        {
            this.Id = country.CountryId;
            this.Name = country.Name;
            this.photo = country.photo;
            Players = new List<PlayerViewModel>();
            var res = from p in players
                         join cp in countryPlayers on p.PlayerId equals cp.PlayerId
                         where (cp.CountryId == country.CountryId) 
                         select new
                         {
                             PlayerId = p.PlayerId,
                             Name = p.Name,
                             Description = p.Description,
                             Years = p.years,
                             Photo = p.Photo,
                         };
            foreach (var p in res)
            {
                Players.Add(new PlayerViewModel(p.PlayerId, p.Name, p.Years, p.Description, p.Photo));
            }
        }

        override public String ToString()
        {
            return Name;
        }
       

    }
}