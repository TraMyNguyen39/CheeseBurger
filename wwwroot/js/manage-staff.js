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
    var searchInput = document.querySelector(".menu-search-staff-box .search-staff-box-input");
    searchInput.value = urlParams.get('search');
};

document.querySelector('#sort-select').addEventListener('change', function () {
    document.querySelector('.menu-sort-staff input[type="submit"]').click();
});

document.querySelector('#role-select').addEventListener('change', function () {
    document.querySelector('.menu-sort-staff-role input[type="submit"]').click();
});

var form = document.querySelector(".menu-search-staff-box");
var inputs = form.querySelectorAll("input.search-staff-box-hidden");
var searchInput = form.querySelector(".search-staff-box-input");
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

var selectElement = document.getElementById("sort-select");
var urlParams = new URLSearchParams(window.location.search);
var submittedValue = urlParams.get('sortBy');

// If the submitted value exists, loop through the options and set the selected option
if (submittedValue) {
    for (var i = 0; i < selectElement.options.length; i++) {
        var option = selectElement.options[i];
        if (option.value === submittedValue) {
            option.selected = true;
            break;
        }
    }
}

var selectElement1 = document.getElementById("role-select");
var urlParams1 = new URLSearchParams(window.location.search);
var submittedValue1 = urlParams.get('roleBy');

// If the submitted value exists, loop through the options and set the selected option
if (submittedValue1) {
    for (var i = 0; i < selectElement1.options.length; i++) {
        var option1 = selectElement1.options[i];
        if (option1.value === submittedValue1) {
            option1.selected = true;
            break;
        }
    }
}

// thay doi thong tin tai khoan
var eyeButtons = document.querySelectorAll(".fa-eye");

for (var i = 0; i < eyeButtons.length; i++) {
  eyeButtons[i].addEventListener("click", function() {
    var modal = document.querySelector(".modal__info-full");
    modal.classList.add("open");
  });
}
// end

// Xem
var pencilButtons = document.querySelectorAll(".fa-pencil-alt");

for (var i = 0; i < pencilButtons.length; i++) {
  pencilButtons[i].addEventListener("click", function() {
    var modal = document.querySelector(".modal__account-update");
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

// OK
var buttonOK = document.querySelectorAll("button.exit-btn");

function handleOKModal() {
    var modal = this.parentNode.parentNode.parentNode;
    modal.classList.remove("open");
}
for (var i = 0; i < buttonOK.length; i++) {
    buttonOK[i].addEventListener("click", handleOKModal);
}

// Xoa
//var banButtons = document.querySelectorAll("td.Option__ban");

//for (var i = 0; i < banButtons.length; i++) {
//    banButtons[i].addEventListener("click", function () {
//        let text = "Bạn có chắc chắn muốn xoá người dùng này không?";
//        if (confirm(text) == true) {
            
//        } else {
            
//        }
//    });
//}
