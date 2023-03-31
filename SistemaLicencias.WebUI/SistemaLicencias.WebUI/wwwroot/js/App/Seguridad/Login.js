/*
		Designed by: SELECTO
		Original image: https://dribbble.com/shots/5311359-Diprella-Login
*/

let switchCtn = document.querySelector("#switch-cnt");
let switchC1 = document.querySelector("#switch-c1");
let switchC2 = document.querySelector("#switch-c2");
let switchCircle = document.querySelectorAll(".switch__circle");
let switchBtn = document.querySelectorAll(".switch-btn");
let aContainer = document.querySelector("#a-container");
let bContainer = document.querySelector("#b-container");
let allButtons = document.querySelectorAll(".submit");

let getButtons = (e) => e.preventDefault();

let changeForm = (e) => {
	switchCtn.classList.add("is-gx");
	setTimeout(function () {
		switchCtn.classList.remove("is-gx");
	}, 1500);

	switchCtn.classList.toggle("is-txr");
	switchCircle[0].classList.toggle("is-txr");
	switchCircle[1].classList.toggle("is-txr");

	switchC1.classList.toggle("is-hidden");
	switchC2.classList.toggle("is-hidden");
	aContainer.classList.toggle("is-txl");
	bContainer.classList.toggle("is-txl");
	bContainer.classList.toggle("is-z200");
};

let mainF = (e) => {
	for (var i = 0; i < allButtons.length; i++)
		allButtons[i].addEventListener("click", getButtons);
	for (var i = 0; i < switchBtn.length; i++)
		switchBtn[i].addEventListener("click", changeForm);
};

window.addEventListener("load", mainF);


$(document).ready(function () {

    var resultado = $("#resultado").val();
    if (resultado == "InicioFallido") {
        swal({
            title: 'Error',
            text: 'No se pudo iniciar sesión',
            type: 'error',
            timer: 2500,
            showConfirmButton: false,
            showCancelButton: false,
            closeOnClickOutside: false,
            closeOnEsc: false,
        });
    }
	if (resultado == "RecuperacionFallida") {
        swal({
            title: 'Error',
            text: 'No se pudo Recuperar tu usuario',
            type: 'error',
            timer: 2500,
            showConfirmButton: false,
            showCancelButton: false,
            closeOnClickOutside: false,
            closeOnEsc: false,
        });
    }
    if (resultado == "RecuperacionExitosa") {
        swal({
            title: 'Recuperado',
            text: 'Tu usuario se a recuperado con exito',
            type: 'success',
            timer: 2500,
            showConfirmButton: false,
            showCancelButton: false,
            closeOnClickOutside: false,
            closeOnEsc: false,
        });
    }
});


function btnLogin() {
	var user_NombreUsuarioL = $("#user_NombreUsuarioL").val();
	var user_ContrasenaL = $("#user_ContrasenaL").val();

	$("#lbluser_NombreUsuarioL").attr('hidden', true);
	$("#lbluser_ContrasenaL").attr('hidden', true);

	if (user_NombreUsuarioL != "" && user_ContrasenaL != "") {
		$("#b-form").submit();
    } else {
		toastr.warning("Completa todos los campos para continuar", "Campos vacios")
		if (user_NombreUsuarioL == "") {
			$("#lbluser_NombreUsuarioL").attr('hidden', false);
        }
		if (user_ContrasenaL == "") {
			$("#lbluser_ContrasenaL").attr('hidden', false);
        }
    }
}

function btnRecuperar() {
	var user_NombreUsuarioR = $("#user_NombreUsuarioR").val();
	var user_ContrasenaR = $("#user_ContrasenaR").val();

	$("#lbluser_NombreUsuarioR").attr('hidden', true);
	$("#lbluser_ContrasenaR").attr('hidden', true);

	if (user_NombreUsuarioR != "" && user_ContrasenaR != "") {
		$("#a-form").submit();
    } else {
		toastr.warning("Completa todos los campos para continuar", "Campos vacios")
		if (user_NombreUsuarioR == "") {
			$("#lbluser_NombreUsuarioL").attr('hidden', false);
        }
		if (user_ContrasenaR == "") {
			$("#lbluser_ContrasenaL").attr('hidden', false);
        }
    }
}