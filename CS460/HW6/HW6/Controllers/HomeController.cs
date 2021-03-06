﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW6.Models;
using HW6.Models.Specs;


namespace HW6.Controllers
{
    /// <summary>
    /// This is the only controller for this homework
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Base instance of database to use within ActionMethods
        /// </summary>
        private WideWorldImporters db = new WideWorldImporters();

        /// <summary>
        /// This is the main page of this web app
        /// This also performs finding of matched searched
        /// </summary>
        /// <param name="s">is the search string given by user</param>
        /// <returns>A list of matches to the performed search</returns>
        [HttpGet]
        public ActionResult Index(string s)
        {
            // Get the search input
            s = Request.QueryString["Search"];
            //Although an input is required, this is mainly for the ViewBag to show or not
            if (s == null)
            {
                ViewBag.show = false;
                return View();
            }
            else     //Where controller handles finding the mathched names in the database
            {
                ViewBag.show = true;
                ViewBag.name = s;
                return View(db.People.Where(person => person.FullName.Contains(s)).ToList());
            }   
        }

        /// <summary>
        /// This is the page that displays specifications for a Person that the user searched/and clicked on from the index page
        /// A click on a searched person from the index page get directed here
        /// </summary>
        /// <param name="id">Takes in the id of the person to show specifications for(Given by index view)</param>
        /// <returns>The specs page filled with the person whodse id matches the given parameter</returns>
        [HttpGet]
        public ActionResult Specs(int id)
        {
            //Model that can hold base instance of a Person object to use for returning properties
            //Used because you can only return one thing, that this one thing can hold the many things we need to return
            SpecsModel specs = new SpecsModel();

            //Assigning the found given id to the Person object
            specs.Person = db.People.Find(id);

            //Check if person is a Primary Contact Person
            if (specs.Person.Customers2.Count() <= 0)
            {
                //If false dont show anything else
                ViewBag.IsPrimary = false;
            }
            else
            {
                //If true then show the following info
                ViewBag.IsPrimary = true;

                //For Company Profile
                int customer_id = specs.Person.Customers2.FirstOrDefault().CustomerID;
                specs.Customer = db.Customers.Find(customer_id);

                //For Purchase History Summary
                //Sales
                ViewBag.Sales = specs.Customer.Orders.SelectMany(invoice => invoice.Invoices)
                                                    .SelectMany(invoicelines => invoicelines.InvoiceLines)
                                                    .Sum(sales => sales.ExtendedPrice);
                //Profit
                ViewBag.Profit = specs.Customer.Orders.SelectMany(invoice => invoice.Invoices)
                                                    .SelectMany(invoicelines => invoicelines.InvoiceLines)
                                                    .Sum(profit => profit.LineProfit);
                
                //For Items Purchased
                specs.InvoiceLine = specs.Customer.Orders.SelectMany(invoice => invoice.Invoices)
                                                        .SelectMany(invoicelines => invoicelines.InvoiceLines)
                                                        .OrderByDescending(profit => profit.LineProfit)
                                                        .Take(10)
                                                        .ToList();
            }

            //return the specsmodel
            return View(specs);
        }
    }
}