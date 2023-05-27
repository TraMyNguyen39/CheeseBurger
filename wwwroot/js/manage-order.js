//const statusDetails = document.querySelectorAll('.main__status-details');

//statusDetails.forEach(function (detail) {
//    detail.addEventListener('click', function () {
//        // Remove active class from previously active li element
//        const currentActive = document.querySelector('.main__status-details.active');
//        currentActive.classList.remove('active');

//        // Add active class to the clicked li element
//        this.classList.add('active');
//    });
//});

window.onload = function () {
	const urlParams = new URLSearchParams(window.location.search);
	var filter = document.getElementsByClassName("main__status-details");
	var element = document.getElementById("status-" + urlParams.get("status"));
	//localStorage.removeItem("cate");
	if (element) {
		element.parentElement.classList.add('active');
	}
	else {
		element = document.getElementById("status-all");
		element.parentElement.classList.add('active');
	}
};
