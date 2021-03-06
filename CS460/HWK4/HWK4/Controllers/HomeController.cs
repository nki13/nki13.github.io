﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;


namespace HWK4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Converter()
        {
            double input = Convert.ToDouble(Request.QueryString["input"]);
            string unit = Request.QueryString["unit"];
            // I want the Query String values
            Debug.WriteLine(input);
            Debug.WriteLine(unit);

            double output = 0;
            ViewBag.Result = false;
            if (unit == "millimeters")
            {
                output = input * 1609344;
                ViewBag.Result = true;
            }
            else if (unit == "centimeters")
            {
                output = input * 160934.4;
                ViewBag.Result = true;
            }
            else if (unit == "meters")
            {
                output = input * 1609.344;
                ViewBag.Result = true;
            }
            else if (unit == "kilometers")
            {
                output = input * 1.609344;
                ViewBag.Result = true;
            }

            string result = "The conversion is: " + Convert.ToString(output) + " " + unit;

            ViewBag.Message = result;

            return View();
        }
    }
}