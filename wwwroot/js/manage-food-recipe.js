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

