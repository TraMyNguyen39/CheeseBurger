// them nguyen lieu
var button = document.querySelector("div.button__add");
button.addEventListener("click", function () {
    var modal = document.querySelector('.modal__ingredient-add');
    modal.classList.add('open');
});
// end

// Xem nguyên lieu
var eyeButtons = document.querySelectorAll(".fa-eye");

for (var i = 0; i < eyeButtons.length; i++) {
    eyeButtons[i].addEventListener("click", function () {
        var modal = document.querySelector(".modal__food-read");
        modal.classList.add("open");
    });
}
// End

// Cap nhat nguyen lieu
var pencilButtons = document.querySelectorAll(".fa-pencil-alt");

for (var i = 0; i < eyeButtons.length; i++) {
    pencilButtons[i].addEventListener("click", function () {
        var modal = document.querySelector(".modal__ingredient-modify");
        modal.classList.add("open");
    });
}
// End

// Exit
var buttonExit = document.querySelectorAll("div.button__exit");

function handleCloseModal() {
    var modal = this.parentNode.parentNode;
    modal.classList.remove("open");
}

for (var i = 0; i < buttonExit.length; i++) {
    buttonExit[i].addEventListener("click", handleCloseModal);
}
