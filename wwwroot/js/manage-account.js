// thay doi thong tin tai khoan
var button = document.querySelector("div.button__change-account");
button.addEventListener("click", function () {
    var modal = document.querySelector('div.modal__customer-update');
    modal.classList.add('open');
});
// end

// exit
var buttonExit = document.querySelector("div.button__exit");
buttonExit.addEventListener("click", function () {
    var modal = document.querySelector('div.modal__customer-update');
    modal.classList.remove('open');
});