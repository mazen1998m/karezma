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



document.addEventListener("DOMContentLoaded", function () {
    var downloadButtons = document.querySelectorAll('.downloadFile');

    downloadButtons.forEach(function (button) {
        button.addEventListener('click', function (event) {
            event.preventDefault();

            // Find the associated input element
            var filePathInput = event.target.previousElementSibling;

            // Extract the file path from the input value
            var filePath = filePathInput.value;

            // Create a link element to trigger the download
            var downloadLink = document.createElement('a');
            downloadLink.href = filePath;
            downloadLink.download = filePath.split('/').pop(); // Set the file name for download

            // Append the link to the document and trigger the download
            document.body.appendChild(downloadLink);
            downloadLink.click();

            // Remove the link from the document
            document.body.removeChild(downloadLink);
        });
    });
});