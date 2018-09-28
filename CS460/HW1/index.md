# Homework 1

Go back to [Home Page](https://nki13.github.io)
* For this homework I had to write a multi-page, hyperlinked set of web pages using HTML, and styling them with CSS and Bootstrap. I was decently familiar with HTML, but spent alot of time googling about CSS and Boostrap. What was really unfamiliar to me was GIt. Once I could wrap my head around it, I ended up benefitting alot from what is has to offer.

## Step 1: Setup Git, create a GitHub account, create local and remote repositories, then synchronize them.

Once Git was downloaded from [here](https://git-scm.com/downloads), I created a local repository to hold all homeworks to come, then initialized it as a git folder. Once that was setup, I did a git config. Once I created an account on GitHub and made a new remote repository to synchronize with my local one, using git remote add as shown below. Then I did a quick git remote to makesure it was added.

```bash
cd Desktop
mkdir Git
cd Git
git init
git config --global user.name "nki13"
git config --global user.email "nki13@wou.edu"
git remote add origin https://github.com/nki13/nki13.github.io
git remote
```
## Step 2: Setup HTML, CSS, and Bootstrap...getting ready to code

After getting Git setup, my next task was to figure out how I was going to write these web pages. Taking a note from my porfessor, I used Visual Studio Code as my text editor. To start out, I created a index.html file and a styles.css file. The HTML below is what I added to index.html to use Bootstrap and CSS. Once I had all of that setup, I was able to finally add content to it.

```HTML
        <!-- Bootstrap CSS -->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.6/css/bootstrap.min.css" integrity="sha384-rwoIResjU2yc3z8GV/NPeZWAv56rSmLldC3R/AZzGRnGxQQKnKkoFVhFQhNUwEyJ" crossorigin="anonymous">
        <link rel="stylesheet" type="text/css" href="styles.css"/>
        <!-- jQuery first, then Tether, then Bootstrap JS. -->
        <script src="https://code.jquery.com/jquery-3.1.1.slim.min.js" integrity="sha384-A7FZj7v+d/sdmMqp/nOQwliLvUsJfDHW+k9Omg/a/EheAdgtzNs3hpfag6Ed950n" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js" integrity="sha384-DztdAPBWPRXSA/3eYEEUWrWCy7G5KFbe8fFjk5JAIxUYHKkDx6Qin1DkWx51bBrb" crossorigin="anonymous"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.6/js/bootstrap.min.js" integrity="sha384-vBWWzlZJ8ea9aCX4pEW3rVHjgjt7zpkNpZk+02D9phzyeVkE+jo0ieGizqPLForn" crossorigin="anonymous"></script>

```
