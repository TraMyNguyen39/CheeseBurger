window.onload = function () {
    document.querySelector('#match_pass_error').textContent = '';
    document.querySelector('#invalid_pass_error').textContent = '';
    document.querySelector('#duplicate_pass_error').textContent = '';
}

// validate thong tin

function validateFilledOldPass() {
    var name = document.querySelector("input[name='oldPassword']");
    if ((name.value = name.value.trim()) === "") return false;
    return true;
}

function validateFilledNewPass() {
    var name = document.querySelector("input[name='newPassword']");
    if ((name.value = name.value.trim()) === "") return false;
    return true;
}

function validateFilledConfirmPass() {
    var name = document.querySelector("input[name='confirmPassword']");
    if ((name.value = name.value.trim()) === "") return false;
    return true;
}

function checkValidate() {
    var oldPassEle = document.getElementById('old_password');
    var newPassEle = document.getElementById('new_password');
    var confirmPassEle = document.getElementById('confirm_password');

    let oldPassValue = oldPassEle.value;
    let newPassValue = newPassEle.value;
    let confirmPassValue = confirmPassEle.value;

    let isCheck = true;

    if (!validateFilledOldPass()) {
        document.querySelector('#match_pass_error').textContent = '* Vui lòng nhập mật khẩu cũ !';
        document.querySelector('#invalid_pass_error').textContent = '';
        document.querySelector('#duplicate_pass_error').textContent = '';
        isCheck = false;
    } else {
        var curPass = oldPassValue.trim();
        var smElements = document.querySelector('small.Current_Password');
        var _Pass = smElements.textContent.trim();
        var bcrypt = dcodeIO.bcrypt; console.log(curPass); console.log(_Pass);
        var isPasswordCorrect = bcrypt.compareSync(curPass, _Pass);
        if (!isPasswordCorrect) {
            document.querySelector('#match_pass_error').textContent = '* Mật khẩu không khớp. Vui lòng nhập lại !';
            document.querySelector('#invalid_pass_error').textContent = '';
            document.querySelector('#duplicate_pass_error').textContent = '';
            isCheck = false;
        } else {
            document.querySelector('#match_pass_error').textContent = '';
            document.querySelector('#duplicate_pass_error').textContent = '';
            if (!validateFilledNewPass()) {
                document.querySelector('#invalid_pass_error').textContent = '* Vui lòng nhập mật khẩu mới !';
                isCheck = false;
            } else {
                if (!isPass(newPassValue)) {
                    document.querySelector('#invalid_pass_error').textContent = '* Mật khẩu phải từ 8 đến 15 ký tự với ít nhất 1 chữ cái thường, 1 chữ cái in hoa, 1 chữ số và 1 ký tự đặc biệt!';
                    isCheck = false;
                } else {
                    document.querySelector('#match_pass_error').textContent = '';
                    document.querySelector('#invalid_pass_error').textContent = '';
                    document.querySelector('#duplicate_pass_error').textContent = '';
                    if (!validateFilledConfirmPass()) {
                        document.querySelector('#duplicate_pass_error').textContent = '* Vui lòng nhập lại mật khẩu mới';
                        isCheck = false;
                    } else if (newPassValue !== confirmPassValue) {
                        document.querySelector('#duplicate_pass_error').textContent = '* Không khớp với mật khẩu mới. Vui lòng nhập lại !';
                        isCheck = false;
                    }
                }
            }
        }
    }

    return isCheck;
}

function validateForm(event) {
    let isValid = checkValidate();
    if (isValid) {
        document.querySelector('.ChangePassword').submit();
    }
    else {
        event.preventDefault();
    }
}

document.querySelector('.button__customer-save').addEventListener('click', validateForm);

function isPass(pass) {
    return /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$/.test(pass);
}