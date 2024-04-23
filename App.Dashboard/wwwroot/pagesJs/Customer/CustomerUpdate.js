document.getElementById('emailInput').addEventListener('input', function () {
    validateEmail();
});

function validateEmail() {
    var emailInput = document.getElementById('emailInput');
    var emailValidationMessage = document.getElementById('emailValidationMessage');

    if (emailInput.validity.typeMismatch || emailInput.value === "") {
        // Display an error message
        emailValidationMessage.textContent = "Please enter a valid email address.";
        emailInput.setCustomValidity("Please enter a valid email address.");
    } else {
        // Clear the error message
        emailValidationMessage.textContent = "";
        emailInput.setCustomValidity("");
    }
}
//----------------------------------------------------------
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
//--------------------------------------------------------
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