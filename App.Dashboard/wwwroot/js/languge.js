$(document).ready(function () {
    // Restore selected language from localStorage
    const savedLanguage = localStorage.getItem('selectedLanguage');
    if (savedLanguage) {
        $('#languageSelector').val(savedLanguage);
    }

    // Initial language setup
    changeLanguage();

    // Language change event
    $('#languageSelector').change(function () {
        const selectedLanguage = $(this).val();
        localStorage.setItem('selectedLanguage', selectedLanguage);
        changeLanguage();
    });

    function changeLanguage() {
        const selectedLanguage = $('#languageSelector').val();
        $('[data-arabic]').each(function () {
            $(this).text(selectedLanguage === 'ar' ? $(this).data('arabic') : $(this).data('english'));
        });

        document.querySelectorAll(("input[placeholder-ar]"))
            .forEach(element => {
                debugger;
                element.placeholder = selectedLanguage === 'ar' ? element.getAttribute('placeholder-ar') : element.getAttribute('placeholder-en');
            });
    }
});