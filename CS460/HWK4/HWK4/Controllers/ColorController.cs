using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Drawing;

namespace HWK4.Controllers
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

            // Translation from hex to Color structure using System.Drawing
            Color color1 = ColorTranslator.FromHtml(c1);
            Color color2 = ColorTranslator.FromHtml(c2);

            // placeholders for results
            int alpha = 0;
            int red = 0;
            int green = 0;
            int blue = 0;

            // Added checking to make sure values of alpha, red, green, and blue are valid
            if (color1.A + color2.A <= 255)
            {
                alpha = color1.A + color2.A;
            }
            else
            {
                alpha = 255;
            }
            if (color1.R + color2.R <= 255)
            {
                red = color1.R + color2.R;
            }
            else
            {
                red = 255;
            }
            if (color1.G + color2.G <= 255)
            {
                green = color1.G + color2.G;
            }
            else
            {
                green = 255;
            }
            if (color1.B + color2.B <= 255)
            {
                blue = color1.B + color2.B;
            }
            else
            {
                blue = 255;
            }

            // Translation back to hex from Color structure for showing results
            string result = ColorTranslator.ToHtml(Color.FromArgb(alpha, red, green, blue));

            // Making Results show as boxes with each color in it, 3 boxes all together
            ViewBag.Show = true;
            ViewBag.firstColor = "width:80px; height:80px; background: " + c1 + "; ";
            ViewBag.secondColor = "width:80px; height:80px; background: " + c2 + "; ";
            ViewBag.mixedColor = "width:80px; height:80px; background: " + result + "; ";

            return View();
        }
    }
}