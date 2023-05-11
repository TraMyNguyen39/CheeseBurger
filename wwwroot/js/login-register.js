﻿var x = document.getElementById("login");
var y = document.getElementById("register");
var z = document.getElementById("switch-btn");

function register() {
    x.style.left = "-400px";
    y.style.left = "50px";
    z.style.left = "50%"
}
function login() {
    x.style.left = "50px";
    y.style.left = "450px";
    z.style.left = "0"
}

window.onload = function () {
	document.querySelector('#error').textContent = '';	
    const urlParams = new URLSearchParams(window.location.search);
    var status = urlParams.get('status').toLowerCase();
    if (status == "register") {
        document.getElementById('register-state').click();
    }
    else {
        document.getElementById('login-state').click();
    }
};

function validateFilledName() {
	var name = document.querySelector("input[name='name']");
	if ((name.value = name.value.trim()) === "") return false;
	return true;
}

function validateFilledEmail() {
	var name = document.querySelector("input[name='email']");
	if ((name.value = name.value.trim()) === "") return false;
	return true;
}

function validateFilledPhone() {
	var name = document.querySelector("input[name='phone']");
	if ((name.value = name.value.trim()) === "") return false;
	return true;
}

function validateFilledNewPass() {
	var name = document.querySelector("input[name='pass']");
	if ((name.value = name.value.trim()) === "") return false;
	return true;
}

function checkValidate() {
	var emailEle = document.getElementById('emaill');
	var phoneEle = document.getElementById('phonee');
	var passEle = document.getElementById('passs');

	let emailValue = emailEle.value;
	let phoneValue = phoneEle.value;
	let passValue = passEle.value;
	
	let isCheck = true;

	if (!validateFilledName()) {
		document.querySelector('#error').textContent = '* Vui lòng nhập họ tên !';
		isCheck = false;
		return isCheck;
	} else {
		document.querySelector('#error').textContent = '';
	}

	if (!validateFilledEmail()) {
		document.querySelector('#error').textContent = '* Vui lòng nhập email!';
		isCheck = false;
		return isCheck;
	}
	else if (!isEmail(emailValue)) {
		document.querySelector('#error').textContent = '* Email bị sai định dạng !';
		isCheck = false;
		return isCheck;
	} else {
		var newEmail = emailValue.trim();
		var listEmails = [];
		var smElements = document.querySelectorAll('small.Ten_Email_All');
		for (var i = 0; i < smElements.length; i++) {
			var _Email = smElements[i].textContent.trim();
			listEmails.push(_Email);
		}
		if (listEmails.some(function (name) { return name === newEmail })) {
			document.querySelector('#error').textContent = '* Email đã bị trùng !';
			isCheck = false;
			return isCheck;
		} else {
			document.querySelector('#error').textContent = '';
		}
	}

	if (!validateFilledPhone()) {
		document.querySelector('#error').textContent = '* Vui lòng nhập số điện thoại !';
		isCheck = false;
		return isCheck;
	}
	else if (!isPhone(phoneValue)) {
		document.querySelector('#error').textContent = '* Số điện thoại bị sai định dạng !';
		isCheck = false;
		return isCheck;
	} else {
		var newPhone = phoneValue.trim();
		var listPhones = [];
		var smElements = document.querySelectorAll('small.Phone_All');
		for (var i = 0; i < smElements.length; i++) {
			var _Phones = smElements[i].textContent.trim();
			listPhones.push(_Phones);
		}
		if (listPhones.some(function (name) { return name === newPhone })) {
			document.querySelector('#error').textContent = '* Số điện thoại đã bị trùng !';
			isCheck = false;
			return isCheck;
		} else {
			document.querySelector('#error').textContent = '';
		}
	}

	if (!validateFilledNewPass()) {
		document.querySelector('#error').textContent = '* Vui lòng nhập mật khẩu!';
		isCheck = false;
		return isCheck;
	} else if (!isPass(passValue)) {
		document.querySelector('#error').textContent = '* Mật khẩu phải từ 8 đến 15 ký tự với ít nhất 1 chữ cái thường, 1 chữ cái in hoa, 1 chữ số và 1 ký tự đặc biệt!';
		isCheck = false;
		return isCheck;
	} else {
		document.querySelector('#error').textContent = '';
	}

	return isCheck;
}

function validateForm(event) {
	let isValid = checkValidate();
	if (isValid) {
		document.querySelector('.RegisterAcc').submit();
	}
	else {
		event.preventDefault();
	}
}

document.querySelector('.submit-btn-register').addEventListener('click', validateForm);

function isEmail(email) {
    return /^[a -z0-9](\.?[a-z0-9]){4,}@gmail\.com$/.test(email);
}

function isPhone(number) {
    return /(0[3|5|7|8|9])+([0-9]{8})\b/.test(number);
}

function isPass(pass) {
	return /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$/.test(pass);
}