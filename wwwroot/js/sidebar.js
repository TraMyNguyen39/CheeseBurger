// Nếu không tìm thấy liên kết, chọn liên kết đầu tiên làm mặc định
if (!document.querySelector('.categories__item.active')) {
    document.querySelector('.categories__item:first-child').classList.add('active');
}

if (currentPage === "ChangePasswordAdmin") {
    setActiveMenuElement(manageFunction[1].parentElement);
}

var path = window.location.pathname;
var currentPage = path.split('/').pop(); // Lấy phần tử cuối cùng trong mảng

var setActiveMenuElement = function (menuElement) {
    var current = document.getElementsByClassName("active");
    if (current.length > 0) {
        current[0].classList.remove('active');
    }
    menuElement.classList.add('active');
}

var manageFunction = document.querySelectorAll('.categories__item > a');
for (var i = 0; i < manageFunction.length; i++) {
    var href = manageFunction[i].getAttribute("href");
    if (href != null) {
        if (href.indexOf(currentPage) !== -1) {
            setActiveMenuElement(manageFunction[i].parentElement);
            break;
        }
    }
}
if (currentPage === 'ManageFood' || currentPage === 'ManageFoodRecipe' || currentPage === 'AddRecipes') {
    var food = document.getElementById('food');
    setActiveMenuElement(food);
}

if (currentPage === 'ManageImportOrder' || currentPage === 'ManageExportOrder' || currentPage === 'DetailExportOrder'
    || currentPage === 'ImportOrderDetail' || currentPage === 'ImportOrderProc') {
    var order = document.getElementById('order');
    setActiveMenuElement(order);
}

// Nếu không tìm thấy liên kết, chọn liên kết đầu tiên làm mặc định
//if (!document.querySelector('.categories__item.active')) {
//    document.querySelector('.categories__item:first-child').classList.add('active');
//}
function toggleCollapse(id) {
    var content = document.getElementById(id);
    if (content.style.display === "none") {
        content.style.display = "block";
    } else {
        content.style.display = "none";
    }
}