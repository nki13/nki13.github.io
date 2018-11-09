# Journal - Homework 6

For this homework I had to use a Code First with an Existing Database workflow with yet again another MVC web app. Although I have some previous experience with querying pre-existing databases with multiple tables and relations, I knew trying to navigate through this would be a task to say the least. From watching some of Dr. Morse's videos, I started to rationalize where to start and dove right in.

## Links:

* [Portfolio Home Page](https://nki13.github.io)
* [Assignment Page](http://www.wou.edu/~morses/classes/cs46x/assignments/HW6_1819.html)
* [Code Repository](https://github.com/nki13/nki13.github.io/tree/master/CS460/HW6)

## Step 1: Loading in the database

To load the database into Visual Studio, I first had to load it into SQL Server Studio. From there I could load it into Visual Studio using Code First with an Existing Database. I was able to follow along with Dr. Morse's instructions in class which made this step alot easier that it seemed. Once the database was loaded into Visual Studio, I was able to look through it's Model classes and start to make things useful.

## Step 2: Feature #1, finding matches and showing some of their specifications

I first started with the Index.cshtml page and filled it with some html form elements that matched something like what Dr.Morse shows in his videos. The line of code shown below is important for this homework because it specifies the model to be passed from the controller for index.

```cs
@model IEnumerable<HW6.Models.Person>
```
The next code shown below is how I used the above Model and was able to return either a list of clickable results, or no results.
```cs
@if (ViewBag.show)
{
    if (Model.Count() == 0)
    {
        <h3>Im sorry, your search returned no results</h3>
    }
    else
    {
        <h3>Names matching your search:</h3>

        @* A for each loop that will go through every person with a match to the search, and create a button for the user to interact with the search*@
        foreach (var person in Model)
        {
        <div>
            @*Here you can see how the id of each person is passed to the Specs parameter, and how user is taken to that page*@
            <a class="btn btn-default btn-lg btn-block" role="button" href="Home/Specs/@person.PersonID">@person.FullName (@person.PreferredName)</a>
        </div>
            }
        }
    }
```
The next thing to tackle was the Controller. Here is the important things from my Index ActionMethod in my HomeController...Here is where I navigate the database and find any person whose name contains the given search. What is returned to the view is in accordance with what I declared as my model in the index.cshtml file.
```cs
        [HttpGet]
        public ActionResult Index(string s)
        {
            // Get the search input
            s = Request.QueryString["Search"];

                ViewBag.show = true;
                return View(db.People.Where(person => person.FullName.Contains(s)).ToList());
            }   
        }
```
Lastly, to finish this feature I had to create a ActionMethod and View for the page that each button for every searched match will be linked to. I started with the Action Method like so...
```cs
        [HttpGet]
        public ActionResult Specs(int id)
        {
            SpecsModel specs = new SpecsModel();
            specs.Person = db.People.Find(id);
            return View(specs);
        }
```
*Note that as Dr.Morse had specified in the homework, we were going to have to make a new Model class. Since the model class was for this View, I named it SpecsModel.cs. Here is that file so far...
```cs
    public class SpecsModel
    {
        public Person Person { get; set; }
    }
```
Lastly, was the Specs View. It is basically html form elements showing the persons name and such, as specified in Dr. Morse's videos. The most important part of this file is this line of code. Which specifies the model passed from the controller.
```cs
@model HW6.Models.Specs.SpecsModel
```

## Step 3: Feature #2, going deeper into the database for more specifications

Although I knew the next feature wasnt going to be easy, I was thankful that I was pretty much set up from here. To add on more specifactions for each searched person, I would have to add to the view and likewise the controller for each. I started with the Company Profile as so. To the view I simply added more html elements to display the information given by the controller. Here is what I added to the Specs Action Method:
```cs
if (specs.Person.Customers2.Count() <= 0)
{
    ViewBag.IsPrimary = false;
}
else
{
    ViewBag.IsPrimary = true;
    int customer_id = specs.Person.Customers2.FirstOrDefault().CustomerID;
    specs.Customer = db.Customers.Find(customer_id);
}
```
I had to verify that the person was the Primary Contact Person for a Customer. I did this with an if statement and using the Customers2 Key to access this needed info.
Next, I went on to the Purchase History Summary. As before I added html elements to the Specs View, and furthered the above if statement with these two ViewBag variables used in the View to show the Gross Profit and Gross Sales. You can see below how I was able to nagivate the database to achieve these values.This querying wasn't easy to achieve. Thankfully with the help of classmates, lectures, and LINQ Pad I was able to come up with this...
```cs
ViewBag.Sales = specs.Customer.Orders.SelectMany(invoice => invoice.Invoices)
                                                    .SelectMany(invoicelines => invoicelines.InvoiceLines)
                                                    .Sum(sales => sales.ExtendedPrice);
ViewBag.Profit = specs.Customer.Orders.SelectMany(invoice => invoice.Invoices)
                                                    .SelectMany(invoicelines => invoicelines.InvoiceLines)
                                                    .Sum(profit => profit.LineProfit);
```
I also added a Customer object to my SpecsModel.cs file for this to work:
```cs
public Customer Customer { get; set; }
```
Last to add was the Items Purchased. I started by created a html table element that the results will be shown in. Then I went on to add to the Specs Action Method. Again thankfully with the help of classmates, lectures, and LINQ Pad I was able to come up with this...
```cs
specs.InvoiceLine = specs.Customer.Orders.SelectMany(invoice => invoice.Invoices)
                            .SelectMany(invoicelines => invoicelines.InvoiceLines)
                            .OrderByDescending(profit => profit.LineProfit)
                            .Take(10)
                            .ToList();
```
I also added an InvoiceLine object to my SpecsModel.cs file for this to work:
```cs
public List<InvoiceLine> InvoiceLine { get; set; }
```

## Extra Credit: Pinpoint the companies loacation on a map

While working with other classmates we got an example for this off of leaflet. Here is what I had to add to my Specs.cshtml file for this map feature to work...
```cs
<head>

    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.3.4/dist/leaflet.css"
          integrity="sha512-puBpdR0798OZvTTbP4A8Ix/l+A4dHDD0DGqYW6RQ+9jxkRFclaxxQb/SJAWZfWAkuyeQUytO7+7N4QKrDh+drA=="
          crossorigin="" />

    <!-- Leaflet's JS for use with MapBox -->

    <script src="https://unpkg.com/leaflet@1.3.4/dist/leaflet.js"
            integrity="sha512-nMMmRyTVoLYqjP9hrbed9S+FzjZHW5gY1TWCHA5ckwXZBadntCNs8kEqAWdrb9O7rxbCaA4lKTIWjDXZxflOcA=="
            crossorigin=""></script>

</head>
<div class="col-md-4">
    <div id="map" style="width:500px; height:300px;"> </div>
        <script>
            var long = @Model.Customer.DeliveryLocation.Longitude;
            var lat = @Model.Customer.DeliveryLocation.Latitude;
            var map = L.map('map').setView([lat, long], 15);
            L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'}).addTo(map);
            L.marker([lat, long]).addTo(map).bindPopup('<p>' + @Model.Customer.City.CityName + '</p>').openPopup();
        </script>
    </div>
</div>
```

## Results!

Overall this homework was very challenging, but I continue to learn how valuable my classmates are. To complete this homework it took alot of drawing out and visualization where to navigate. I am happy with the way that my web app came out, and think this is probably the "prettiest" web app I have made thus far. I feel like I am really getting comfortable with the Model, View, Controller framework and am excited to see what other kinds of things we can do with databases. Ill, stop talking here. Here is a video of my web application for this homework running...

[![Alt text](https://img.youtube.com/vi/4OX-1DG7mv0/0.jpg)](https://www.youtube.com/watch?v=4OX-1DG7mv0)

<iframe width="560" height="315" src="https://www.youtube.com/embed/4OX-1DG7mv0" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
