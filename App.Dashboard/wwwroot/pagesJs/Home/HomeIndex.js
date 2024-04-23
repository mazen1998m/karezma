// Function to filter cards based on search input
function filterCards() {
    var searchInput = document.getElementById('searchInput').value.toLowerCase();
    var cards = document.querySelectorAll('.max-width-container .col-2');

    cards.forEach(function (card) {
        var cardText = card.querySelector('p').innerText.toLowerCase();
        if (cardText.includes(searchInput)) {
            card.style.display = 'block';
        } else {
            card.style.display = 'none';
        }
    });
}

// Attach the filterCards function to the input's oninput event
document.getElementById('searchInput').addEventListener('input', filterCards);