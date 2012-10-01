
var map;
var initialLocation;
var infowindow;
var siberia = new google.maps.LatLng(60, 105);
var newyork = new google.maps.LatLng(40.69847032728747, -73.9514422416687);
var browserSupportFlag = new Boolean();
var geocoder;

function initialize() {
    
    var myOptions = {
        zoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
   infowindow = new google.maps.InfoWindow();
   map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
  
    // Try W3C Geolocation (Preferred)
    if (navigator.geolocation) {
        browserSupportFlag = true;
        navigator.geolocation.getCurrentPosition(function (position) {
            initialLocation = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            map.setCenter(initialLocation);
            addMarker(initialLocation);
            codeLatLng(initialLocation, infowindow);
        }, function () {
            handleNoGeolocation(browserSupportFlag);
        });
    }
        // Browser doesn't support Geolocation
    else {
        browserSupportFlag = false;
        handleNoGeolocation(browserSupportFlag);
    }

    function handleNoGeolocation(errorFlag) {
        if (errorFlag == true) {
            alert("Geolocation service failed.");
            initialLocation = newyork;
        } else {
            alert("Your browser doesn't support geolocation. We've placed you in Siberia.");
            initialLocation = siberia;
        }
        map.setCenter(initialLocation);
    }
}

function codeLatLng(LatLng, infowindow) {
    geocoder = new google.maps.Geocoder();
        geocoder.geocode({ 'latLng': LatLng }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                map.setCenter(results[0].geometry.location);
                infowindow.setContent(results[0].formatted_address);
                infowindow.open(map, marker);
            } else {
                alert("Geocode was not successful for the following reason: " + status);
            }
        });
    }

function addMarker(LatLng) {
        marker = new google.maps.Marker({
            position: LatLng,
            map: map,
            draggable: true,
            animation: google.maps.Animation.DROP
        });
    }

function codeAddress(marker) {
        geocoder = new google.maps.Geocoder();
        var address = document.getElementById('address').value;
        geocoder.geocode({ 'address': address }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                map.setCenter(results[0].geometry.location);
                marker.setPosition(results[0].geometry.location);
                Geocodee(results[0].geometry.location, infowindow);
                //new google.maps.Marker({
                //map: map,
                //position: results[0].geometry.location
                //  });
            } else {
                alert('Geocode was not successful for the following reason: ' + status);
            }
        });
    }
