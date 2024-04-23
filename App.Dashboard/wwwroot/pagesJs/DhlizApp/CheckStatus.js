const showModalBtn = document.getElementById('showModalBtn');
const modal = document.getElementById('myModal');
const closeBtn = modal.querySelector('.close');

// Function to show the modal
function showModal() {
    modal.style.display = 'block';
}

// Function to hide the modal
function hideModal() {
    modal.style.display = 'none';
}

// Event listener for showing the modal when the button is clicked
showModalBtn.addEventListener('click', showModal);

// Event listener for hiding the modal when the close button is clicked
closeBtn.addEventListener('click', hideModal);

// Event listener to hide the modal when clicking outside the modal
window.addEventListener('click', (e) => {
    if (e.target === modal) {
        hideModal();
    }
});

//-------------------------------------------------------------------------

// Function to show the modal
function showApproveModal(id) {
    document.getElementById('ApproveModal_' + id).style.display = 'block';
}

// Function to hide the modal
function hideApproveModal(id) {
    document.getElementById('ApproveModal_' + id).style.display = 'none';
}

// Function to submit the form
function submitApproveForm(id) {
    document.getElementById('approveForm_' + id).submit();
}


// Function to show the modal
function showDeclineModal(id) {
    document.getElementById('DeclineModal_' + id).style.display = 'block';
}

// Function to hide the modal
function hideDeclineModal(id) {
    document.getElementById('DeclineModal_' + id).style.display = 'none';
}

// Function to submit the form
function submitDeclineForm(id) {
    document.getElementById('RejectReasonInput_' + id).value = document.getElementById('RejectReasonBox_' + id).value;
    document.getElementById('DeclineForm_' + id).submit();
}


//------------------------------------------------------------------------

console.log("test");


//var totalPages = '@ViewBag.indexes';
//var pageNumber = '@ViewBag.LastIndex';

//updatePaginationBar(totalPages, pageNumber);

//// Pagination options
//const options = {
//    dataSource: fetchData,
//    pageSize: 10,
//    callback: function (data, pagination) {
//        console.log("Callback called");

//    },
//};




//--------------------------------------------------------------------------------------------------
// Function to update the pagination control bar
function updatePaginationBar(totalPages, currentPage) {
    const paginationBar = document.getElementById('paginationBar');
    paginationBar.innerHTML = '';

    // Previous button
    const prevButton = document.createElement('button');
    prevButton.innerText = '« Previous';
    prevButton.classList.add('page-index-btn');
    prevButton.addEventListener('click', function () {
        if (currentPage > 1) {
            updatePageIndex(parseInt(currentPage, 10) - 1);
        }
    });
    if (currentPage === "1") {
        prevButton.disabled = true;
    }
    paginationBar.appendChild(prevButton);

    // Display current page and total pages
    const pageInfo = document.createElement('span');
    pageInfo.innerText = `Page ${currentPage} of ${totalPages}`;
    pageInfo.classList.add('page-info');
    paginationBar.appendChild(pageInfo);

    // Add page index buttons
    let numberOfPagesInPager = 5;
    let firstPage = currentPage - (currentPage % numberOfPagesInPager);
    if (currentPage % numberOfPagesInPager == 0) firstPage = firstPage - numberOfPagesInPager;
    let lastPage = firstPage + numberOfPagesInPager;
    for (let i = firstPage + 1; i <= lastPage && i <= totalPages; i++) {
        const pageIndexButton = document.createElement('button');
        pageIndexButton.innerText = i;
        pageIndexButton.classList.add('page-index-btn');
        pageIndexButton.addEventListener('click', function () {
            updatePageIndex(i);
        });

        // Highlight the current page index
        if (i.toString() == currentPage) {
            pageIndexButton.classList.add('active');
        }

        paginationBar.appendChild(pageIndexButton);
    }

    // Next button
    const nextButton = document.createElement('button');
    nextButton.innerText = 'Next »';
    nextButton.classList.add('page-index-btn');
    nextButton.addEventListener('click', function () {
        if (currentPage < totalPages) {
            updatePageIndex(parseInt(currentPage, 10) + 1);
        }
    });
    if (currentPage === totalPages.toString()) {
        nextButton.disabled = true;
    }
    paginationBar.appendChild(nextButton);
}



//--------------------------------------------------------------------------
function validateInput(input) {
    // Remove non-numeric characters using a regular expression
    input.value = input.value.replace(/\D/g, '');
}