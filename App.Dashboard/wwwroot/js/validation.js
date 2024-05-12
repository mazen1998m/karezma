var inputElements = document.querySelectorAll("input");
var textareaElements = document.querySelectorAll("textarea");

// Find the first input element with a 'validation' attribute and get its value
var validationElement = Array.from(inputElements).find(function (inputElement) {
    return inputElement.hasAttribute('validation');
});
var validationErrorsString = validationElement ? validationElement.getAttribute('validation') : '[]';
var validationErrors = JSON.parse(validationErrorsString);

function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

function setErrors(chengeLang) {
    // Combine input and textarea elements into one array for processing
    var allElements = Array.from(inputElements).concat(Array.from(textareaElements));

    allElements.forEach(function (element) {
        

        var propName = element.getAttribute('propertyname');
        var validationAttribute = element.getAttribute('validation');
        if (validationAttribute != null) {
            var errors = validationErrors.filter(function (error) {
                return error.propertyName === propName;
            }).map(function (item) {

                var currentLanguage = localStorage.getItem('selectedLanguage');
                currentLanguage = chengeLang ? currentLanguage=="ar"?"en":"ar" :currentLanguage;
                var error = JSON.parse(item.errorMessage);
                return error[capitalizeFirstLetter(currentLanguage)];
            });

            if (errors.length > 0) {
                element.style.border = "1px solid red";
                element.style.borderRadius = "5px";
                element.style.padding = "5px";
                element.style.margin = "5px";
                element.style.backgroundColor = "rgba(255, 0, 0, 0.1)";
                element.style.color = "red";
                element.setAttribute("title", errors.join("\n"));

                // Add span to show error message
                var span = document.createElement("span");
                span.classList.add('error-message'); // Add a class for easy identification
                span.style.color = "red";
                span.style.fontSize = "16px";
                span.style.display = "block";
                span.style.marginTop = "5px";
                span.style.marginLeft = "10px";
                span.innerHTML = errors.join("<br/>");
                element.parentElement.appendChild(span);
            }
        }
    });
}

// Function to simulate a 'storage change' event
function onStorageChange() {
    const originalSetItem = localStorage.setItem;
    localStorage.setItem = function (key, value) {
        if (key === 'selectedLanguage') {
            const event = new Event('storageChange');
            event.key = key;
            event.newValue = value;
            document.dispatchEvent(event);
        }
        originalSetItem.apply(this, arguments);
    };
}

// Initialize the storage change simulation
onStorageChange();

// Listen for the simulated 'storage change' event
document.addEventListener('storageChange', function (e) {
    if (e.key === 'selectedLanguage') {
        // Clear existing error messages
        var errorSpans = document.querySelectorAll('span.error-message');
        errorSpans.forEach(function (span) {
            span.remove();
        });

        // Reapply error messages in the new language
        setErrors(true);
    }
});
// Call setErrors initially to display any existing validation errors
setErrors(false);

