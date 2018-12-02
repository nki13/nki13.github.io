using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW8.Models
{
    public class ListViewModel
    {
        public List<Item> ItemsList { get; set; }

        public List<Bid> BidsList { get; set; }
    }
}