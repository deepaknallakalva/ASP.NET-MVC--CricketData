using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CricketData.Models.Entities;
namespace CricketData.Models.ViewModels
{
    public class CustomersViewModel
    {
        public List<CustomerViewModel> CustomerViewModels { get; set; }
        public CustomersViewModel()
        {
            CustomerViewModels = new List<CustomerViewModel>();
        }
    }
}