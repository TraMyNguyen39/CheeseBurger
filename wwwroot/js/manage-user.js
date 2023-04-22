// thay doi thong tin tai khoan
var eyeButtons = document.querySelectorAll("td.Option__eye");

for (var i = 0; i < eyeButtons.length; i++) {
  eyeButtons[i].addEventListener("click", function() {
    var modal = document.querySelector(".modal__info-full");
    modal.classList.add("open");
  });
}
// end

// Xem
var pencilButtons = document.querySelectorAll("td.Option__pencil");

for (var i = 0; i < pencilButtons.length; i++) {
  pencilButtons[i].addEventListener("click", function() {
    var modal = document.querySelector(".modal__account-update");
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
