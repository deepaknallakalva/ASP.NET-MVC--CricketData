using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketData.Models.Entities
{
    public class Comments
    {
        public int Id { get; set; }
        public string UserComment { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public string name { get; set; }

    }
}
