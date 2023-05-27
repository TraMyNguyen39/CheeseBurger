/* for quantity button */
var plusButton = document.getElementsByClassName('plus-detail');
var minusButton = document.getElementsByClassName('minus-detail');
var maxQty = document.getElementById('maxQty').value;
var message = document.getElementById('error-message');
//Increase
var button_plus = plusButton[0];
button_plus.addEventListener('click', function handleClick(event) {
    var input = event.target.parentElement.children[1];
    var inputValue = input.value;
    var newValue = parseInt(inputValue) + 1;
    if (isNaN(newValue)) {
        newValue = 1;
    }
    if (newValue > maxQty) {
        newValue = maxQty;
        message.innerHTML = 'Món ăn chỉ còn ' + maxQty + ' sản phẩm';
    }
    else
        message.innerHTML = '';
    input.value = newValue;
});
//Descrease
var button_minus = minusButton[0];
button_minus.addEventListener('click', function handleClick(event) {
    var input = event.target.parentElement.children[1];
    var inputValue = input.value;
    var newValue = parseInt(inputValue) - 1;
    if (isNaN(newValue) || newValue < 1) {
        newValue = 1;
    }
    message.innerHTML = '';
    input.value = newValue;
});
// input change
var inputs = document.getElementById("quantity");
inputs.addEventListener("input", validateInput);
function validateInput(event) {
    var input = event.target.value;
    var regex = /^\d+$/;

    if (!regex.test(input)) {
        event.target.value = "1";
    }
    if (parseInt(input) > parseInt(maxQty)) {
        event.target.value = maxQty;
        message.innerHTML = 'Món ăn chỉ còn ' + maxQty + ' sản phẩm';
    }
    else {
        message.innerHTML = '';
    }
    if (parseInt(input) === 0) {
        event.target.value = 1;
    }
}

//// submit
//var submitBtn = document.querySelector('#submit-btn');
//submitBtn.addEventListener('click', function () {
//    alert(maxQty); alert(inputs.value);
//    if (parseInt(inputs.value) > parseInt(maxQty) || parseInt(inputs.values) < 1)
//        event.preventDefault();
//    event.preventDefault();
//})

/* for emphrase picture*/

var main_img = document.querySelector(".main-img img");
var more_img = document.querySelectorAll(".more-img img");
more_img.forEach(function (img) {
    img.addEventListener('click', function () {
        main_img.src = img.src
    });
});

var alert = document.querySelector(".alert-dismissible");
var hideTimeout = setTimeout(function () {
    alert.classList.remove('show');
}, 3000);

var rating = document.querySelector('.stars-outer input').value;
const starPercentage = (rating / 5) * 100;
const starPercentageRounded = `${(Math.round(starPercentage / 10) * 10)}%`;
document.querySelector(`.stars-inner`).style.width = starPercentageRounded;

// unactive
var hethangbtns = document.querySelectorAll('.grey-btn');
for (var i = 0; i < hethangbtns.length; i++) {
    hethangbtns[i].addEventListener('click', function () {
        event.preventDefault();
    });
}