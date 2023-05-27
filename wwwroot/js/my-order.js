window.onload = function () {
	const urlParams = new URLSearchParams(window.location.search);
	var filter = document.getElementsByClassName("body__side-bar-item-or");
	var element = document.getElementById("status-" + urlParams.get("status"));
	//localStorage.removeItem("cate");
	if (element) {
		element.classList.add('active');
	}
	else {
		element = document.getElementById("status-all");
		element.classList.add('active');
	}
};
