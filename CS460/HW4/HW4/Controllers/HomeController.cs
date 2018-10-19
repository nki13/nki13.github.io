using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace HW4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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
            ViewBag.result = false;
            if (unit == "millimeters")
            {
                output = input * 1609344;
                ViewBag.result = true;
            }
            else if (unit == "centimeters")
            {
                output = input * 160934.4;
                ViewBag.result = true;
            }
            else if (unit == "meters")
            {
                output = input * 1609.344;
                ViewBag.result = true;
            }
            else if (unit == "kilometers")
            {
                output = input * 1.609344;
                ViewBag.result = true;
            }

            string message = "The conversion is: " + Convert.ToString(output) + " " + unit;

            ViewBag.Message = message;

            return View();
        }

    }
}