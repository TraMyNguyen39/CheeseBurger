var path = window.location.pathname;
var currentPage = path.split('/').pop(); // Lấy phần tử cuối cùng trong mảng

var setActiveMenuElement = function (menuElement) {
    var current = document.getElementsByClassName("active");
    if (current.length > 0) {
        current[0].classList.remove('active');
    }
    menuElement.classList.add('active');
}

var manageFunction = document.querySelectorAll('.categories__item a');
for (var i = 0; i < manageFunction.length; i++) {
    if (manageFunction[i].getAttribute("href").indexOf(currentPage) !== -1) {
        setActiveMenuElement(manageFunction[i].parentElement);
        break;
    }
}

// Nếu không tìm thấy liên kết, chọn liên kết đầu tiên làm mặc định
//if (!document.querySelector('.categories__item.active')) {
//    document.querySelector('.categories__item:first-child').classList.add('active');
//}

if (currentPage === "ChangePasswordAdmin") {
    setActiveMenuElement(manageFunction[1].parentElement);
}