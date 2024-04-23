// Declare global variables for map, marker, and text boxes
var map, marker, latitudeTextBox, longitudeTextBox;

// Initialize and add the map
function initMap() {

    var initialPosition = { lat: 20.0000000, lng: 20.0000000 }; // San Francisco, CA

    // Create a new map centered at the initial position
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 12,
        center: initialPosition
    });
    var customIcon = {
        url: 'https://cdn-icons-png.flaticon.com/128/3135/3135715.png',
        scaledSize: new google.maps.Size(40, 40),
    };
    // Create a marker and set its position
    marker = new google.maps.Marker({
        position: initialPosition,
        map: map,
        draggable: true, // Allow the marker to be dragged
        title: 'User', // Display a tooltip when the marker is hovered
        icon: customIcon,
    });

    // Set up event listener to update text boxes when marker is dragged
    marker.addListener('dragend', updateTextBoxes);

    // Get references to the text boxes
    latitudeTextBox = document.getElementById('latitude');
    longitudeTextBox = document.getElementById('longitude');

    // Initialize text boxes with the initial marker position
    updateTextBoxes();
}

// Update text boxes with the current marker position
function updateTextBoxes() {
    var position = marker.getPosition();
    latitudeTextBox.value = position.lat();
    longitudeTextBox.value = position.lng();
}