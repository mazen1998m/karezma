const imageInput = document.getElementById('imageInput');
const employeeImage = document.getElementById('employeeImage');


imageInput.addEventListener('change', (event) => {
    
    const selectedFile = event.target.files[0];
    if (selectedFile) {
        const imageUrl = URL.createObjectURL(selectedFile);
        employeeImage.src = imageUrl;
    }
});
//-----------------------------------------------------------------
function validateEmail() {
    // Get the input element
    var emailInput = document.querySelector('.form-control-lg[type="text"]');

    // Get the input value
    var email = emailInput.value;

    // Regular expression for validating an Email address
    var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    // Check if the input value matches the email pattern
    if (emailRegex.test(email)) {
        document.getElementById("emailValidationResult").innerHTML = "Valid Email Address";
    } else {
        document.getElementById("emailValidationResult").innerHTML = "Invalid Email Address";
    }
}