window.onload = function () {
    const urlParams = new URLSearchParams(window.location.search);
    var selectedValueSort = urlParams.get('sortBy');
    if (selectedValueSort) {
        var selectElementSort = document.querySelector(".menu-sort-staff .menu-sort-staff-box");
        selectElementSort.value = selectedValueSort;
    }
    var selectedValueRole = urlParams.get('roleBy');
    if (selectedValueRole) {
        var selectElementRole = document.querySelector(".menu-sort-staff-role .menu-sort-staff-role-box");
        selectElementRole.value = selectedValueRole;
    }
    var searchInput = document.querySelector(".input-wrapper .form-control");
    searchInput.value = urlParams.get('search');
};

document.querySelector('#sort-select').addEventListener('change', function () {
    document.querySelector('.menu-sort-staff input[type="submit"]').click();
});

document.querySelector('#role-select').addEventListener('change', function () {
    document.querySelector('.menu-sort-staff-role input[type="submit"]').click();
});

var form = document.querySelector(".form-inline.my-2.my-lg-0");
var inputs = form.querySelectorAll("input.search-staff-box-hidden");
var searchInput = form.querySelector(".form-control");
form.addEventListener("submit", function (event) {
    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].value === "") {
            inputs[i].name = "";
            inputs[i].value = "";
        }
    }
    form.submit();
});

var form = document.querySelector(".menu-sort-staff");
var inputs = form.querySelectorAll("input");
form.addEventListener("submit", function (event) {
    //event.preventDefault();
    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].value.trim() === "") {
            inputs[i].name = "";
            inputs[i].value = "";
        }
    }
    form.submit();
});

var form = document.querySelector(".menu-sort-staff-role");
var inputs = form.querySelectorAll("input");
form.addEventListener("submit", function (event) {
    //event.preventDefault();
    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].value.trim() === "") {
            inputs[i].name = "";
            inputs[i].value = "";
        }
    }
    form.submit();
});

// them mon an
var button = document.querySelector("div.button__add");
button.addEventListener("click", function () {
    var modal = document.querySelector('.modal__food-add');
    modal.classList.add('open');
});
// end

// Xem mon an
var eyeButtons = document.querySelectorAll(".fa-eye");

for (var i = 0; i < eyeButtons.length; i++) {
    eyeButtons[i].addEventListener("click", function () {
        var modal = document.querySelector(".modal__food-read");
        modal.classList.add("open");
    });
}
// End

// Cap nhat mon an
var pencilButtons = document.querySelectorAll(".fa-pencil-alt");

for (var i = 0; i < pencilButtons.length; i++) {
    pencilButtons[i].addEventListener("click", function () {
        var modal = document.querySelector(".modal__ingredient-modify");
        modal.classList.add("open");
    });
}
// End

// Exit
var buttonExit = document.querySelectorAll("div.button__exit");

function handleCloseModal() {
    var modal = this.parentNode.parentNode;
    modal.classList.remove("open");
}

for (var i = 0; i < buttonExit.length; i++) {
    buttonExit[i].addEventListener("click", handleCloseModal);
}

//OK
var buttonOK = document.querySelectorAll("button.exit-btn");

function handleOKModal() {
    var modal = this.parentNode.parentNode.parentNode.parentNode;
    modal.classList.remove("open");
}
for (var i = 0; i < buttonOK.length; i++) {
    buttonOK[i].addEventListener("click", handleOKModal);
}

