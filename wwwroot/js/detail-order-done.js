window.onload = function () {
    document.querySelector('#star-error').textContent = '';
}

// Xem
var pencilButtons = document.querySelectorAll("td.Option__pencil");

for (var i = 0; i < pencilButtons.length; i++) {
    pencilButtons[i].addEventListener("click", function () {
        var modal = document.getElementById('modal-container-review');
        modal.classList.add('show');
    });
}
// End

// Exit
var ic_close = document.getElementById('ic-close-modal-review');

ic_close.addEventListener('click', function () {
    var modal = document.getElementById('modal-container-review');
    modal.classList.remove('show');
    document.querySelector('#star-error').textContent = '';
    document.querySelector('#fileupload').value = ''; 
    document.querySelector('input[name="star"]:checked').checked = false; 
    document.querySelector('textarea[name="content_review"]').value = ''; 
});
// End