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








function showGenre(item) {
    document.getElementById("dropdownMenu1").innerHTML = item.innerHTML;

}

const imageInput = document.getElementById('imageInput');
const employeeImage = document.getElementById('employeeImage');

imageInput.addEventListener('change', (event) => {
    const selectedFile = event.target.files[0];
    if (selectedFile) {
        const imageUrl = URL.createObjectURL(selectedFile);
        employeeImage.src = imageUrl;
    }
});

function createFileList(files) {
    const fileList = Object.create(FileList.prototype);
    Object.defineProperty(fileList, 'length', {
        value: files.length,
        writable: false,
    });
    for (let i = 0; i < files.length; i++) {
        Object.defineProperty(fileList, i, {
            value: files[i],
            writable: false,
        });
    }
    return fileList;
}

var fileList = [];
document.getElementById('Attachments').onchange = function () {
    var files = this.files;
    for (var i = 0; i < files.length; i++) {

        const fileType = files[i].type.toLowerCase(); // Get the file's MIME type in lowercase

        // Define an array of allowed MIME types
        const allowedTypes = [
            "application/msword", // DOC
            "application/vnd.openxmlformats-officedocument.wordprocessingml.document", // DOCX
            "application/vnd.ms-excel", // XLS
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", // XLSX
            "application/vnd.ms-powerpoint", // PPT
            "application/vnd.openxmlformats-officedocument.presentationml.presentation", // PPTX
            "application/pdf", // PDF
            "image/png", // PNG
            "image/jpeg", // JPG and JPEG
        ];

        if (!allowedTypes.includes(fileType)) {
            alert('File type not allowed:', files[i].name);
            return;
        }
        if (files[i].size > 5242880) {
            alert('file size should not be moer than 5MB.');
            return;
        }

    }
    fileList.push(files[i]);

}

document.getElementById('file-list').innerHTML = '';

for (var i = 0; i < fileList.length; i++) {
    var fileName = fileList[i].name;
    var listItem = '<li class="d-flex align-self-start align-items-center" dir="rtl">' + fileName + '  <span class="delete-file">x</span>' + '</li>';
    document.getElementById('file-list').innerHTML += listItem;
}

Array.from(document.getElementsByClassName('delete-file')).forEach(b => b.onclick = function () {
    if (window.confirm('Are you sure ?')) {
        fileList = fileList.filter(f => f.name != this.getAttribute('file-name'));
        this.parentElement.remove();
    }
});
//-----------------------------------------------------------------
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


