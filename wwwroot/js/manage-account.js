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
});

// validate thong tin
const usernameEle = document.getElementById('namesta');
const emailEle = document.getElementById('email');
const phoneEle = document.getElementById('phone');
const housenumEle = document.getElementById('housenumber');

const btnRegister = document.getElementById('btn-register');
const inputEles = document.querySelectorAll('.item-line');

btnRegister.addEventListener('click', function () {
    Array.from(inputEles).map((ele) =>
        ele.classList.remove('success', 'error')
    );
    let isValid = checkValidate();

    if (isValid) {
        alert('Cập nhật thành công');
    }
});

function checkValidate() {
    let usernameValue = usernameEle.value;
    let emailValue = emailEle.value;
    let phoneValue = phoneEle.value;
    let housenumValue = housenumEle.value;

    let isCheck = true;

    if (usernameValue == '') {
        setError(usernameEle, 'Tên không được để trống');
        isCheck = false;
    } else {
        setSuccess(usernameEle);
    }

    if (emailValue == '') {
        setError(emailEle, 'Email không được để trống');
        isCheck = false;
    } else if (!isEmail(emailValue)) {
        setError(emailEle, 'Email không đúng định dạng');
        isCheck = false;
    } else {
        setSuccess(emailEle);
    }

    if (phoneValue == '') {
        setError(phoneEle, 'Số điện thoại không được để trống');
        isCheck = false;
    } else if (!isPhone(phoneValue)) {
        setError(phoneEle, 'Số điện thoại không đúng định dạng');
        isCheck = false;
    } else {
        setSuccess(phoneEle);
    }

    if (housenumValue == '') {
        setError(housenumEle, 'Số nhà không được để trống');
        isCheck = false;
    } else {
        setSuccess(housenumEle);
    }

    return isCheck;
}

function setSuccess(ele) {
    ele.parentNode.classList.add('success');
}

function setError(ele, message) {
    let parentEle = ele.parentNode;
    parentEle.classList.add('error');
    parentEle.querySelector('small').innerText = message;
}

function isEmail(email) {
    return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(
        email
    );
}

function isPhone(number) {
    return /(84|0[3|5|7|8|9])+([0-9]{8})\b/.test(number);
}
// end