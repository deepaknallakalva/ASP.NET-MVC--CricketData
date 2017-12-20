using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace CricketData.Models.ViewModels
{
    public class CricketViewModel
    {
        public List<CountryViewModel> Categories { get; protected set; }
        public String Name { get; protected set; }
        public CricketViewModel(List<CountryViewModel> categories, String name)
        {
            Categories = categories;
            Name = name;

        }
    }
}