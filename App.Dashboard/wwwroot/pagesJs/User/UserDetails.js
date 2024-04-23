
function copyUsertype() {
    // احصل على نص User ID
    var userIdText = document.getElementById("UserType").innerText;

    // إنشاء عنصر نص مؤقت للنسخ
    var tempInput = document.createElement("input");

    // قم بإعطاء العنصر النصي القيمة التي تم الحصول عليها
    tempInput.value = userIdText;

    // إضافة العنصر النصي إلى الصفحة
    document.body.appendChild(tempInput);

    // تحديد نص العنصر النصي
    tempInput.select();

    // نسخ النص إلى الحافظة
    document.execCommand("copy");

    // إزالة العنصر النصي المؤقت
    document.body.removeChild(tempInput);

    // اختيار الأيقونة لتوضيح النسخ
    var copyIcon = document.getElementById("copyIconUsertype");
    copyIcon.style.color = "green";

    // إظهار رسالة النسخ وتحديث نصها
    var copyUserId = document.getElementById("copyUsertype");
    copyUserId.style.display = "inline";
    copyUserId.textContent = "copied";

    // إعادة تعيين لون الأيقونة بعد فترة زمنية
    setTimeout(function () {
        copyIcon.style.color = "chocolate";
    }, 1000);

    // إخفاء رسالة النسخ بعد فترة زمنية
    setTimeout(function () {
        copyUserId.style.display = "none";
    }, 2000);
}
function copyFullName() {
    // احصل على نص User ID
    var FullNameText = document.getElementById("FullName").innerText;

    // إنشاء عنصر نص مؤقت للنسخ
    var tempInput = document.createElement("input");

    // قم بإعطاء العنصر النصي القيمة التي تم الحصول عليها
    tempInput.value = FullNameText;

    // إضافة العنصر النصي إلى الصفحة
    document.body.appendChild(tempInput);

    // تحديد نص العنصر النصي
    tempInput.select();

    // نسخ النص إلى الحافظة
    document.execCommand("copy");

    // إزالة العنصر النصي المؤقت
    document.body.removeChild(tempInput);

    // اختيار الأيقونة لتوضيح النسخ
    var copyIcon = document.getElementById("copyIconFullName");
    copyIcon.style.color = "green";

    // إظهار رسالة النسخ وتحديث نصها
    var copyFullName = document.getElementById("copyFullName");
    copyFullName.style.display = "inline";
    copyFullName.textContent = "copied";

    // إعادة تعيين لون الأيقونة بعد فترة زمنية
    setTimeout(function () {
        copyIcon.style.color = "chocolate";
    }, 1000);

    // إخفاء رسالة النسخ بعد فترة زمنية
    setTimeout(function () {
        copyUserId.style.display = "none";
    }, 2000);
}
function copyPhoneNumber() {
    // احصل على نص User ID
    var PhoneNumberText = document.getElementById("PhoneNumber").innerText;

    // إنشاء عنصر نص مؤقت للنسخ
    var tempInput = document.createElement("input");

    // قم بإعطاء العنصر النصي القيمة التي تم الحصول عليها
    tempInput.value = PhoneNumberText;

    // إضافة العنصر النصي إلى الصفحة
    document.body.appendChild(tempInput);

    // تحديد نص العنصر النصي
    tempInput.select();

    // نسخ النص إلى الحافظة
    document.execCommand("copy");

    // إزالة العنصر النصي المؤقت
    document.body.removeChild(tempInput);

    // اختيار الأيقونة لتوضيح النسخ
    var copyIcon = document.getElementById("copyIconPhoneNumber");
    copyIcon.style.color = "green";

    // إظهار رسالة النسخ وتحديث نصها
    var copyPhoneNumber = document.getElementById("copyPhoneNumber");
    copyPhoneNumber.style.display = "inline";
    copyPhoneNumber.textContent = "copied";

    // إعادة تعيين لون الأيقونة بعد فترة زمنية
    setTimeout(function () {
        copyIcon.style.color = "chocolate";
    }, 1000);

    // إخفاء رسالة النسخ بعد فترة زمنية
    setTimeout(function () {
        copyPhoneNumber.style.display = "none";
    }, 2000);
}
function copyPhone2Number() {
    // احصل على نص User ID
    var PhoneNumberText = document.getElementById("phone2").innerText;

    // إنشاء عنصر نص مؤقت للنسخ
    var tempInput = document.createElement("input");

    // قم بإعطاء العنصر النصي القيمة التي تم الحصول عليها
    tempInput.value = PhoneNumberText;

    // إضافة العنصر النصي إلى الصفحة
    document.body.appendChild(tempInput);

    // تحديد نص العنصر النصي
    tempInput.select();

    // نسخ النص إلى الحافظة
    document.execCommand("copy");

    // إزالة العنصر النصي المؤقت
    document.body.removeChild(tempInput);

    // اختيار الأيقونة لتوضيح النسخ
    var copyIcon = document.getElementById("copyIconPhoneNumber2");
    copyIcon.style.color = "green";

    // إظهار رسالة النسخ وتحديث نصها
    var copyPhoneNumber = document.getElementById("copyPhoneNumber2");
    copyPhoneNumber.style.display = "inline";
    copyPhoneNumber.textContent = "copied";

    // إعادة تعيين لون الأيقونة بعد فترة زمنية
    setTimeout(function () {
        copyIcon.style.color = "chocolate";
    }, 1000);

    // إخفاء رسالة النسخ بعد فترة زمنية
    setTimeout(function () {
        copyPhoneNumber.style.display = "none";
    }, 2000);
}
function copyEmail() {
    // احصل على نص User ID
    var EmailText = document.getElementById("Email").innerText;

    // إنشاء عنصر نص مؤقت للنسخ
    var tempInput = document.createElement("input");

    // قم بإعطاء العنصر النصي القيمة التي تم الحصول عليها
    tempInput.value = EmailText;

    // إضافة العنصر النصي إلى الصفحة
    document.body.appendChild(tempInput);

    // تحديد نص العنصر النصي
    tempInput.select();

    // نسخ النص إلى الحافظة
    document.execCommand("copy");

    // إزالة العنصر النصي المؤقت
    document.body.removeChild(tempInput);

    // اختيار الأيقونة لتوضيح النسخ
    var copyIcon = document.getElementById("copyIconEmail");
    copyIcon.style.color = "green";

    // إظهار رسالة النسخ وتحديث نصها
    var copyEmail = document.getElementById("copyEmail");
    copyEmail.style.display = "inline";
    copyEmail.textContent = "copied";

    // إعادة تعيين لون الأيقونة بعد فترة زمنية
    setTimeout(function () {
        copyIcon.style.color = "chocolate";
    }, 1000);

    // إخفاء رسالة النسخ بعد فترة زمنية
    setTimeout(function () {
        copyPhoneNumber.style.display = "none";
    }, 2000);
}
function copyUserName() {
    // احصل على نص User ID
    var UserNameText = document.getElementById("UserName").innerText;

    // إنشاء عنصر نص مؤقت للنسخ
    var tempInput = document.createElement("input");

    // قم بإعطاء العنصر النصي القيمة التي تم الحصول عليها
    tempInput.value = UserNameText;

    // إضافة العنصر النصي إلى الصفحة
    document.body.appendChild(tempInput);

    // تحديد نص العنصر النصي
    tempInput.select();

    // نسخ النص إلى الحافظة
    document.execCommand("copy");

    // إزالة العنصر النصي المؤقت
    document.body.removeChild(tempInput);

    // اختيار الأيقونة لتوضيح النسخ
    var copyIcon = document.getElementById("copyIconUserName");
    copyIcon.style.color = "green";

    // إظهار رسالة النسخ وتحديث نصها
    var copyUserName = document.getElementById("copyUserName");
    copyUserName.style.display = "inline";
    copyUserName.textContent = "copied";

    // إعادة تعيين لون الأيقونة بعد فترة زمنية
    setTimeout(function () {
        copyIcon.style.color = "chocolate";
    }, 1000);

    // إخفاء رسالة النسخ بعد فترة زمنية
    setTimeout(function () {
        copyPhoneNumber.style.display = "none";
    }, 2000);
}
function copyAddress() {
    // احصل على نص User ID
    var UserNameText = document.getElementById("Address").innerText;

    // إنشاء عنصر نص مؤقت للنسخ
    var tempInput = document.createElement("input");

    // قم بإعطاء العنصر النصي القيمة التي تم الحصول عليها
    tempInput.value = UserNameText;

    // إضافة العنصر النصي إلى الصفحة
    document.body.appendChild(tempInput);

    // تحديد نص العنصر النصي
    tempInput.select();

    // نسخ النص إلى الحافظة
    document.execCommand("copy");

    // إزالة العنصر النصي المؤقت
    document.body.removeChild(tempInput);

    // اختيار الأيقونة لتوضيح النسخ
    var copyIcon = document.getElementById("copyIconAddress");
    copyIcon.style.color = "green";

    // إظهار رسالة النسخ وتحديث نصها
    var copyUserName = document.getElementById("copyAddress");
    copyUserName.style.display = "inline";
    copyUserName.textContent = "copied";

    // إعادة تعيين لون الأيقونة بعد فترة زمنية
    setTimeout(function () {
        copyIcon.style.color = "chocolate";
    }, 1000);

    // إخفاء رسالة النسخ بعد فترة زمنية
    setTimeout(function () {
        copyPhoneNumber.style.display = "none";
    }, 2000);
}