const ic_open = document.getElementsByClassName('ic-open-modal-review');
const ic_close = document.getElementById('ic-close-modal-review');
const btn_close = document.getElementById('btn-close-modal-review');

const modal_container = document.getElementById('modal-container-review');
const modal_demo = document.getElementById('modal-review');

for (var i = 0; i < ic_open.length; i++) {
    ic_open[i].addEventListener('click', () => {
        modal_container.classList.add('show');
    });
}

ic_close.addEventListener('click', () => {
    modal_container.classList.remove('show');
});
btn_close.addEventListener('click', () => {
    modal_container.classList.remove('show');
});

modal_container.addEventListener('click', (e) => {
    if (!modal_demo.contains(e.target)) {
        ic_close.click();
    }
});
