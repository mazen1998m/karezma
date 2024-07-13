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
                element.placeholder = selectedLanguage === 'ar' ? element.getAttribute('placeholder-ar') : element.getAttribute('placeholder-en');
            });
        //add direction: rtl to body
        if (selectedLanguage === 'ar') {
            document.body.style.direction = 'rtl';
            updateEyeIconPosition(selectedLanguage)
        } else {
            document.body.style.direction = 'ltr';
        }

        updateEyeIconPosition(selectedLanguage)


    }
    function updateEyeIconPosition(selectedLanguage) {
        const togglePassword = $('#togglePassword');
        const passwordField = $('#password');
        if (selectedLanguage === 'ar') {
            togglePassword.css('left', '20px').css('right', '');
        } else {
            togglePassword.css('right', '20px').css('left', '');
        }
    }

    $('#togglePassword').click(function () {
        const passwordField = $('#password');
        const passwordFieldType = passwordField.attr('type');
        if (passwordFieldType === 'password') {
            passwordField.attr('type', 'text');
            $(this).removeClass('fa-eye-slash').addClass('fa-eye');
        } else {
            passwordField.attr('type', 'password');
            $(this).removeClass('fa-eye').addClass('fa-eye-slash');
        }
    });


});