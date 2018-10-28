# Journal - Homework 5

For this homework, building off of what I learned in the last homework, I had to create another ASP.NET MVC 5 web application. This time, the web application would use a simple one-table local database. The content for this homework was making a maintenance or service request form, and saving the service requests to a database.
I have never used a database when writing a web application, so I knew this would be interesting. But following along with Dr. Morse in class and taking good notes on steps to follow really helped me out.

## Links:

* [Portfolio Home Page](https://nki13.github.io)
* [Assignment Page](http://www.wou.edu/~morses/classes/cs46x/assignments/HW5_1819.html)
* [Code Repository](https://github.com/nki13/nki13.github.io/tree/master/CS460/HW5)

## Step 1: Setting up

I started with an empty MVC project in Visual Studio. I decided to start with the index landing page for the homework web application, and made it look decent. I breifly explained what this homework was about and made links to both pages I will create later in this homework. Here is what that landing page looks like:
![Landing Page](landing.PNG)

## Step 2: Creating the Database and populating it

The next thing to tackle was the database. I created the database by adding a new SQL Server database item into the App_Data folder. The actual database is a .mdf file which I named Forms.mdf. Once the database was created, the next thing to do was populate it. I did this by creating a new query that I named up.sql. Here is what that up.sql query looks like:
```SQL
CREATE TABLE [dbo].[Forms]
(
	[ID]			INT IDENTITY (1,1)	NOT NULL,
	[FirstName]		NVARCHAR(64)		NOT NULL,
	[LastName]		NVARCHAR(64)		NOT NULL,
	[Phone]			NVARCHAR(64)		NOT NULL,
	[ApartmentName]	NVARCHAR(64)		NOT NULL,
	[UnitNumber]	INT					NOT NULL,
	[Explanation]	VARCHAR(364)		NOT NULL,
	[Permission]	BIT					NOT NULL,
	CONSTRAINT [PK_dbo.Forms] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Forms] (FirstName, LastName, Phone, ApartmentName, UnitNumber, Explanation, Permission) VALUES
	('Nina', 'Loser', '999-999-9178', 'Home', 12, 'Super Important', 0),
	('Anglea', 'Nihei', '999-899-7473', 'Hawaii', 3, 'Not important', 1),
	('Ed', 'Key', '888-889-7616', 'Oahu', 6, 'Super broken', 1),
	('Junior', 'John', '888-809-7616', 'Monmouth', 1, 'Kinda broken', 0),
	('Boy', 'Robins', '888-889-0000', 'Kuliouou', 8, 'Not important', 0)
GO
```
Corresponding to that up.sql query, I also needed to create a down.sql query to drop that table from the database. This is what that down.sql query file looks like:
```SQL
DROP TABLE dbo.Forms
```
Great! I have a database and I can put things into it. Now I have to be able to use it with this web app.

## Step 3: Creating a Model and Data Abstraction Layer(DAL) to match

To be able to use this database with this web application the first thing I needed to do was create a Model. I did this by adding a new file to the Models folder, I named it Forms.cs. In class, I learned that models have attributes and I had to create attributes matching the database in this file. Here is what my Forms Model class looks like:
```cs
namespace HW5.Models
{
    public class Form
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        //label for uses this
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, Phone, Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required, Display(Name = "Apartment Name")]
        public string ApartmentName { get; set; }

        [Required, Display(Name = "Unit Number")]
        public int UnitNumber { get; set; }

        [Required]
        public string Explanation { get; set; }

        public bool Permission { get; set; }
    }
}
```
After creating the Model, I had to create a Data Abstraction Layer to access the database safely. I did this by created a new folder within the project and named it DAL. In that DAL folder I created a new file and named it FormsContext.cs. As seen below this class implements DbContext which is what does the magic of talking to and altering the database. We can use DbContext by using System.Data.Entity as shown below. Here is what my FormsContext looks like:
```cs
using System.Data.Entity;
namespace HW5.DAL
{
    public class FormsContext : DbContext 
    {
        public FormsContext() : base("name=Forms")
        {

        }

        public virtual DbSet<Form> Forms { get; set; }
    }
}
```
## Step 4: Connecting the two

Now that I have both a database and model created, I needed to connect the two. I did this by adding a connection strings section to my web.config file. I retrieved the connection string to my database by right clicking on it in visual studio and clicking properties. From there I copied and pasted that connection string in my web.config file. Here is what I added to my web.config file to make that connection:
```cs
  <connectionStrings>
	<add name="Forms" connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nki13\Desktop\Git\CS460\HW5\HW5\App_Data\Forms.mdf;Integrated Security=True" providerName="System.Data.SqlClient" />
  </connectionStrings>
```

## Step 5: Scaffolding a Controller & Views



## Step 6: Editing and making it my own

## Results: Running!