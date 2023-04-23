// Xem danh muc
var eyeButtons = document.querySelectorAll(".fa-eye");

for (var i = 0; i < eyeButtons.length; i++) {
    eyeButtons[i].addEventListener("click", function () {
        var modal = document.querySelector(".modal__food-read");
        modal.classList.add("open");
    });
}
// End

// Cap nhat danh muc
var pencilButtons = document.querySelectorAll(".fa-pencil-alt");

for (var i = 0; i < eyeButtons.length; i++) {
    pencilButtons[i].addEventListener("click", function () {
        var modal = document.querySelector(".modal__food-modify");
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
// OK
var buttonOK = document.querySelectorAll("button.exit-btn");

function handleOKModal() {
    var modal = this.parentNode.parentNode.parentNode;
    modal.classList.remove("open");
}
for (var i = 0; i < buttonOK.length; i++) {
    buttonOK[i].addEventListener("click", handleOKModal);
}