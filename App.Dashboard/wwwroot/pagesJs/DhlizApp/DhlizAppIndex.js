// دالة لإظهار بطاقة المعلومات المنبثقة
function showPopupCard(title, content, event) {
    const popupCard = document.getElementById('popupCard');
    const popupTitle = document.getElementById('popupTitle');
    const popupContent = document.getElementById('popupContent');

    popupTitle.textContent = title;
    popupContent.textContent = content;

    popupCard.style.left = (event.clientX + 10) + 'px'; // تعيين الموقع الأفقي
    popupCard.style.top = (event.clientY + 10) + 'px';  // تعيين الموقع العمودي

    popupCard.style.display = 'block';

    // إضافة حدث click لزر الإغلاق
    const closeButton = document.getElementById('closeButton');
    closeButton.addEventListener('click', hidePopupCard);

    // إضافة حدث click لزر التفاصيل
    const detailsButton = document.getElementById('detailsButton');
    detailsButton.addEventListener('click', () => {
        alert('تم النقر على زر التفاصيل');
    });
}

// دالة لإخفاء بطاقة المعلومات المنبثقة
function hidePopupCard() {
    const popupCard = document.getElementById('popupCard');
    popupCard.style.display = 'none';
}

// إنشاء المربعات لكل قسم
function createColorBlocks(sectionId, colorClass, count, sectionName) {
    const section = document.getElementById(sectionId);

    for (let i = 0; i < count; i++) {
        const square = document.createElement("div");
        square.className = "section-square " + colorClass;

        // تغيير الحدث من mouseenter إلى click
        square.addEventListener('click', (event) => {
            showPopupCard(sectionName, `Username: ${sectionName}`, event);
        });

        section.appendChild(square);
    }
}

// إنشاء المربعات لكل قسم
createColorBlocks("redSection", "square-red", 70, "Mohammad alqannas");
createColorBlocks("greenSection", "square-green", 90, "Sofyan alshaar");
createColorBlocks("yellowSection", "square-yellow", 40, "Dr. Ahmad Alnajjar");
createColorBlocks("blueSection", "square-blue", 50, "available");
  
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.js"></script>


        const ctx = document.getElementById("chart").getContext('2d');
        const myChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"],
                datasets: [{
                    label: 'Inventory Entry  Year 2023',
                    backgroundColor: 'rgba(70, 193, 125, 1)',
                    borderColor: 'rgb(47, 128, 237)',
                    data: [3000, 4000, 2000, 5000, 8000, 9000, 2000],
                }],
            },

            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true,
                        }
                    }]
                }
            },
        });