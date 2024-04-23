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


//--------------------------------------------------------------

function openConfirmModal(Id) {
    $('#deleteModal_' + Id + '').modal('show');
}
function closeConfirmModal(Id) {
    $('#deleteModal_' + Id + '').modal('hide');
}

const showModalBtn = document.getElementById('showModalBtn');
const modal = document.getElementsByClassName('myModal');
const closeBtn = modal.querySelector('.Cancel');

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
//-----------------------------------------------------------
// Get references to elements
const deleteBtn = document.getElementById('deleteBtn');
const deleteModal = document.getElementById('deleteModal');
const confirmDeleteBtn = document.getElementById('confirmDeleteBtn');
const cancelDeleteBtn = document.getElementById('cancelDeleteBtn');

// Function to show the delete modal
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
    alert('Item deleted!');
    hideDeleteModal();
});






// Get references to elements
const infoBtn = document.getElementById('infoBtn');
const infoModal = document.getElementById('infoModal');
const closeInfoBtn = document.getElementById('closeInfoBtn');

// Function to show the information modal
function showInfoModal() {
    infoModal.style.display = 'block';
}

// Function to hide the information modal
function hideInfoModal() {
    infoModal.style.display = 'none';
}

// Event listener for showing the information modal
infoBtn.addEventListener('click', showInfoModal);

// Event listener for hiding the information modal when Close is clicked
closeInfoBtn.addEventListener('click', hideInfoModal);

// Event listener for hiding the information modal when clicking outside the modal
window.addEventListener('click', (e) => {
    if (e.target === infoModal) {
        hideInfoModal();
    }
});