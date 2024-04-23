var map; // Declare the map variable globally
var marker; // Declare the marker variable globally
// Initialize and add the map
function initMap() {
    // The initial center of the map
    var centerLatLng = { lat: -34.397, lng: 150.644 };

    // Create a map object and specify the DOM element for display
    map = new google.maps.Map(document.getElementById('map'), {
        center: centerLatLng,
        zoom: 8 // You can adjust the zoom level as needed
    });

    // Get the text input elements
    var latInput = document.getElementById('lat');
    var lngInput = document.getElementById('lng');

    // Add a click event listener to the map
    google.maps.event.addListener(map, 'click', function (event) {
        // Get the clicked location's latitude and longitude
        var clickedLat = event.latLng.lat();
        var clickedLng = event.latLng.lng();

        // Update the text input values with the latitude and longitude
        latInput.value = clickedLat;
        lngInput.value = clickedLng;

        // Remove existing marker, if any
        if (marker) {
            marker.setMap(null);
        }
        var customIcon = {
            url: 'https://cdn-icons-png.flaticon.com/512/407/407775.png',
            scaledSize: new google.maps.Size(40, 40),
        };
        marker = new google.maps.Marker({
            position: { lat: clickedLat, lng: clickedLng },
            map: map,
            title: 'Warehouse', // You can set a custom title for the marker
            icon: customIcon,
        });
    });
}

// Function to delete the marker
function deleteMarker() {
    if (marker) {
        marker.setMap(null); // Remove the marker from the map
        marker = null; // Set marker variable to null
        // Clear the text input values
        document.getElementById('lat').value = '';
        document.getElementById('lng').value = '';
    }
}
//--------------------------------------------------------------



document.getElementById('position').onchange = function (e) {
    document.getElementById('EmployeeId').disabled = false;
    document.getElementById('EmployeeId').innerHTML = Employess
        .filter(d => d.position == e.target.value)
        .map(d => `<option value="${d.id}">${d.name}</option>`)
        .join('');
}