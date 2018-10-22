# Journal - Homework 4 New

For this homework, I created my first ASP.NET MVC 5 Web application that does not use a database. This web application has two features, which include a mile to metric converter and a color mixer. Through this homework, I learn how to send data from the browser to the server and vice versa. Also, I was required to use two git branches for this homework for each feature, to get familiar with merging conflicts.
I was unfamiliar with MVC projects and Razor code. Thankfully, in class, we did some examples and were able to get a gist of where in the MVC project we would be making changes to, or adding to. With that, I decided to dive in.

## Links

* [Portfolio Home Page](https://nki13.github.io)
* [Assignment Page](http://www.wou.edu/~morses/classes/cs46x/assignments/HW4_1819.html)
* [Code Repository](https://github.com/nki13/nki13.github.io/tree/master/CS460/HWK4)

## Step 1: Setting up

Getting set up for this fairly simple thanks to Visual Studio. I created my ASP.NET MVC 5 Project with no problems and felt like I was off to a good start. Before committing my setup project to master, I added to my .gitignore file to include the ignored files for this homework. Then I decided to create one of my branches for this homework from here. I decided to name this branch 4converter.

## Step 2: Tackling the Index.cshtml page

When running the web application I could see what the code given to me with the MVC 5 app results to. From there I looked at the code and saw how I could make changes for this homework. Starting with the index page, I noticed that it was pretty straight forward.
One thing to note is that I left the default ASP.NET link for the buttons while I was in the early stages of creating this project, knowing that later I would implement the routes given from this homework's requirements. 

## Step 3: Mile to Metric Converter

To implement the Mile to Metric Converter, I first started with adding an Action Method to my HomeController.cs file called Converter like so:
```cs
[HttpGet]
        public ActionResult Converter()
        {
            return View();
        }
```
After this I created a view for this Action Method by simply right clicking the method and clicking add view. This automatically made a Converter.cshtml file for me in /Views/Home/. This was a good start, but it didnt have anything on the page, or do anything.
Next, I added HTML form elements to match what Dr. Morse has provided as an example to follow. This included an input element, radio buttons, and submit button. It was fairly easy but even though my page looked nice, it didnt actually 'do' anything.
So I moved on to build the Converter() method in the HomeController.cs file. Here what I aded to implement the calculation and use ViewBag to give back the results:
```cs
double input = Convert.ToDouble(Request.QueryString["input"]);
string unit = Request.QueryString["unit"];
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
```

## Step 4: Color Mixer

## Step 5: Merging and Commenting

## Results: Working!

