# Journal - Homework 4

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

To implement the Mile to Metric Converter, I first started with adding an [Htpp Get] Action Method to my HomeController.cs file called Converter like so:
```cs
[HttpGet]
        public ActionResult Converter()
        {
            return View();
        }
```
After this I created a view for this Action Method by simply right clicking the method and clicking add view. This automatically made a Converter.cshtml file for me in /Views/Home/. This was a good start, but it didnt have anything on the page, or do anything.
Next, I added HTML form elements to match what Dr. Morse has provided as an example to follow. This included an input element, radio buttons, and submit button. It was fairly easy but even though my page looked nice, it didnt actually 'do' anything.
So I moved on to build the Converter() method in the HomeController.cs file. Here is how I implemented the calculation to metric units, and how I used ViewBag to give back the results:
```cs
double input = Convert.ToDouble(Request.QueryString["input"]);
string unit = Request.QueryString["unit"];
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
string message = "The conversion is: " + Convert.ToString(output) + " " + unit;
ViewBag.Message = message;
```

## Step 4: Color Mixer

The next thing to do was the color mixer. First things first, I created a new git branch and named it 4color. I didn't know how to start with the actual addition of the colors, but I could start with creating some action methods and a filling out a view for that get request. In Dr. Morse's example, his route is /Color/Create meaning I that had to create a new controller. Along with creating a new controller, I had to actually create two create() methods, one that is [HttpGet] and another that is [HttpPost]. Here is what my Color Controller class looks like:
```cs
namespace HW4.Controllers
{
    public class ColorController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string c1, string c2)
        {

            return View();
        }
```
After this I created a view for create() the same way I made one previously for the /Home/Converter. Once again thanks to Dr. Morse's example, it was pretty straight forward. One requirement for this homework was to use Razor's HTML Helpers for all of our form elements. I have never used Razor language before but I knew it involved an '@' sign. Visual Studio is a great helper to understanding what kinds of parameters are expected where and etc. Here is how I used Razor to create HTML form elements used for /Color/Create:
```cs
@{
    ViewBag.Title = "Color Mixer";
}

<h2>Create a New Color</h2>

<p>Please enter colors in HTML hexadecimal format: #AABBCC</p>

@using (Html.BeginForm("Create", "Color", FormMethod.Post))
{
    <div class="form-group">
        @Html.Label("c1", "First Color")
        @Html.TextBox("color1", null, htmlAttributes: new { @class = "form-control", pattern = "#[0-9A-Fa-f]{3,6}", type = "text", placeholder = "#AABBCC", required = "required" })
    </div>
    <div class="form-group">
        @Html.Label("c2", "Second Color")
        @Html.TextBox("color2", null, htmlAttributes: new { @class = "form-control", pattern = "#[0-9A-Fa-f]{3,6}", type = "text", placeholder = "#AABBCC", required = "required" })
    </div>

    <p><button type="submit" class="btn btn-primary btn-lg">Mix Colors</button></p>
}
```
The most important part of the TextBox form elements is the specified pattern in its HTML attributes. This is because this is what requries the user to use proper hexadecimal formatting on inputs. Great! I have something that looks nice and takes input from the user, but it doesn't 'do' any addition of colors of any sort. Just like the convert calculations in the last step, we did it all in the controller. So I decided to go the Color Controller and work on the [HttpPost] Create() method. The first thing to do was to get the user input. I did this by using the Request.Form and referenced each TextBox name show here below:
```cs
c1 = Request.Form["color1"];
c2 = Request.Form["color2"];
```
Thanks to a comment made in class. I knew that using System.Drawing was the right way to go. I googled for a bit, and tried to make sense of what it could offer me. After being stuck for awhile I had decided to ask other classmates for help on an approach to this. They advised me to use the Color structure in System.Drawing, which represented an ARGB color where A,R,G,B are four interger values. They also advised me that I would be using one of the methods from the ColorTranslator class in System.Drawing to perform the translation from an input to an 'add-able' color value. This was a great push in the right direction. Here is how I translated the input and created interger A,R,B,G variables to hold results:
```cs
Color color1 = ColorTranslator.FromHtml(c1);
Color color2 = ColorTranslator.FromHtml(c2);
int alpha = 0;
int red = 0;
int green = 0;
int blue = 0;
```
I was now setup to perform addition on the colors. In the System.Drawing documentation, there are remarks for using the Color structure saying that each of the four components (A,R,G,B) is a number from 0 through 255. I quickly realized when hitting some errors that when adding each value for the resulting color, it cant go over 255 as specified. So here is how I added some checking with if statements before adding each value for the color. If the addition result exceeded 255 for any of the values, it would set that value to 255 instead show here:
```cs
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
```
From here before posting back the result, I had to change it back to a string using ColorTranslator again like so:
```cs
string result = ColorTranslator.ToHtml(Color.FromArgb(alpha, red, green, blue));
```
At this point, I could add the colors which was great. But what I struggled greatly with was using ViewBag to show to the colors in a square, so I seeked peer advice. A classmate advised me that ViewBag can be used in such a way where ViewBag."something", and "something" can be thought of as a square object. He also advised to me that those objects can be set to a string that would be used to style a 'div'. I could have multiple 'div's within a 'div row' that each represent a little part in the result. As before I did the view first, then altered the controller like so:
```cs
//View for Create
@if (@ViewBag.Show)
{
    <div class="row">
        <div class="col-sm-3" style="@ViewBag.firstColor"></div>
        <div class="col-sm-1" style="width:55px"><h1>+</h1></div>
        <div class="col-sm-3" style="@ViewBag.secondColor"></div>
        <div class="col-sm-1" style="width:55px"><h1>=</h1></div>
        <div class="col-sm-3" style="@ViewBag.mixedColor"></div>
    </div>
}
```
```cs
//Create HTTP POST Action Method
ViewBag.Show = true;
ViewBag.firstColor = "width:80px; height:80px; background: " + c1 + "; ";
ViewBag.secondColor = "width:80px; height:80px; background: " + c2 + "; ";
ViewBag.mixedColor = "width:80px; height:80px; background: " + result + "; ";
```

## Step 5: Merging and Commenting

At this point I was confident that my web page was done sufficiently enough to where I could merge my two branches back to master. I started first by advancing master by creating and index.md file. Then I merged the 4converter branch back to master. I had some merge conflicts within my .gitignore file, which were thankfully not to bad to fix. After that I went to the 4color branch and pulled master into it, to see the merge conflicts there. Once again, I had some conflicts in my .gitignore file that were easily fixable. After that was all said and done, I *should have* gone back to master to advance master again, but I was too merge successful excited and did a merge of 4color back to master before advancing it. This fast-forwarded the commits and 'kind-of' disregarded showing the branch on git log --graph. I've learned the hard way, but that is okay because it's better now than later!
Just like the last homework, we had to comment our code in XML. Although because we used Razor this time, we had to include Razor comments as well. They look like this:
```cshtml
@* This is a Razor comment *@
```

## Results: Working!

