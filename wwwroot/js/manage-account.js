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

// validate thong tin

function validateFilledName() {
	var name = document.querySelector("input[name='Name']");	
	if ((name.value = name.value.trim()) === "") return false;	
	return true;
}

function validateFilledEmail() {
	var name = document.querySelector("input[name='Email']");
	if ((name.value = name.value.trim()) === "") return false;
	return true;
}

function validateFilledPhone() {
	var name = document.querySelector("input[name='Phone']");
	if ((name.value = name.value.trim()) === "") return false;
	return true;
}

function checkValidate() {	
	var emailEle = document.getElementById('email');
	var phoneEle = document.getElementById('phone');
	var housenumEle = document.getElementById('housenumber');
	var wardEle = document.getElementById('ward');
	var districtEle = document.getElementById('district');

	let emailValue = emailEle.value;
	let phoneValue = phoneEle.value;
	let housenumValue = housenumEle.value;
	let wardValue = wardEle.value;
	let districtValue = districtEle.value;

	let isCheck = true;

	if (!validateFilledName()) {
		document.querySelector('#name-error').textContent = '* Vui lòng nhập họ tên !';
		isCheck = false;
	} else {
		document.querySelector('#name-error').textContent = '';
	}

	if (!validateFilledEmail()) {
		document.querySelector('#email-error').textContent = '* Vui lòng nhập email!';
		isCheck = false;
	}
	else if (!isEmail(emailValue)) {
		document.querySelector('#email-error').textContent = '* Email bị sai định dạng !';
		isCheck = false;
	} else {
		var newEmail = emailValue.trim();
		var listEmails = [];
		var smElements = document.querySelectorAll('small.Ten_Email_All');
		for (var i = 0; i < smElements.length; i++) {
			var _Email = smElements[i].textContent.trim();
			listEmails.push(_Email);
		}
		if (listEmails.some(function (name) { return name === newEmail })) {
			document.querySelector('#email-error').textContent = '* Email đã bị trùng !';
			isCheck = false;
		} else {
			document.querySelector('#email-error').textContent = '';			
		}
	}

	if (!validateFilledPhone()) {
		document.querySelector('#phone-error').textContent = '* Vui lòng nhập số điện thoại !';
		isCheck = false;
	}
	else if (!isPhone(phoneValue)) {
		document.querySelector('#phone-error').textContent = '* Số điện thoại bị sai định dạng !';
		isCheck = false;
	} else {
		var newPhone = phoneValue.trim();
		var listPhones = [];
		var smElements = document.querySelectorAll('small.Phone_All');
		for (var i = 0; i < smElements.length; i++) {
			var _Phones = smElements[i].textContent.trim();
			listPhones.push(_Phones);
		}		
		if (listPhones.some(function (name) { return name === newPhone })) {
			document.querySelector('#phone-error').textContent = '* Số điện thoại đã bị trùng !';
			isCheck = false;
		} else {
			document.querySelector('#phone-error').textContent = '';
		}
	}

	if (housenumValue.trim() === "") {
		if (districtValue != 0) {
			if (wardValue == 0) {
				document.querySelector('#district-error').textContent = '';	
				document.querySelector('#housenumber-error').textContent = '* Vui lòng nhập số nhà !';
				document.querySelector('#ward-error').textContent = '* Vui lòng chọn phường (xã) !';
				isCheck = false;
			} else {
				document.querySelector('#housenumber-error').textContent = '* Vui lòng nhập số nhà !';
				document.querySelector('#ward-error').textContent = '';
				document.querySelector('#district-error').textContent = '';	
				isCheck = false;
			}
		} else {
			document.querySelector('#housenumber-error').textContent = '';
			document.querySelector('#ward-error').textContent = '';
			document.querySelector('#district-error').textContent = '';	
		}
	} else {
		if (districtValue == 0) {
			document.querySelector('#district-error').textContent = '* Vui lòng chọn quận (huyện) !';
			document.querySelector('#ward-error').textContent = '* Vui lòng chọn phường (xã) !';
			document.querySelector('#housenumber-error').textContent = '';
			isCheck = false;
		} else if (wardValue == 0) {
			document.querySelector('#district-error').textContent = '';
			document.querySelector('#housenumber-error').textContent = '';
			document.querySelector('#ward-error').textContent = '* Vui lòng chọn phường (xã) !';
			isCheck = false;
		}
		else {
			document.querySelector('#district-error').textContent = '';			
			document.querySelector('#housenumber-error').textContent = '';
			document.querySelector('#ward-error').textContent = '';
		}
	}

	return isCheck;
}

function validateForm(event) {	
	let isValid = checkValidate();
	if (isValid) {
		document.querySelector('.UpdateAccount').submit();
	}
	else {
		event.preventDefault();
	}	
}

document.querySelector('.button__save-change').addEventListener('click', validateForm);

//function isEmail(email) {
//    return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(
//        email
//    );
//}

function isEmail(email) {
	return /^[a -z0-9](\.?[a-z0-9]){4,}@gmail\.com$/.test(email);
}

function isPhone(number) {
    return /(0[3|5|7|8|9])+([0-9]{8})\b/.test(number);
}