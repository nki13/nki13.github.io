using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW8.Models;

namespace HW8.Controllers
{
    public class APIController : Controller
    {
        private AuctionContext auction = new AuctionContext();
        //GET: Bid
        public JsonResult Bids(int? id)
        {
            DetailsModel model = new DetailsModel
            {
                ModelItem = auction.Items.Find(id)
            };

            var result = "";

            if (model.BidsList.Count > 0)
            {
                // get the ID of auction item with bid(s)
                int ItemId = model.ModelItem.ID;

                // use the ID to grab those bids of the auction item
                model.BidsList = auction.Items.SelectMany(a => a.Bids).Where(b => b.ItemID == ItemId).OrderByDescending(c => c.Timestamp).ToList();

                // convert to json for return
                result = JsonConvert.SerializeObject(model.BidsList);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
    }
}