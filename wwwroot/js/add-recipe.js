//var inputQty = document.querySelectorAll('input[name="quantity"]');

//var deleteBtn = document.querySelectorAll('button.remove-btn');
//for (var item = 0; item < deleteBtn.length; item++) {
//    deleteBtn[item].addEventListener('click', function (event) {
//        event.preventDefault();
//        var removeQty = document.querySelectorAll('.remove-qty');
//        for (var i = 0; i < deleteBtn.length; i++) {
//            removeQty[i].value = inputQty[i].value;
//        }
//        this.parentNode.submit();
//    });
//}

//var addBtn = document.querySelectorAll('button.add-btn');
//for (var item = 0; item < addBtn.length; item++) {
//    addBtn[item].addEventListener('click', function (event) {
//        event.preventDefault();
//        var addQty = document.querySelectorAll('.add-qty');
//        for (var i = 0; i < inputQty.length; i++) {
//            addQty[i].value = inputQty[i].value;
//        }
//        this.parentNode.submit();
//    });
//}

var submit = document.getElementById('submit-recipe');
var countItem = document.querySelector('input[name="countItem"');

submit.addEventListener('click', function (event) {
	var qty = document.querySelectorAll('input[name="quantity"');
	var ingre = document.querySelectorAll('input[name="ingreID"');

	var check = true;
	for (var i = 0; i < qty.length; i++) {
		var floatNum = parseFloat(qty[i].value);
		if (isNaN(floatNum) || floatNum === 0) {
			qty[i].value = "Nhập số lượng!";
			check = false;
		}
	}
	if (!check || qty.length === 0)
		event.preventDefault();
	else {
		addForm();
		var mainQty = document.querySelectorAll('.mainQty');
		var mainIngre = document.querySelectorAll('.mainIngre');
		for (var i = 0; i < qty.length; i++) {
			mainQty[i].value = qty[i].value;
			mainIngre[i].value = ingre[i].value;
		}
		countItem.value = mainQty.length;
	}
})

function addForm() {
	var form = document.getElementById('UpdateForm');
	var elementCount = document.querySelectorAll('input[name="quantity"').length;
	for (var i = 0; i < elementCount; i++) {
		// Tạo các phần tử input mới
		var mainIngreInput = document.createElement('input');
		mainIngreInput.setAttribute('type', 'hidden');
		mainIngreInput.setAttribute('class', 'mainIngre');
		mainIngreInput.setAttribute('name', 'mainIngre[' + i + ']');

		var mainQtyInput = document.createElement('input');
		mainQtyInput.setAttribute('type', 'hidden');
		mainQtyInput.setAttribute('class', 'mainQty');
		mainQtyInput.setAttribute('name', 'mainQty[' + i + ']');

		// Chèn các phần tử input vào form
		form.appendChild(mainIngreInput);
		form.appendChild(mainQtyInput);
	}
}