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
            int alpha = 0;
            int red = 0;
            int green = 0;
            int blue = 0;

            // Added checking to make sure values of alpha, red, green, and blue are valid
            if (color1.A + color2.A >= 255)
            {
                alpha = 255;
            }
            else
            {
                alpha = color1.A + color2.A;
            }
            if (color1.R + color2.R >= 255)
            {
                red = 255;
            }
            else
            {
                red = color1.R + color2.R;
            }
            if (color1.G + color2.G >= 255)
            {
                green = 255;
            }
            else
            {
                green = color1.G + color2.G;
            }
            if (color1.B + color2.B >= 255)
            {
                blue = 255;
            }
            else
            {
                blue = color1.B + color2.B;
            }

            // Translation back to hex from Color type for showing results
            string result = ColorTranslator.ToHtml(Color.FromArgb(alpha, red, green, blue));

            //Results
            string message = "Your mixed color is: " + result;

            ViewBag.Message = message;
            return View();
        }
    }
}