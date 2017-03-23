var express = require('express');
var app = express();
var server = require('http').Server(app);
var io = require('socket.io')(server);
var mysql = require('mysql');

app.use(express.static('public'));

//--------------------------------------------
//        sql


//-------------------------------------------------------------
io.on('connection', function(socket) {

  
});

//--------------------------------------------


server.listen(8080, function() {
    console.log("Servidor corriendo en http://localhost:8080");
});
