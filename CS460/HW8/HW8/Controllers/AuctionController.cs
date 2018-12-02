using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW8.Models;

namespace HW8.Controllers
{
    public class AuctionController : Controller
    {
        private AuctionContext db = new AuctionContext();


        // GET: Auction/Create
        public ActionResult CreateBid()
        {
            ViewBag.Buyer = new SelectList(db.Buyers, "Name", "Name");
            ViewBag.ItemID = new SelectList(db.Items, "ID", "Name");
            return View();
        }

        // POST: Auction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBid([Bind(Include = "ItemID,Buyer,Price,Timestamp")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                db.Bids.Add(bid);
                db.SaveChanges();
                return RedirectToAction("IndexList");
            }

            ViewBag.Buyer = new SelectList(db.Buyers, "Name", "Name", bid.Buyer);
            ViewBag.Item = new SelectList(db.Items, "ID", "Name", bid.ItemID);
            return View(bid);
        }

        // GET: Auction
        public ActionResult Index()
        {
            return View();
        }

        // GET: Auction
        public ActionResult IndexList()
        {
            ListViewModel model = new ListViewModel()
            {
                ItemsList = db.Items.Include(i => i.Seller1).ToList(),
                BidsList = db.Bids.Take(10).OrderByDescending(b => b.Timestamp).ToList()
            };
            return View(model);
        }

        // GET: Auction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Auction/Create
        public ActionResult Create()
        {
            ViewBag.Seller = new SelectList(db.Sellers, "Name", "Name");
            return View();
        }

        // POST: Auction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Seller")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("IndexList");
            }

            ViewBag.Seller = new SelectList(db.Sellers, "Name", "Name", item.Seller);
            return View(item);
        }

        // GET: Auction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.Seller = new SelectList(db.Sellers, "Name", "Name", item.Seller);
            return View(item);
        }

        // POST: Auction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Seller")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexList");
            }
            ViewBag.Seller = new SelectList(db.Sellers, "Name", "Name", item.Seller);
            return View(item);
        }

        // GET: Auction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Auction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            List<Bid> allBids = db.Bids.Where(b => b.ItemID == id).ToList();
            if (allBids.Count == 0)
            {
                foreach (Bid bid in allBids)
                {
                    db.Bids.Remove(bid);
                }
            }
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("IndexList");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
