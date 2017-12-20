using System;
using System.Collections.Generic;
using System.Linq;
using CricketData.Models.Entities;

namespace CricketData.Models.ViewModels
{
    public class PlayerViewModel
    {

        public Player Player
        {
            get
            {
                Player tempPlayer = new Player
                {
                    PlayerId = this.Id,
                    Name = this.Name,
                    Description = this.Description,
                    years = this.years,
                    Photo = this.Photo
                };
                List<CountryPlayer> tempCountryPlayers = new List<CountryPlayer>();
                for (int i = 0; i < AllCountries.Count; i++)
                {
                    if (SelectedCountries[i])
                        tempCountryPlayers.Add(new CountryPlayer
                        {
                            CountryId = AllCountries.ElementAt(i).Id,
                            PlayerId = this.Id
                        });
                }
                tempPlayer.CountryPlayers = tempCountryPlayers;
                return tempPlayer;
            }
        }

        public int Id { get;  set; }
        public String Name { get;  set; }
        public String Description { get;  set; }
        public String years { get;  set; }
        public String Photo { get; set; }
        public List<CountryViewModel> Countries { get;  set; }

        public PlayerViewModel()
        {
            init();
        }
        public PlayerViewModel(int id, String name, String Description, String years, string photo) : this()
        {
            this.Id = id;
            this.Name = name;
            this.Description = Description;
            this.years = years;
            this.Photo = photo;
           // Countries = new List<CountryViewModel>();
        }

        public PlayerViewModel(Player player, Boolean populateCountries = false) : this()
        {
           //Countries = new List<CountryViewModel>();
            this.Id = player.PlayerId;
            this.Name = player.Name;
            this.Description = player.Description;
            this.years = player.years;
            this.Photo = player.Photo;
            if (populateCountries)
            {
                foreach (CountryPlayer countryPlayer in player.CountryPlayers)
                {

                    Countries.Add(new CountryViewModel(countryPlayer.Country, false));

                }
            }
        }



        public List<CountryViewModel> AllCountries { get; set; }
        public bool[] SelectedCountries { get; set; }
       

        public PlayerViewModel(Player player, IEnumerable<Country> countries) : this(player, true)
        {

            this.SelectedCountries = new bool[countries.Count()];
            foreach (Country tempCountry in countries)
            {
                AllCountries.Add(new CountryViewModel(tempCountry));
                bool tempBool = false;
                foreach (CountryPlayer tempCountryPlayer in player.CountryPlayers)
                {
                    if (tempCountryPlayer.CountryId == tempCountry.CountryId)
                    {
                        tempBool = true;
                    }
                }
                SelectedCountries[AllCountries.Count - 1] = tempBool;
            }
        }


        override public String ToString()
        {
            return this.Name;
        }
        private void init()
        {
            Countries = new List<CountryViewModel>();
            AllCountries = new List<CountryViewModel>();

        }

        internal void UpdateCountries(bool[] SelectedCountries, IEnumerable<Country> countries)
        {
            init(); //reset the lists since SelectedCategories will be used to fill them in
            this.SelectedCountries = SelectedCountries;
            foreach (Country tempCountry in countries)
            {
                AllCountries.Add(new CountryViewModel(tempCountry));
                if (SelectedCountries[AllCountries.Count - 1])
                {
                    Countries.Add(new CountryViewModel(tempCountry, false));
                }
            }
        }

    }

}