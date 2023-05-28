window.onload = function () {
	document.querySelector('#forget_pass_error').textContent = '';
}

// validate thong tin

function validateFilledEmail() {
	var name = document.querySelector("input[name='email']");
	if ((name.value = name.value.trim()) === "") return false;
	return true;
}

function checkValidate() {
	var emailEle = document.getElementById('emaill');
	let emailValue = emailEle.value;
	let isCheck = true;
	if (!validateFilledEmail()) {
		document.querySelector('#forget_pass_error').textContent = '* Vui lòng nhập email!';
		isCheck = false;
		return isCheck;
	}
	else if (!isEmail(emailValue)) {
		document.querySelector('#forget_pass_error').textContent = '* Email bị sai định dạng !';
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
			document.querySelector('#forget_pass_error').textContent = '';
			isCheck = true;
			return isCheck;
		} else {
			document.querySelector('#forget_pass_error').textContent = '* Email chưa được đăng ký!';
			isCheck = false;
			return isCheck;
		}
	}
}

function validateForm(event) {
	let isValid = checkValidate();
	if (isValid) {
		var email = document.getElementById("emaill").value;
		var url = 'https://localhost:44344/Login/SuccessfulValidate1';
		var form = document.createElement("form");
		form.action = url;
		form.method = "POST";

		var emailInput = document.createElement("input");
		emailInput.type = "text";
		emailInput.name = "email";
		emailInput.value = email;
		form.appendChild(emailInput);

		document.body.appendChild(form);
		form.submit();
	}
	else {
		event.preventDefault();
	}
}

document.querySelector('.btn-send-mail').addEventListener('click', validateForm);

function isEmail(email) {
	return /^[a -z0-9](\.?[a-z0-9]){4,}@gmail\.com$/.test(email);
}