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
//----------------------------------------------------------------------
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