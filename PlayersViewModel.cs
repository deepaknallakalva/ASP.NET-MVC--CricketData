using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketData.Models.Entities; 
namespace CricketData.Models.ViewModels
{
    public class PlayersViewModel
    {
        public List<PlayerViewModel> Players { get; protected set; }

        public PlayersViewModel(IEnumerable<Player> players)
        {   
            Players = new List<PlayerViewModel>();
            foreach (Player player in players)
            {
                this.Players.Add(new PlayerViewModel(player));
            }
        }


    }
}
