window.onload = function () {
    var menuClass = localStorage.getItem('menuClass');
    var element = document.getElementById(menuClass);
    if (element) {
        element.classList.add('active');
    } else {
        element = document.getElementById('revenue');
        element.classList.add('active');
    }
};

var manageFunction = document.getElementsByClassName('categories__item');
for (var i = 0; i < manageFunction.length; i++) {
    manageFunction[i].addEventListener('click', function () {
        var current = document.getElementsByClassName("active");
        current[0].className = current[0].className.replace(" active", "");
        this.classList.toggle("active");
        localStorage.setItem('menuClass', this.id);
    });
};
