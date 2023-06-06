// Lấy ra combobox quận và combobox phường
var districtSelect = document.getElementById("district");
var wardSelect = document.getElementById("ward");
var houseNumberInput = document.querySelector('input[name="HouseNumber"]');

// Lắng nghe sự kiện khi người dùng chọn một quận trong combobox quận
districtSelect.addEventListener("change", function() {
	// Lấy ra ID của quận được chọn
	var districtID = districtSelect.options[districtSelect.selectedIndex].getAttribute("data-id_district");
	houseNumberInput.value = null;
	// Lặp qua các tùy chọn phường trong combobox phường và ẩn đi những tùy chọn không thuộc quận được chọn
	for (var i = 0; i < wardSelect.options.length; i++)
	{
		if (wardSelect.options[i].getAttribute("data-district") == districtID)
		{
			wardSelect.options[i].style.display = "block";
		}
		else
		{
			wardSelect.options[i].style.display = "none";
		}
	}
	// Chọn sẵn phường đầu tiên trong combobox phường
	for (var i = 0; i < wardSelect.options.length; i++)
	{
		if (wardSelect.options[i].getAttribute("data-district") == districtID)
		{
			wardSelect.selectedIndex = i;
			break;
		}
	}
});

wardSelect.addEventListener("change", function () {
	// Đặt giá trị null cho thẻ input "HouseNumber"
	houseNumberInput.value = null;
});


// Kiểm tra số điện thoại
function validatePhoneNumber(input_str) {
	var re = /(0[3|5|7|8|9])+([0-9]{8})\b/;
	return re.test(input_str);
}
function validateFilled() {
	var name = document.querySelector("input[name='Name']");
	var adr = document.querySelector("input[name='HouseNumber']");
	if ((name.value = name.value.trim()) === "") return false;
	if ((adr.value = adr.value.trim()) === "") return false;
	return true;
}
function validateForm(event) {
	var phone = document.getElementById('phone_number').value;
	if (!validateFilled()) {
		document.querySelector('.submit-btn__payment').click;
	}
	else if (!validatePhoneNumber(phone)) {
		document.getElementById('phone_error').classList.remove('hidden');
		event.preventDefault();
	}
	else {
		document.getElementById('phone_error').classList.add('hidden');
		document.querySelector('.payment').submit();
	}
}

document.querySelector('.submit-btn__payment').addEventListener('click', validateForm);