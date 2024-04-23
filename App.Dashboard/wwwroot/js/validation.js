var inputElements = document.querySelectorAll("input");
var validationErrorsString = Array.from(inputElements).find(function (inputElement) {
    return inputElement.hasAttribute('validation');
}).getAttribute('validation');
var validationErrors = JSON.parse(validationErrorsString);
var textareaElement =document.querySelectorAll("textarea")

inputElements.forEach(function (inputElement) {

    var propName = inputElement.getAttribute('propertyname');
    var validationAttribute = inputElement.getAttribute('validation');
    if (validationAttribute != null) {
        var validationErrors = JSON.parse(validationErrorsString);
        var errors = validationErrors.filter(x => x.propertyName == propName).map(item => item.errorMessage);
        if (errors.length > 0) {
            inputElement.style.border = "1px solid red";
            inputElement.style.borderRadius = "5px";
            inputElement.style.padding = "5px";
            inputElement.style.margin = "5px";
            inputElement.style.backgroundColor = "rgba(255, 0, 0, 0.1)";
            inputElement.style.color = "red";
            inputElement.setAttribute("title", errors.join("\n"));
        }

        //add span to show error message
        var span = document.createElement("span");
        span.style.color = "red";
        span.style.fontSize = "16px";
        span.style.display = "block";
        span.style.marginTop = "5px";
        span.style.marginLeft = "10px";
        span.innerHTML = errors.join("<br/>");
        inputElement.parentElement.appendChild(span);


    }

});

textareaElement.forEach(function (inputElement) {
    var propName = inputElement.getAttribute('propertyname');
    var validationAttribute = inputElement.getAttribute('validation');
    if (validationAttribute != null) {
        var validationErrors = JSON.parse(validationErrorsString);
        var errors = validationErrors.filter(x => x.propertyName == propName).map(item => item.errorMessage);
        if (errors.length > 0) {
            inputElement.style.border = "1px solid red";
            inputElement.style.borderRadius = "5px";
            inputElement.style.padding = "5px";
            inputElement.style.margin = "5px";
            inputElement.style.backgroundColor = "rgba(255, 0, 0, 0.1)";
            inputElement.style.color = "red";
            inputElement.setAttribute("title", errors.join("\n"));
        }

        //add span to show error message
        var span = document.createElement("span");
        span.style.color = "red";
        span.style.fontSize = "16px";
        span.style.display = "block";
        span.style.marginTop = "5px";
        span.style.marginLeft = "10px";
        span.innerHTML = errors.join("<br/>");
        inputElement.parentElement.appendChild(span);


    }

});


