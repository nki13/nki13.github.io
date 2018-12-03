# Journal - Homework 7

For this homework we had to make an 'Internet Language Translator' MVC app that implemented AJAX by showing a message with gifs instead of words.

## Links:

* [Portfolio Home Page](https://nki13.github.io)
* [Assignment Page](http://www.wou.edu/~morses/classes/cs46x/assignments/HW7_1819.html)
* [Code Repository](https://github.com/nki13/nki13.github.io/tree/master/CS460/HW7)

## Step 1: Giphy API Key

The first thing to do was to get an API Key from Giphy and use it within our projects without actually sharing out key into Visual Studio, or committing it to our GitHub repositories. I did this by putting a configuration file for that key outside of the Git repo, and accessed it that way. Here is how...
```cs
    string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettin["APIKEY"];

```

## Step 2: The API Controller

The above Giphy Key was used in the APIController which I decided to tackle next. But before doing so, I made sure to quickly make some Razor HTML elements to use. This homework was very straight forward and only required a TextBox for the View page.
For the controller, I made one method that did the translation from a input word to a json result of the gif. This translate method took in the message from the view, then made a get request to the Giphy translate API using that message. Then, I returned the json result from Giphy for that gif. Here is how I did that...
```cs
        public JsonResult Translate(string message)
        {
            string giphyUrl = "https://api.giphy.com/v1/stickers/translate?api_key=" + apiKey + "&s=" + message;

            WebRequest webRequest = WebRequest.Create(giphyUrl);            WebResponse webResponse = webRequest.GetResponse();
            Stream receiveStream = webResponse.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream);
            string responseString = readStream.ReadToEnd();

            var jsonS = new System.Web.Script.Serialization.JavaScriptSerializer();
            var result = jsonS.DeserializeObject(responseString);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
```

## Step 3: The JavaScript File

The JavaScript file was definetely the biggest hump for me to pass. This file held all the AJAX handling for this homework. Here is the main part of that file, which is the AJAX call...
```js
    var source = "/Translate/" + a; //Where the get request came from
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayGif,
        error: errorOnAjax
    });
```

## Step 4: Custom Routing

For this homework I had to show that I could use custom routing, so here is what I added to my RouteConfig.cs file to do so...I used this route shown above in the JavaScript.
```cs
routes.MapRoute(
    name: "Translate",
    url: "Translate/{word}",
    defaults: new { controller = "API", action = "Translate", word = UrlParameter.Optional }
);
```

## Results...
Overall, this was by far the hardest lab for me thus far this term. I think it is because I wasn't able to grasp AJAX that well, and I didnt know the order of steps I should follow to have a good workflow. You can see my struggles in the incompletion of this lab. I was unable to get the gifs to show in my results. When using the developer tools on Chrome it shows that it is reaching my .js file, yet doesnt actually show the gif. I was still able to use AJAX in this lab, just not fully to the extent that I wanted it to work. It bothers me that the gifs dont show, and I plan to keep fiddling with it until I can reach a solution. Nonetheless, I am still happy with how much I've completed and how it looks.
Even though the gifs dont show for this homework I was still able to get everything else working. Here is a demo video I made for this homework showing it running. You will see, and I will explain where my web application fails in the video.

<iframe width="560" height="315" src="https://www.youtube.com/embed/J62z3aDg0pk" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>

