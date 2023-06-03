var x = document.getElementById("login");
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

function validateFilledConfirmPass() {
	var name = document.querySelector("input[name='confirmpassRG']");
	if ((name.value = name.value.trim()) === "") return false;
	return true;
}

function checkValidate() {
	var emailEle = document.getElementById('emaill');
	var phoneEle = document.getElementById('phonee');
	var passEle = document.getElementById('passs');
	var confirmpassEle = document.getElementById('confirmpasssRG');

	let emailValue = emailEle.value;
	let phoneValue = phoneEle.value;
	let passValue = passEle.value;
	let confirmpassValue = confirmpassEle.value;
	
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
		document.querySelector('#error').textContent = '* Vui lòng nhập mật khẩu !';
		isCheck = false;
		return isCheck;
	} else {
		if (!isPass(passValue)) {
			document.querySelector('#error').textContent = '* Mật khẩu phải từ 8 đến 15 ký tự với ít nhất 1 chữ cái thường, 1 chữ cái in hoa, 1 chữ số và 1 ký tự đặc biệt !';
			isCheck = false;
			return isCheck;
		} else {
			document.querySelector('#error').textContent = '';
			if (!validateFilledConfirmPass()) {
				document.querySelector('#error').textContent = '* Vui lòng xác nhận lại mật khẩu !';
				isCheck = false;
				return isCheck;
			} else if (passValue !== confirmpassValue) {
				document.querySelector('#error').textContent = '* Không khớp với mật khẩu. Vui lòng nhập lại !';
				isCheck = false;
				return isCheck;
			}
		}
	}
	
	return isCheck;
}

function validateForm(event) {
	let isValid = checkValidate();
	if (isValid) {
		
		event.preventDefault();
		// Lấy các giá trị từ input fields
		var email = document.getElementById("emaill").value;
		var name = document.getElementById("namee").value;
		var phone = document.getElementById("phonee").value;
		var pass = document.getElementById("passs").value;

		// Tạo form ẩn
		var hiddenForm = document.createElement("form");
		hiddenForm.setAttribute("method", "post");
		hiddenForm.setAttribute("action", "https://localhost:44344/Login/SendMailIden");

		// Tạo input fields ẩn và gắn các giá trị
		var emailInput = document.createElement("input");
		emailInput.setAttribute("type", "hidden");
		emailInput.setAttribute("name", "email");
		emailInput.setAttribute("value", email);
		hiddenForm.appendChild(emailInput);

		var nameInput = document.createElement("input");
		nameInput.setAttribute("type", "hidden");
		nameInput.setAttribute("name", "name");
		nameInput.setAttribute("value", name);
		hiddenForm.appendChild(nameInput);

		var phoneInput = document.createElement("input");
		phoneInput.setAttribute("type", "hidden");
		phoneInput.setAttribute("name", "phone");
		phoneInput.setAttribute("value", phone);
		hiddenForm.appendChild(phoneInput);

		var passInput = document.createElement("input");
		passInput.setAttribute("type", "hidden");
		passInput.setAttribute("name", "pass");
		passInput.setAttribute("value", pass);
		hiddenForm.appendChild(passInput);

		// Thêm form ẩn vào body của document
		document.body.appendChild(hiddenForm);

		// Submit form ẩn
		hiddenForm.submit();
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