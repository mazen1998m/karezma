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
            url: 'https://cdn-icons-png.flaticon.com/128/3135/3135715.png',
            scaledSize: new google.maps.Size(40, 40),
        };
        marker = new google.maps.Marker({
            position: { lat: clickedLat, lng: clickedLng },
            map: map,
            title: 'User-Added Marker', // You can set a custom title for the marker
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
//-------------------------------------------------------------------------------------------
//---------------------------------------------------------------------------
document.getElementById('emailInput').addEventListener('input', validateEmail);

function validateEmail() {
    const emailInput = document.getElementById('emailInput');
    const emailError = document.getElementById('emailError');

    // Regular expression for basic email validation
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (!emailRegex.test(emailInput.value)) {
        emailError.textContent = 'Please enter a valid email address.';
    } else {
        emailError.textContent = ''; // Clear the error message if email is valid
    }
}
//---------------------------------------------------------
document.getElementById('password').addEventListener('input', function () {
    // Get the password value
    var password = this.value;

    // Check password complexity (you can customize this according to your requirements)
    var isComplex = checkPasswordComplexity(password);

    // Display message based on complexity
    var messageElement = document.getElementById('passwordMessage');
    if (isComplex) {
        messageElement.textContent = 'Password is complex.';
        messageElement.style.color = '#59FF00';
    } else {
        messageElement.textContent = 'Password is not complex.';
        messageElement.style.color = '#FF0000';
    }
});

function checkPasswordComplexity(password) {
    // Example: Check if the password contains at least 8 characters and a combination of letters, numbers, and special characters
    var regex = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    return regex.test(password);
}
//---------------------------------------------------------
$(document).ready(function () {
    // Function to check if password and confirm password match
    function checkPasswordMatch() {
        var password = $("#password").val();
        var confirmPassword = $("#confirmPassword").val();

        if (password !== confirmPassword) {
            $("#confirmPasswordMessage").text("Password not matching");
        } else {
            $("#confirmPasswordMessage").text("");
        }
    }

    // Event listener for input changes in password and confirm password fields
    $("#password, #confirmPassword").on("keyup", checkPasswordMatch);
});