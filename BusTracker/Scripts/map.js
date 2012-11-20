
var map;
var initialLocation;
var infowindow;
var siberia = new google.maps.LatLng(60, 105);
var newyork = new google.maps.LatLng(40.69847032728747, -73.9514422416687);
var browserSupportFlag = new Boolean();
var geocoder;
var directionsDisplay;
var directionsService = new google.maps.DirectionsService();
var path = [];
var poly = [];

function initialize()
{

    directionsDisplay = new google.maps.DirectionsRenderer();

    var myOptions = {
        zoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    infowindow = new google.maps.InfoWindow();
    map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
    directionsDisplay.setMap(map);
    // Try W3C Geolocation (Preferred)
    if (navigator.geolocation)
    {
        browserSupportFlag = true;
        navigator.geolocation.getCurrentPosition(function (position)
        {
            initialLocation = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            map.setCenter(initialLocation);
            addMarker(initialLocation);
            codeLatLng(initialLocation, infowindow);
        }, function ()
        {
            handleNoGeolocation(browserSupportFlag);
        });
    }
        // Browser doesn't support Geolocation
    else
    {
        browserSupportFlag = false;
        handleNoGeolocation(browserSupportFlag);
    }

    function handleNoGeolocation(errorFlag)
    {
        if (errorFlag == true)
        {
            alert("Geolocation service failed.");
            initialLocation = newyork;
        } else
        {
            alert("Your browser doesn't support geolocation. We've placed you in Siberia.");
            initialLocation = siberia;
        }
        map.setCenter(initialLocation);
    }

    /*
    google.maps.event.addListener(map, "click", function (evt)
    {
        
        
        if (path.length == 0)
        {
            //path.push(evt.latLng);
            path.push(new google.maps.LatLng(55.862363, 9.856836));
            poly = new google.maps.Polyline({ map: map });
            poly.setPath(path);
            
        } else
        {
            directionsService.route({
                origin: path[path.length - 1],
                destination: new google.maps.LatLng(55.862991, 9.863353),
                travelMode: google.maps.DirectionsTravelMode.DRIVING
            }, function (result, status)
            {
                if (status == google.maps.DirectionsStatus.OK)
                {
                    path = path.concat(result.routes[0].overview_path);
                    poly.setPath(path);
                    
                }
            });
            
        }
        
    });
   */
   
}



function codeLatLng(LatLng, infowindow)
{
    geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'latLng': LatLng }, function (results, status)
    {
        if (status == google.maps.GeocoderStatus.OK)
        {
            map.setCenter(results[0].geometry.location);
            infowindow.setContent(results[0].formatted_address);
            infowindow.open(map, marker);
        } else
        {
            alert("Geocode was not successful for the following reason: " + status);
        }
    });
}

function addMarker(LatLng)
{
    marker = new google.maps.Marker({
        position: LatLng,
        map: map,
        draggable: true,
        animation: google.maps.Animation.DROP
    });
}

function codeAddress(marker)
{
    geocoder = new google.maps.Geocoder();
    var address = document.getElementById('address').value();
    geocoder.geocode({ 'address': address }, function (results, status)
    {
        if (status == google.maps.GeocoderStatus.OK)
        {
            map.setCenter(results[0].geometry.location);
            marker.setPosition(results[0].geometry.location);
            codeLatLng(results[0].geometry.location, infowindow);
            //new google.maps.Marker({
            //map: map,
            //position: results[0].geometry.location
            //  });
        } else
        {
            alert('Geocode was not successful for the following reason: ' + status);
        }
    });
}

function calcRoute()
{
    var start = document.getElementById('start').value;
    var end = document.getElementById('end').value;
    var waypts = [];
    var checkboxArray = document.getElementById('waypoints');
    for (var i = 0; i < checkboxArray.length; i++)
    {
        if (checkboxArray.options[i].selected == true)
        {
            waypts.push({
                location: checkboxArray[i].value,
                stopover: true
            });
        }
    }

    var request = {
        origin: start,
        destination: end,
        waypoints: waypts,
        optimizeWaypoints: true,
        travelMode: google.maps.DirectionsTravelMode.DRIVING
    };




    directionsService.route(request, function (response, status)
    {
        if (status == google.maps.DirectionsStatus.OK)
        {
            poly = new google.maps.Polyline({ map: map });
            path = path.concat(response.routes[0].overview_path);
            poly.setPath(path);

            directionsDisplay.setDirections(response);
            var route = response.routes[0];
            var summaryPanel = document.getElementById('directions_panel');
            summaryPanel.innerHTML = '';
            // For each route, display summary information.
            for (var i = 0; i < route.legs.length; i++)
            {
                var routeSegment = i + 1;
                summaryPanel.innerHTML += '<b>Route Segment: ' + routeSegment + '</b><br>';
                summaryPanel.innerHTML += route.legs[i].start_address + ' to ';
                summaryPanel.innerHTML += route.legs[i].end_address + '<br>';
                summaryPanel.innerHTML += route.legs[i].distance.text + '<br><br>';
            }
        }
    });
}

function addRouteDirection(addresses, color)
{

    var ds = new google.maps.DirectionsService();
    var waypts = [];

    for (var i = 1; i < addresses.length - 1; i++)
    {

        waypts.push({
            location: addresses[i],
            stopover: true
        });

    }

    var request = {
        origin: addresses[0],
        destination: addresses[addresses.length - 1],
        waypoints: waypts,
        optimizeWaypoints: true,
        travelMode: google.maps.DirectionsTravelMode.DRIVING
    };

    ds.route(request, function (response, status)
    {
        if (status == google.maps.DirectionsStatus.OK)
        {
            var localpath = [];
            var lineSymbol = {
                path: google.maps.SymbolPath.FORWARD_CLOSED_ARROW
            };
            poly = new google.maps.Polyline({
                strokeColor: color,
                //   strokeOpacity:0.7,
                strokeWeight: 3,
                //icons: [{
                //    icon: lineSymbol,

                //    repeat:'2%'
                //}]
            });
            localpath = localpath.concat(response.routes[0].overview_path);
            poly.setPath(localpath);
            poly.setMap(map);

            //   directionsDisplay.setDirections(response);

        }
    });


}

function addRoute(addresses, color,name)
{

    var polyOptions = {
        strokeColor: color,
        strokeOpacity: 1.0,
        strokeWeight: 3,
        path:addresses
    }
    polyl = new google.maps.Polyline(polyOptions);
    poly.push({ "name": name, "polyline":polyl });
    for(var i=0;i<poly.length;i++){
        if(poly[i].name==name){
            (poly[i].polyline).setMap(map);
        }
    }
}

function sendLocationToServer()
{
    if (navigator.geolocation)
    {
        browserSupportFlag = true;
        navigator.geolocation.getCurrentPosition(function (position)
        {
            // initialLocation = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            var json_data = "lat=" + position.coords.latitude + "&lon=" + 5;
            //  $("#var1").attr("value",position.coords.latitude);
            //  $("#var2").attr("value", position.coords.longitude);
            $.ajax({
                type: "POST",
                url: "/Home/latlon",
                data: json_data,
                success: function (msg)
                {
                    addMarker(new google.maps.LatLng(msg.lat, msg.lon, false));
                },
                error: function (jqXHR, textStatus, errorThrown)
                {
                    // log the error to the console
                    console.log(
                        "The following error occured: " +
                        textStatus, errorThrown
                    );
                }
            });
        });
    }
}


function drawRoutes(RouteName)
{ 
    $.ajax({
        type: "POST",
        url: "/Home/drawroutes",
        data: { Data: RouteName },
        success: function (msg)
        {
            var addresses = [];
         
            for (var i = 0; i < msg.lat.length; i++)
            {
                addresses[i]= new google.maps.LatLng(msg.lat[i], msg.lon[i], false);
            }
            addRoute(addresses, msg.color,RouteName);
           
        },
        error: function (jqXHR, textStatus, errorThrown)
        {
            // log the error to the console
            console.log(
                "The following error occured: " +
                textStatus, errorThrown
            );
        }
    });

}

function drawStops(RouteName)
{
    $.ajax({
        type: "POST",
        url: "/Home/drawStops",
        data: { Data: RouteName },
        success: function (msg)
        {
            // var addresses = [];
            var image = new google.maps.MarkerImage('./Style/45busstop.png',
       new google.maps.Size(45, 45),
       new google.maps.Point(0, 0),
       new google.maps.Point(22.5, 22.5)
   );

            for (var i = 0; i < msg.lat.length; i++)
            {
                var customMarker = new google.maps.Marker({
                    position: new google.maps.LatLng(msg.lat[i], msg.lon[i], false),
                    map: map,
                    icon: image
                });
               // addMarker(new google.maps.LatLng(msg.lat[i], msg.lon[i], false));
            }
            //  addRoute(addresses, "#0066FF", RouteName);
           

           
           
        },
        error: function (jqXHR, textStatus, errorThrown)
        {
            // log the error to the console
            console.log(
                "The following error occured: " +
                textStatus, errorThrown
            );
        }
    });

}

function clearMap(name)
{
    for (var i = 0; i < poly.length; i++)
    {
        if (poly[i].name == name)
        {
            (poly[i].polyline).setMap(null);
        }
    }
}



