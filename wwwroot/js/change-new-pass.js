window.onload = function () {
	document.querySelector('#error').textContent = '';	
}

// validate thong tin
function validateFilledNewPass() {
	var name = document.querySelector("input[name='newpass']");
	if ((name.value = name.value.trim()) === "") return false;
	return true;
}

function validateFilledConfirmPass() {
	var name = document.querySelector("input[name='confirmpass']");
	if ((name.value = name.value.trim()) === "") return false;
	return true;
}

function checkValidate() {		
	var newPassEle = document.getElementById('newpasss');
	var confirmPassEle = document.getElementById('confirmpasss');	

	let newPassValue = newPassEle.value;
	let confirmPassValue = confirmPassEle.value;
	
	let isCheck = true;
	
	if (!validateFilledNewPass()) {
		document.querySelector('#error').textContent = '* Vui lòng nhập mật khẩu mới !';
		isCheck = false;
		return isCheck;
	} else {				
		if (!isPass(newPassValue)) {
			document.querySelector('#error').textContent = '* Mật khẩu phải từ 8 đến 15 ký tự với ít nhất 1 chữ cái thường, 1 chữ cái in hoa, 1 chữ số và 1 ký tự đặc biệt!';
			isCheck = false;
			return isCheck;
		} else {
			document.querySelector('#error').textContent = '';			
			if (!validateFilledConfirmPass()) {
				document.querySelector('#error').textContent = '* Vui lòng nhập lại mật khẩu mới';
				isCheck = false;
				return isCheck;
			} else if (newPassValue !== confirmPassValue) {
				document.querySelector('#error').textContent = '* Không khớp với mật khẩu mới. Vui lòng nhập lại !';
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
		document.querySelector('ChangeNewPass').submit();
	}
	else {
		event.preventDefault();
	}	
}

document.querySelector('.btn-confirm-change-pass').addEventListener('click', validateForm);

function isPass(pass) {
	return /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$/.test(pass);
}