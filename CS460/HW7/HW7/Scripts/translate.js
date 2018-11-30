function req(a) {
    var source = "/Translate/" + a; //Where the get request came from
    // Send an async request to our server, requesting JSON back
    console.log(source);
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayGif,
        error: errorOnAjax
    });
}

function displayGif(data) {
    console.log("Reached display method");
    console.log(data);
    var gif = data.data.images.original.url;
    $('#res').append("<img src='" + gif + "'style='height:120px;width:120px;margin:25px;'></img>");
    console.log("reached after append");
}


function errorOnAjax() {
    console.log("there was an error loading the gif");
}

$('#message').bind('keypress', function (e) {
    if (e.which === 32) {
        var a = $('#message').val(); // What the user typed in
        var last = a.split(" ").pop(); //For use of ajax

        if (filter(last) == true) {
            $('#res').append("<label>" + last + "&nbsp;</label></div>");
        }
        else {
            req(last);
        }
    }

    function filter(message) {
        var noGood = ["me", "I", "you", "the", "something", "it", "is", "my", "in", "a", "on", "our", "all", "am"]
        var bad = false;
        for (var i = 0; i < noGood.length; i++) {
            if (message === noGood[i]) {
                bad = true;
            }
        }
        return bad;
    }
});

// All Javascript functions for  for hw7 goes here

// From Dr. Morse' code
// Callback function registered on a button.  Initiates AJAX call to
// retrieve random numbers from our server