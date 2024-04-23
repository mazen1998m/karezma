$(document).ready(function () {
    // Attach an event listener to input elements with class "form-control"
    $('.form-control').on('blur', function () {
        // Trim spaces at the end of the input value
        $(this).val($(this).val().trim());
    });
});