window.onload = function () {
	var email = document.getElementById("emaill").value;
	var url = 'https://localhost:44344/Login/SuccessfulValidate';
	var form = document.createElement("form");
	form.action = url;
	form.method = "POST";

	var emailInput = document.createElement("input");
	emailInput.type = "text";
	emailInput.name = "email";
	emailInput.value = email;
	form.appendChild(emailInput);

	document.body.appendChild(form);
	form.submit();
}
