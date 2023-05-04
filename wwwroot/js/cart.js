var plusButton = document.getElementsByClassName('plus');
var minusButton = document.getElementsByClassName('minus');
//Increase
for (var i = 0; i < plusButton.length; i++) {
    var button = plusButton[i];
    button.addEventListener('click', function handleClick(event) {
        var input = event.target.parentElement.children[1];
        var inputValue = input.value;
        var newValue = parseInt(inputValue) + 1;
        if (isNaN(newValue)) {
            newValue = 1;
        }
        input.value = newValue;
        var submit = event.target.parentElement.children[4];
        submit.click();
    });
}
//Descrease
for (var i = 0; i < minusButton.length; i++) {
    var button = minusButton[i];
    button.addEventListener('click', function handleClick(event) {
        var input = event.target.parentElement.children[1];
        var inputValue = input.value;
        var newValue = parseInt(inputValue) - 1;
        if (isNaN(newValue) || newValue <= 0) {
            newValue = 1;
        }
        input.value = newValue;
        var submit = event.target.parentElement.children[4];
        submit.click();
    });
}
// Thẻ input
var inputs = document.getElementsByClassName("input-field");
for (var i = 0; i < inputs.length; i++) {
    inputs[i].addEventListener("input", validateInput);
}
function validateInput(event) {
    var input = event.target.value;
    var regex = /^\d+$/;

    if (!regex.test(input)) {
        event.target.value = "1";
    }
    // click
    var submit = event.target.parentElement.children[4];
    submit.click();
}
//function changeQuantity(productId, quantity) {
//    var input = document.getElementById(productId);
//    alert(input.value);
//    var output = document.getElementById("total-" + productId).innerText;
//    alert(output);
//    $.ajax({
//        type: "POST",
//        url: "https://localhost:44344/User/Cart",
//        data: { prodId: productId, qty: quantity },
//        success: function (data) {
//            $("#total-" + productId).html(data.totalPrice);
//        },
//        error: function (data) {
//            console.log("NôtK: " + data.responseText);
//        }
//    });
//}

//$(document).ready(function () {
//    $(".input-group .submit").click(function (event) {
//        event.preventDefault();
//        var productid = $(this).value;
//        var quantity = $("#quantity-" + productid).val();
//        $.ajax({
//            type: "POST",
//            url: "/user/cart",
//            data: {
//                productid: productid,
//                quantity: quantity
//            },
//            success: function (result) {
//                window.location.href = "@Url.RouteUrl(/" / user / cart/")";
//            }
//        });
//    });
//});

