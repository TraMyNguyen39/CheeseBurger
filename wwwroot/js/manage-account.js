// thay doi thong tin tai khoan
var button = document.querySelector('button.btn-change-account');
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
	document.querySelector('#email-error').textContent = '';
	document.querySelector('#phone-error').textContent = '';
	document.querySelector('#housenumber-error').textContent = '';
	document.querySelector('#ward-error').textContent = '';
	document.querySelector('#district-error').textContent = '';
	document.querySelector('#name-error').textContent = '';
});