// Function to display the Swal alert
function displaySwal() {
    Swal.fire({
        position: "top-end",
        icon: "success",
        title: "Your work has been saved",
        showConfirmButton: false,
        timer: 1500
    });
}

// Run the displaySwal function when the page is loaded
window.addEventListener('load', function () {
    displaySwal();
});