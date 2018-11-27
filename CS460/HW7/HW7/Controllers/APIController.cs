using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HW7.Controllers
{
    /// <summary>
    /// This is the controller for the API
    /// </summary>
    public class APIController : Controller
    {
        //GET: Translate
        public JsonResult Translate(string message)
        {
            //my api key, safely used
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["APIKEY"];
            //url used for this homework to translate words to gifs
            string giphyUrl = "https://api.giphy.com/v1/stickers/translate?api_key=" + apiKey + "&s=" + message;

            //request instance to giphy
            WebRequest webRequest = WebRequest.Create(giphyUrl);
            //Getting the response from the above request
            WebResponse webResponse = webRequest.GetResponse();
            //Gives data stream from giphy, returns a StreamReader instance
            Stream receiveStream = webResponse.GetResponseStream();
            //Pipes the stream to a higher level stream reader, now the readStream can be "read" for display
            StreamReader readStream = new StreamReader(receiveStream);
            //Actually reading the data from giphy into a string
            string responseString = readStream.ReadToEnd();

            //Parse through JSON object
            //then return it
            // ..
            var jsonS = new System.Web.Script.Serialization.JavaScriptSerializer();
            var result = jsonS.DeserializeObject(responseString);

            //release resources of stream objects
            readStream.Close();
            receiveStream.Close();
            //release resources of response object
            webResponse.Close();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}