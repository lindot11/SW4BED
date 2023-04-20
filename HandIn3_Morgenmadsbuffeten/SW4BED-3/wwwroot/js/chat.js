var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();

connection.start().then(function () {
    console.log("Connected");
}).catch(function (err) {
    console.error(err.toString());
});

connection.on("Update", function () {
    window.location.reload();
})