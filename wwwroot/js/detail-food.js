/* for quantity button */
var plusButton = document.getElementsByClassName('plus-detail');
var minusButton = document.getElementsByClassName('minus-detail');
//Increase
var button_plus = plusButton[0];
button_plus.addEventListener('click', function handleClick(event) {
    var input = event.target.parentElement.children[1];
    var inputValue = input.value;
    var newValue = parseInt(inputValue) + 1;
    if (isNaN(newValue)) {
        newValue = 1;
    }
    input.value = newValue;
});
//Descrease
var button_minus = minusButton[0];
button_minus.addEventListener('click', function handleClick(event) {
    var input = event.target.parentElement.children[1];
    var inputValue = input.value;
    var newValue = parseInt(inputValue) - 1;
    if (isNaN(newValue) || newValue <= 0) {
        newValue = 1;
    }
    input.value = newValue;
});

/* for emphrase picture*/

var main_img = document.querySelector(".main-img img");
var more_img = document.querySelectorAll(".more-img img");
more_img.forEach(function (img) {
    img.addEventListener('click', function () {
        main_img.src = img.src
    });
});

var alert = document.querySelector(".alert-success");
var hideTimeout = setTimeout(function () {
    alert.classList.remove('show');
}, 3000);

var rating = document.querySelector('.stars-outer input').value;
const starPercentage = (rating / 5) * 100;
const starPercentageRounded = `${(Math.round(starPercentage / 10) * 10)}%`;
document.querySelector(`.stars-inner`).style.width = starPercentageRounded;