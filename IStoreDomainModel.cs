using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketData.Models.Entities;
namespace CricketData.Models
{
    public interface IStoreDomainModel
    {
        IEnumerable<Player> Players { get; }
        IEnumerable<Country> Countries { get; }
        IEnumerable<CountryPlayer> CountryPlayers { get; }
        IEnumerable<Customer> Customers { get; }
        IEnumerable<Comments> Comment { get; }
        bool AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void UpdatePlayer(Player player);

        void AddComment(string Comment, int playerID,int customerID,string customername);

        

    }
}
