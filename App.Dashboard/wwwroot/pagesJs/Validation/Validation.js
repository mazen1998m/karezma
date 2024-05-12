var errorDataElement = document.getElementById('errorData');
var error = JSON.parse(errorDataElement.getAttribute('data-error'));
if (error.length === 0) {
} else {

    var elements;
    var spanElement;
    var lineBreak;

    error.forEach(function (errorMessage) {
        elements = document.getElementById(errorMessage.propertyName);


        spanElement = document.createElement("span");
        spanElement.setAttribute("style", "color: red; font-size: 14px; margin-bottom: 6px;display: block; margin-top: -39px; margin-left: 26px;");
        spanElement.textContent = errorMessage.errorMessage;

        elements.parentNode.insertBefore(spanElement, elements.nextSibling);
        lineBreak = document.createElement("br");
        elements.parentNode.insertBefore(lineBreak, elements.nextSibling);



    });
}