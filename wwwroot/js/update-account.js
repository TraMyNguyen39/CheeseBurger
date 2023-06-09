window.onload = function () {
	document.querySelector('#email-error').textContent = '';
	document.querySelector('#phone-error').textContent = '';
	document.querySelector('#housenumber-error').textContent = '';
	document.querySelector('#ward-error').textContent = '';
	document.querySelector('#district-error').textContent = '';
	document.querySelector('#name-error').textContent = '';
}

// Lấy ra combobox quận và combobox phường
var districtSelect = document.getElementById("district");
var wardSelect = document.getElementById("ward");

// Lắng nghe sự kiện khi người dùng chọn một quận trong combobox quận
districtSelect.addEventListener("change", function() {
	// Lấy ra ID của quận được chọn
	var districtID = districtSelect.options[districtSelect.selectedIndex].getAttribute("data-id_district");

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
	document.getElementById("housenumber").value = "";
	wardSelect.selectedIndex = 0;
	var wardIDHidden = document.querySelector('input[name="wardId"]');
	var wardID = wardSelect.value;
	wardIDHidden.value = wardID;
});

wardSelect.addEventListener("change", function () {
	var wardIDHidden = document.querySelector('input[name="wardId"]');
	document.getElementById("housenumber").value = "";
	var wardID = wardSelect.value;
	wardIDHidden.value = wardID;
});