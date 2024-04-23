document.addEventListener("DOMContentLoaded", function () {
    const rowContainer = document.getElementById("rowContainer");
    const addRowBtn = document.getElementById("addRowBtn");

    addRowBtn.addEventListener("click", function () {
        const newRow = document.createElement("div");
        newRow.classList.add("row");
        newRow.style.marginLeft = "20px";

        newRow.innerHTML = `
                <div class="input-group mb-3">
                   
                         <input required pattern="^[0-9+]+$" type="number" class="form-control" placeholder="Truck space" aria-label="Space" aria-describedby="basic-addon2" style="border-top-left-radius: 17px; border-bottom-left-radius: 17px;border: none;">
                        <span class="input-group-text" id="basic-addon2">Ton</span>

                         <input required pattern="^[0-9+]+$" type="number" class="form-control" placeholder="Truck Type" aria-label="Space" aria-describedby="basic-addon2" style="border-top-left-radius: 17px; border-bottom-left-radius: 17px;border: none;">
                        <span class="input-group-text" id="basic-addon2">Type</span>

                         <input required pattern="^[0-9+]+$" type="number" class="form-control" placeholder="Cost" aria-label="Space" aria-describedby="basic-addon2" style="border-top-left-radius: 17px; border-bottom-left-radius: 17px;border: none;">
                        <span class="input-group-text" id="basic-addon2">SAR</span>
                                <button type="button" style=" color: white; border-radius:20px ; padding-left: 35px ; padding-right: 35px;" class="remove-btn location"><span>-</span></button>
                </div>
            `;

        rowContainer.appendChild(newRow);

        const removeBtn = newRow.querySelector(".remove-btn");
        removeBtn.addEventListener("click", function () {
            rowContainer.removeChild(newRow);
        });
    });
});