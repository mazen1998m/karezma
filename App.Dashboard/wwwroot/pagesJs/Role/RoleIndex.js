// Get references to elements
const deleteBtn = document.getElementById('deleteBtn');
const deleteModal = document.getElementById('deleteModal ');
const confirmDeleteBtn = document.getElementById('confirmDeleteBtn');
const cancelDeleteBtn = document.getElementById('cancelDeleteBtn');

function openConfirmModal(Id) {
    $('#deleteModal_' + Id + '').modal('show');
}
// Function to show the delete modal
function closeConfirmModal(Id) {
    $('#deleteModal_' + Id + '').modal('hide');
}
function showDeleteModal() {
    deleteModal.style.display = 'block';
}

// Function to hide the delete modal
function hideDeleteModal() {
    deleteModal.style.display = 'none';
}

// Event listener for showing the delete modal
deleteBtn.addEventListener('click', showDeleteModal);

// Event listener for hiding the delete modal when Cancel is clicked
cancelDeleteBtn.addEventListener('click', hideDeleteModal);

// Event listener for handling the delete action when Delete is clicked
confirmDeleteBtn.addEventListener('click', () => {
    // Perform the delete action here
    // You can replace this with your actual delete logic

    hideDeleteModal();
});
//--------------------------------------------------------------------
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
