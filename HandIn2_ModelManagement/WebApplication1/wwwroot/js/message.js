"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/messageHub").build();

connection.on("NewExpense", function (expense) {
    var li = document.createElement("li");
    li.textContent = expense;
    document.getElementById("expenseList").appendChild(li);
});

connection.start().then(function () {
    console.log("Connected");
}).catch(function (err) {
    console.error(err.toString());
});
