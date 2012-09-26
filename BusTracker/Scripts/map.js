

var LatLng;
var map;
var infowindow = new google.maps.InfoWindow();
var marker;
function getCurrentPosition() {
    
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(

            function (position) {
               LatLng= google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            });
    }
   
}

function initializeMap() {
    var mapOptions = {
        center: LatLng,
        zoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        zoomControlOptions: true,
        zoomControlOptions: {
            position: google.maps.ControlPosition.RIGHT_BOTTOM,
            style: google.maps.ZoomControlStyle.BIG
        }
    };
    map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
}
   
    function Geocodee(LatLng, infowindow) {
                
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


