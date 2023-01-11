const http = require('http');
const path = require('path');
const osUtils = require('os-utils');
const os = require('os');
const geoip = require('ipapi.co');
const publicIp = require('public-ip');
const { getSunrise, getSunset } = require('sunrise-sunset-js');
const express = require('express');
const axios = require('axios');
const cheerio = require('cheerio');
const app = express();
const server = http.createServer(app);
const IP2LOC = require('ip2location-nodejs');
const APPID = "627dd26ec6398215229e708af7b02c8d";

let getData = html => {
  const $ = cheerio.load(html);
  return null;//$("#comic").children("img:first").attr("src");
}

let ip2loc = new IP2LOC.IP2Location();
ip2loc.open('./ip.bin');

app.use(express.static(path.join(__dirname, 'public')));

const PORT = process.env.PORT || 5000;


var histogramLength = 61;
var cpuHist = [];
var interval = 500;
var io = require("socket.io")(server);
var comic_url = null;
var random_xkcd_url = "https://c.xkcd.com/random/comic"
var xkcd_url = "https://www.xkcd.com"

for( var i = 0; i < histogramLength; i++) cpuHist[i] = [i,0];

server.listen(PORT, () =>{ 
    console.log(`Server running on port ${PORT}`);
    io.on('connection', function (socket) {
        
        publicIp.v4().then(
            (v4)=>{
                var longi = ip2loc.getLongitude(v4);
                var lat = ip2loc.getLatitude(v4);

                var sunset = getSunset(lat, longi);
                var sunrise = getSunrise(lat,longi);
                
                socket.emit("sunset-sunrise",[sunset,sunrise]);
                
                var weather_url = `http://api.openweathermap.org/data/2.5/weather?`
                                    + `lat=${lat}&lon=${longi}&appid=${APPID}`;
                var forecast_url = `http://api.openweathermap.org/data/2.5/forecast?`
                                    + `lat=${lat}&lon=${longi}&appid=${APPID}`;
                axios.get(weather_url).then( resp => {
                     console.log(resp.data.main.temp);
                     socket.emit("weatherData", resp.data);
                });
                axios.get(forecast_url).then( resp => {
                     console.log(resp.data.list[0]);
                     socket.emit("forecastData", resp.data.list[0]);
                });

            }).catch(
                () => {

                }
            );
            

        socket.emit("cpuType", os.cpus()[0].model);
        axios.get(random_xkcd_url).then( resp => {
          xkcd_url = resp.request.res.responseUrl
        });
        axios.get(xkcd_url)
             .then(response =>{
               //console.log(response.data);
               comic_url = getData(response.data);
             })
             .catch(error => {
               console.log(error);
             });
        socket.emit("comic_url", comic_url);

              
        //sets interval to check cpu usage
        
        console.log(os.userInfo().username);
        var intv = setInterval(
            () => {
                osUtils.cpuUsage((value) => {
                    updateHist(Math.round(value*100));
                    io.emit("cpu histogram", cpuHist);
                    io.emit("currentUsage",value);
                });
            }, 
            interval);
        
        socket.on("disconnect", ()=>{
            clearInterval(intv);
            delete socket;
        });
        
    });
});

function updateHist(cpuLoad){
    if(cpuHist.length >= histogramLength) 
        cpuHist.shift();
    
    cpuHist.push([0,cpuLoad]);

    for(var i = 0; i< histogramLength; i++)
        cpuHist[i][0] = i;
}


