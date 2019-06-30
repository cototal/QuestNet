"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/sampleHub").build();
var $commandForm = $("#command-form");
var $story = $("#story");

connection.on("ReceiveMessage", function (message) {
    $story.append(`<p>${message}</p>`);
});

connection.start().then(() => {
    console.log("Connection started.");
    $("#command-form").on("submit", evt => {
        evt.preventDefault();
        console.log("Submitting...");
        const $input = $commandForm.find("input[type='text']");
        const action = $input.val();
        connection.invoke("SendMessage", action).catch(err => {
            return console.error(err.toString())
        });
        $input.val("");
    });
}).catch(err => {
    return console.error(err.toString());
});
