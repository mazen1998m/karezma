//const dropdown = document.getElementById('permission');
//const checkboxContainer = document.getElementById('checkboxContainer');

//Permission.forEach(d => {
//    const checkboxLabel = document.createElement('label');
//    checkboxLabel.innerHTML = `
//                 <div style="border-radius:17px;border:none;width:700px;"><input type="checkbox" name="PermissionIds" value="${d.id}"/> ${d.name}</div>
//                            `;
//    checkboxContainer.appendChild(checkboxLabel);
//});

//checkboxContainer.addEventListener('change', function () {
//    const selectedOptions = Array.from(checkboxContainer.querySelectorAll('input:checked')).map(input => input.value);
//    dropdown.value = selectedOptions.join(',');
//    document.getElementById('SelectedPermissions').value = selectedOptions.join(',');
//});

//dropdown.addEventListener('click', function () {
//    checkboxContainer.style.display = checkboxContainer.style.display === 'none' ? 'block' : 'none';
//});
//------------------------------------------------------------------------
//var type = "";
//if (user.userType == 0) {
//    type = "Customer";
//} else if (user.userType == 1) {
//    type = "Admin"
//}
//else if (user.userType == 2) {
//    type = "Employee"
//}
//const dropdown2 = document.getElementById('userId');
//const checkboxContainer2 = document.getElementById('checkboxContainer2');

//user.forEach(d => {
//    if (d.userType == 0) {
//        type = "Customer";
//    } else if (d.userType == 1) {
//        type = "Admin"
//    }
//    else if (d.userType == 2) {
//        type = "Employee"
//    }
//    const checkboxLabel2 = document.createElement('label');
//    checkboxLabel2.innerHTML = `
//                              <div style="border-radius: 17px; border: none; width: 700px;"><input type="checkbox" name="UserIds" value="${d.id}" /> ${d.name}/${type}</div>
//                                `;
//    checkboxContainer2.appendChild(checkboxLabel2);
//});

//checkboxContainer2.addEventListener('change', function () {
//    const selectedOptions = Array.from(checkboxContainer2.querySelectorAll('input:checked')).map(input => input.value);
//    dropdown2.value = selectedOptions.join(',');
//    document.getElementById('SelectedUsers').value = selectedOptions.join(',');
//});

//dropdown2.addEventListener('click', function () {
//    checkboxContainer2.style.display = checkboxContainer2.style.display === 'none' ? 'block' : 'none';
//});