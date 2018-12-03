using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW8.Models
{
    public class DetailsModel
    {
        public Item ModelItem { get; set; }

        public List<Bid> BidsList { get; set; }
    }
}