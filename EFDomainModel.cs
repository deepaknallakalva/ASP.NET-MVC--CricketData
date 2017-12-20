using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketData.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CricketData.Models
{
    public class EFDomainModel : IStoreDomainModel
    {
        private ApplicationDbContext context;
        public EFDomainModel(ApplicationDbContext ctx)
        {
            context = ctx;

        }
       

        public void UpdatePlayer(Player player)
        {
            Player currentPlayer = Players.Single(p => p.PlayerId == player.PlayerId);
            currentPlayer.CountryPlayers.Clear();
            currentPlayer.UpdateValues(player);
            context.SaveChanges();
        }

        public IEnumerable<CountryPlayer> CountryPlayers
        {
            get { return context.CountryPlayer; }
        }


        public IEnumerable<Player> Players
        {
            get { return context.Players.Include(c => c.CountryPlayers).ThenInclude(cp => cp.Country); }

        }

        public IEnumerable<Country> Countries
        {
            get
            {
                return context.Countries.Include(c => c.CountryPlayers)
                  .ThenInclude(cp => cp.Player);
            }
        }

        public IEnumerable<Customer> Customers
        {
            get { return context.Customers; }
        }

        public IEnumerable<Comments> Comment
        {
            get { return context.Comment; }
        }


        public void UpdateCustomer(Customer customer)
        {

            Customer currentCustomer = Customers.Single(c => c.CustomerId == customer.CustomerId);
            currentCustomer.UpdateValues(customer);
            context.SaveChanges();
        }
        public bool AddCustomer(Customer customer)
        {
            
            foreach (Customer tempCustomer in Customers)
            {
                if (tempCustomer.Email.CompareTo(customer.Email) == 0)
                    return false;
            }
            context.Customers.Add(customer);

            context.SaveChanges();
            return true;
        }

        public void AddComment(string Comment,int playerID,int customerID,string customername)
        {

            context.Comment.AddRange(new Comments { UserComment = Comment,PlayerId=playerID,CustomerId=customerID ,name=customername});
            context.SaveChanges();
        }

    }
}
