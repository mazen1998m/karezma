// Function to filter cards based on search input

checkBarcodeMinimum();
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

//show popup if IsBarcodeMinimum api returns true

function showCustomPopup() {
    const popup = document.createElement('div');
    popup.innerHTML = `
        <div class="custom-popup">
            <div class="custom-popup-content">
                <h2 class="custom-popup-title" data-arabic="تنبيه" data-english="Alert">Alert</h2>
                <p class="custom-popup-message" data-arabic="وصل الباركود إلى الحد الأدنى، يرجى تحديث الباركود" data-english="Barcode has reached the minimum, please update the barcode">
                    Barcode has reached the minimum, please update the barcode
                </p>
                <div class="custom-popup-button-container">
                    <button class="custom-popup-button update-button" data-arabic="تحديث الباركود" data-english="Update Barcode">Update Barcode</button>
                    <button class="custom-popup-button cancel-button" data-arabic="إلغاء" data-english="Cancel">Cancel</button>
                </div>
            </div>
        </div>
    `;

    document.body.appendChild(popup);

    const updateButton = popup.querySelector('.update-button');
    const cancelButton = popup.querySelector('.cancel-button');

    updateButton.onclick = function () {
        window.location.href = '/Barcode/Update';
    };

    cancelButton.onclick = function () {
        document.body.removeChild(popup);
    };

    // Apply current language to the popup
    applyLanguageToPopup();
}

function applyLanguageToPopup() {
    const selectedLanguage = $('#languageSelector').val();
    $('.custom-popup [data-arabic]').each(function () {
        $(this).text(selectedLanguage === 'ar' ? $(this).data('arabic') : $(this).data('english'));
    });

    // Set direction for popup content
    if (selectedLanguage === 'ar') {
        $('.custom-popup-content').css('direction', 'rtl');
    } else {
        $('.custom-popup-content').css('direction', 'ltr');
    }
}

// Modify your existing changeLanguage function
function changeLanguage() {
    const selectedLanguage = $('#languageSelector').val();
    $('[data-arabic]').each(function () {
        $(this).text(selectedLanguage === 'ar' ? $(this).data('arabic') : $(this).data('english'));
    });

    document.querySelectorAll("input[placeholder-ar]")
        .forEach(element => {
            element.placeholder = selectedLanguage === 'ar' ? element.getAttribute('placeholder-ar') : element.getAttribute('placeholder-en');
        });

    // Set direction for body
    document.body.style.direction = selectedLanguage === 'ar' ? 'rtl' : 'ltr';

    // Apply language change to popup if it exists
    applyLanguageToPopup();

    updateEyeIconPosition(selectedLanguage);
}

// Call this function when checking for barcode minimum
function checkBarcodeMinimum() {
    fetch('/Barcode/IsBarcodeMinimum')
        .then(response => response.json())
        .then(data => {
            if (data === true) {
                showCustomPopup();
            }
        })
        .catch(error => console.error('Error:', error));
}




