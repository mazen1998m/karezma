document.addEventListener("DOMContentLoaded", function () {
    var infoBtn = document.getElementById('infoBtn');
    var infoPopup = document.getElementById('infoPopup');
    var popupTimer;

    infoBtn.addEventListener('mouseenter', function () {
        var title = document.getElementById('infoPopup').textContent;
        infoPopup.innerHTML = title;
        infoPopup.style.display = 'block';
        this.getAttribute('title').display = none;
    });

    infoBtn.addEventListener('mouseleave', function () {
        popupTimer = setTimeout(function () {
            infoPopup.style.display = 'none';
        }, 3000); // Adjust the delay time as needed
    });

    infoPopup.addEventListener('mouseenter', function () {
        clearTimeout(popupTimer);
    });

    infoPopup.addEventListener('mouseleave', function () {
        infoPopup.style.display = 'none';
    });
});