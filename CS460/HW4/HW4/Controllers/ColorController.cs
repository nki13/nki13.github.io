using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Drawing;

namespace HW4.Controllers
{
    public class ColorController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.show = false;
            return View();
        }

        [HttpPost]
        public ActionResult Create(string c1, string c2)
        {
            c1 = Request.Form["color1"];
            c2 = Request.Form["color2"];

            //Debug
            Debug.WriteLine(c1);
            Debug.WriteLine(c2);

            // Translation from hex to Color type using System.Drawing
            Color color1 = ColorTranslator.FromHtml(c1);
            Color color2 = ColorTranslator.FromHtml(c2);

            // Actual mixing of colors to placeholders for results
            int alpha = color1.A + color2.A;
            int red = color1.R + color2.R;
            int green = color1.G + color2.G;
            int blue = color1.B + color2.B;

            // Translation back to hex from Color type for showing results
            string result = ColorTranslator.ToHtml(Color.FromArgb(alpha, red, green, blue));

            string message = "Your mixed color is: " + result;

            ViewBag.Message = message;
            return View();
        }
    }
}