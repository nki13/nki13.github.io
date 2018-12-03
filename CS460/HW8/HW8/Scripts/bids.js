function ajax_call() {
    var a = document.getElementById('modelID').value;
    var id = parseInt(a);
    console.log(id);
    var source = "/Auction/Bids/" + id;
    console.log(source);
    console.log("in ajax");
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayBids,
        error: errorOnAjax
    });
    console.log("after ajax");
}

function displayBids(BidsList) {
    if (BidsList.length === 0) {
        console.log("item has no bids");
    }
    else {
        console.log("items has bids");
        for (var i = 0; i < BidList.length; i++) {
            // . shows class names
            $(".tbody").append("<tr class=\"bid\"><td>" + BidsList[i].Buyer + "</td><td>$" + Number(BidTable[i].Price).toLocaleString('en-US', { minimumFractionDigits: 2 }) + "</td></tr>");
        }
        console.log("end if");
    }
}

function errorOnAjax() {
    console.log("error showing bids");
}

function main() {
    console.log("in main");
    ajax_call();
    console.log("end of ajax call");
    var interval = 1000 * 5; // 5 seconds delay
    window.setInterval(ajax_call, interval);
}

$(document).ready(main());