document.addEventListener("DOMContentLoaded", function () {
    const uploadContainer = document.getElementById("uploadContainer");
    const fileInput = document.getElementById("fileUpload");
    const allFilesContainer = document.getElementById("allFilesContainer");
    const uploadedFileList = document.getElementById("uploadedFileList");

    // Add a click event listener to the upload container
    uploadContainer.addEventListener("click", function () {
        // Programmatically trigger a click on the hidden file input
        fileInput.click();
    });

    // Add a change event listener to the file input
    fileInput.addEventListener("change", function () {
        // Access the selected files using fileInput.files
        const selectedFiles = fileInput.files;

        if (selectedFiles.length > 0) {
            // Display the names of selected files in the "AllFiles" container
            uploadedFileList.innerHTML = ''; // Clear the previous list

            for (let i = 0; i < selectedFiles.length; i++) {
                const fileName = selectedFiles[i].name;
                const fileListItem = document.createElement("div");
                fileListItem.textContent = "Uploaded File: " + fileName;
                uploadedFileList.appendChild(fileListItem);
            }
        } else {
            // Clear the file list if no files are selected
            uploadedFileList.innerHTML = '';
        }
    });
});


const imageInput = document.getElementById('imageInput');
const employeeImage = document.getElementById('employeeImage');

imageInput.addEventListener('change', (event) => {
    const selectedFile = event.target.files[0];
    if (selectedFile) {
        const imageUrl = URL.createObjectURL(selectedFile);
        employeeImage.src = imageUrl;
    }
});

function showGenre(item) {
    document.getElementById("dropdownMenu1").innerHTML = item.innerHTML;

}
document.addEventListener("DOMContentLoaded", function () {
    var position = '@Model.Position';
    var selectElement = document.getElementById("Position");
    for (var i = 0; i < selectElement.options.length; i++) {
        if (selectElement.options[i].text === position) {
            selectElement.options[i].selected = true;
            break;
        }
    }
});


//------------------------------------------------------------------------------------------------------------------
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

