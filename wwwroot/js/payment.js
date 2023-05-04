﻿// Lấy ra combobox quận và combobox phường
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