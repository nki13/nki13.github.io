using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW7.Controllers
{
    public class HomeController : Controller
    {
        //safe use of api key
        string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["APIKEY"];

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}