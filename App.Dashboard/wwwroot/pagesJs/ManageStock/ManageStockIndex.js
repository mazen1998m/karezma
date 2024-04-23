function showGenre(item) {
    document.getElementById("dropdownMenu1").innerHTML = item.innerHTML;
}

//---------------------------------------------------------
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
