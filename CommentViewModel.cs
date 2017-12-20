using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketData.Models.ViewModels
{
    public class CommentViewModel
    {
       

        public string comment { get; set; }
        public int customerid { get; set; }

        public string customername { get; set; }

        public CommentViewModel(string comment,int customerid,string customername)
        {
            this.comment = comment;
            this.customerid = customerid;
            this.customername = customername;
            
        }

        public override string ToString()
        {
            return this.comment;
        }
        public CommentViewModel() { }
        private void init() { }
    }
}
