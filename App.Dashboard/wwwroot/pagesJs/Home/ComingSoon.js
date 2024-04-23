// Function to filter cards based on search input
function filterCards() {
    var searchInput = document.getElementById('searchInput').value.toLowerCase();
    var cards = document.querySelectorAll('.max-width-container .col-2');
    // var texts = ["DIHLIZ App", "Enter and withdraw and Transfere", "Warehouse", "customer", "Employees", "Back Up Data", "Package","Reports","Help"]
    //var counter=0;
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