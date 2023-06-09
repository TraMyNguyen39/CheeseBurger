var inputQty = document.querySelectorAll('input[name="quantity"]');

var deleteBtn = document.querySelectorAll('button.remove-btn');
for (var item = 0; item < deleteBtn.length; item++) {
    deleteBtn[item].addEventListener('click', function (event) {
        event.preventDefault();
        var removeQty = document.querySelectorAll('.remove-qty');
        for (var i = 0; i < deleteBtn.length; i++) {
            removeQty[i].value = inputQty[i].value;
        }
        this.parentNode.submit();
    });
}

var addBtn = document.querySelectorAll('button.add-btn');
for (var item = 0; item < addBtn.length; item++) {
    addBtn[item].addEventListener('click', function (event) {
        event.preventDefault();
        var addQty = document.querySelectorAll('.add-qty');
        for (var i = 0; i < inputQty.length; i++) {
            addQty[i].value = inputQty[i].value;
        }
        this.parentNode.submit();
    });
}

var submit = document.getElementById('submit-recipe');
var qty = document.querySelectorAll('input[name="quantity"');
var mainQty = document.querySelectorAll('.mainQty');
submit.addEventListener('click', function (event) {
	var check = true;
	for (var i = 0; i < qty.length; i++) {
		var floatNum = parseFloat(qty[i].value);
		if (isNaN(floatNum) || floatNum === 0) {
			qty[i].value = "Nhập số lượng!";
			check = false;
		}
	}
	if (!check || mainQty.length == 0)
		event.preventDefault();
	else {
		for (var i = 0; i < mainQty.length; i++) {
			mainQty[i].value = qty[i].value;
		}
	}

})