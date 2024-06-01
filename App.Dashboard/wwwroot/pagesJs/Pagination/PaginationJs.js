function generatePagination() {
    debugger
    var currentPageInput = document.getElementById("currentPage");
    var totalPagesInput = document.getElementById("totalPages");
    var numInput = document.getElementById("pagenumber");
    var totalnum = parseInt(numInput.value);
    var currentPage = totalnum
    var totalPages = parseInt(totalPagesInput.value);

    var paginationDiv = document.getElementById("pagination");
    paginationDiv.innerHTML = "";

    var paginationStart = 1;
    var paginationEnd = totalPages;

    if (totalPages > 10) {
        if (currentPage > 6) {
            paginationStart = currentPage - 5;
            paginationEnd = currentPage + 4;
            if (paginationEnd > totalPages) {
                paginationEnd = totalPages;
            }
        } else {
            paginationEnd = 10;
        }
    }

    if (paginationStart > 1) {
        paginationDiv.appendChild(createPageLink("1", currentPageInput, 1, numInput));
        paginationDiv.appendChild(createPageLink("...", currentPageInput, paginationStart - 1, numInput));
    }

    for (var i = paginationStart; i <= paginationEnd; i++) {
        var pageLink = createPageLink(i, currentPageInput, i, numInput);
        paginationDiv.appendChild(pageLink);
    }

    if (paginationEnd < totalPages) {
        paginationDiv.appendChild(createPageLink("...", currentPageInput, paginationEnd + 1, numInput));
        paginationDiv.appendChild(createPageLink(totalPages.toString(), currentPageInput, totalPages, numInput));
    }
}

function createPageLink(text, currentPageInput, pageNum, numInput) {
    var pageLink = document.createElement("button"); // Change 'a' to 'button'
    pageLink.setAttribute("type", "submit"); // Set type as button
    pageLink.innerHTML = text;
    if (parseInt(numInput.value) === pageNum) {
        pageLink.classList.add("active");
    }
    pageLink.onclick = function () {
        numInput.value = pageNum;
        generatePagination();
        return false;
    };
    return pageLink;
}

// To use 'a' as a key:
document.addEventListener('DOMContentLoaded', function () {
    var aKey = document.getElementById('a');
    aKey.addEventListener('click', function () {
        var currentPageInput = document.getElementById("currentPage");
        currentPageInput.value = 1; // Assuming 'a' should go to the first page
        generatePagination();
    });
});

generatePagination();


$(document).ready(function () {
    $('#mySelect').change(function () {
        var selectedOption = $(this).val();
        sendData2(selectedOption);
    });
});



$(document).ready(function () {
    
    $('#mySelect').change(function (event) {
       
        var selectedOption = $(this).val();
        sendData(selectedOption);
    });
});



const selectElement = document.getElementById('mySelect2');
const pageSizeInput = document.getElementById('pageSizeInput');
const submitButton = document.getElementById('submitButton');

// Add event listener to the select element
selectElement.addEventListener('change', function () {
    pageSizeInput.value = this.value;

    submitButton.click();
});


submitButton.addEventListener('click', function () {
   
});


const selectElementTrans = document.getElementById('mySelect');
const pageSizeInputTrans = document.getElementById('pageSizeInput_Trans');
const submitButtonTrans = document.getElementById('submitButton_Trans');


selectElementTrans.addEventListener('change', function () {

    pageSizeInputTrans.value = this.value;

    submitButtonTrans.click();
});


submitButtonTrans.addEventListener('click', function () {

});
