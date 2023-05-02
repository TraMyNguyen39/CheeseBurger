window.onload = function () {
	/// Thiết lập lại giá trị của selectSort và inputSearch
	const urlParams = new URLSearchParams(window.location.search);
	var selectedValue = urlParams.get('sortBy');
	if (selectedValue) {
		var selectElement = document.querySelector('.menu-sort .menu-sort-box');
		selectElement.value = selectedValue;
	}
	var searchInput = document.querySelector(".menu-search-box .search-box-input");
	searchInput.value = urlParams.get('search');

	/// Thiết lập active filter
	var filterCate = document.getElementsByClassName("category-filter-name");
	var element = document.getElementById("cate-" + urlParams.get("category"));
	//localStorage.removeItem("cate");
	if (element) {
		element.classList.add('active');
	}
	else {
		element = document.getElementById("cate-all");
		element.classList.add('active');
	}

	var filterPrice = document.getElementsByClassName("cost-filter-name");
	var element = document.getElementById("price-" + urlParams.get("price"));
	if (element) {
		element.classList.add('active');
	}
	else {
		element = document.getElementById("price-all");
		element.classList.add('active');
	}
};

// Thay đổi lựa chọn sắp xếp
document.querySelector('select').addEventListener('change', function () {
	document.querySelector('.menu-sort input[type="submit"]').click();

});

// active filter
var filterCate = document.getElementsByClassName("category-filter-name");
for (var i = 0; i < filterCate.length; i++) {
	filterCate[i].addEventListener('click', function () {
		var currentActive = document.querySelector('.category-filter-name.active');
		currentActive.className = currentActive.className.replace('active', '');
		this.classList.toggle("active");
		//localStorage.setItem("cate", this.id);
	});
}

var filterPrice = document.getElementsByClassName("cost-filter-name");
for (var i = 0; i < filterPrice.length; i++) {
	filterPrice[i].addEventListener('click', function () {
		var currentActive = document.querySelector('.cost-filter-name.active');
		currentActive.className = currentActive.className.replace('active', '');
		this.classList.toggle("active");
	});
}

/// Xoá đi các thẻ input rỗng cho search (thẻ đóng vai trò truyền url)
var form = document.querySelector(".menu-search-box");
var inputs = form.querySelectorAll("input.search-box-hidden");
var searchInput = form.querySelector(".search-box-input");
form.addEventListener("submit", function (event) {
	for (var i = 0; i < inputs.length; i++) {
		if (inputs[i].value === "") {
			inputs[i].name = ""; // Xoá name của input rỗng
			inputs[i].value = ""; // Xoá value của input rỗng
		}
	}
	// Gửi form
	form.submit();
});

/// Xoá đi các thẻ input rỗng cho sort (thẻ đóng vai trò truyền url)
var form = document.querySelector(".menu-sort");
var inputs = form.querySelectorAll("input");
form.addEventListener("submit", function (event) {
	event.preventDefault(); // ngăn chặn form gửi đi
	for (var i = 0; i < inputs.length; i++) {
		if (inputs[i].value.trim() === "") {
			inputs[i].name = ""; // Xoá name của input rỗng
			inputs[i].value = ""; // Xoá value của input rỗng
		}
	}
	// Gửi form nếu không có input rỗng
	form.submit();
});

var alert = document.querySelector(".alert-success");
var hideTimeout = setTimeout(function () {
	alert.classList.remove('show');
}, 3000);

// Ngoi sao
var list = document.querySelectorAll('.stars-outer input');
for (var i = 0; i < list.length; i++) {
	rating = list[i].value;
	const starPercentage = (rating / 5) * 100;
	const starPercentageRounded = `${(Math.round(starPercentage / 10) * 10)}%`;
	list[i].parentElement.children[0].style.width = starPercentageRounded;
}
