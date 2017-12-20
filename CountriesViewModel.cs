using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using CricketData.Models.Entities;

namespace CricketData.Models.ViewModels
{
    public class CountriesViewModel
    {

        public List<CountryViewModel> Countries { get; protected set; }

        public CountriesViewModel(IEnumerable<Country> countries)
        {

            Countries = new List<CountryViewModel>();
            foreach (Country category in countries)
            {
                this.Countries.Add(new CountryViewModel(category));
            }

        }
    }
}
