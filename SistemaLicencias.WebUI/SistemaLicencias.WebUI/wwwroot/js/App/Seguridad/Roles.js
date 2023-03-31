$(document).ready(function () {


    var resultado = $("#resultado").val();
    if (resultado == "CreateSuccess") {
        swal({
            title: 'Guardado',
            text: 'El registro se creo con exito',
            type: 'success',
            timer: 1500,
            showConfirmButton: false,
            showCancelButton: false,
            closeOnClickOutside: false,
            closeOnEsc: false,
        });
    }
    if (resultado == "CreateError") {
        swal({
            title: 'Error',
            text: 'No se pudo crear el registro',
            type: 'error',
            timer: 1500,
            showConfirmButton: false,
            showCancelButton: false,
            closeOnClickOutside: false,
            closeOnEsc: false,
        });
    }
    if (resultado == "EditSuccess") {
        swal({
            title: 'Editado',
            text: 'El registro fue editado exitosamente',
            type: 'success',
            timer: 1500,
            showConfirmButton: false,
            showCancelButton: false,
            closeOnClickOutside: false,
            closeOnEsc: false,
        });
    }
    if (resultado == "EditError") {
        swal({
            title: 'Error',
            text: 'No se pudo editar el regitro',
            type: 'error',
            timer: 1500,
            showConfirmButton: false,
            showCancelButton: false,
            closeOnClickOutside: false,
            closeOnEsc: false,
        });
    }
    if (resultado == "DeleteSuccess") {
        swal({
            title: 'Eliminado',
            text: 'El registro se elimino exitosamente',
            type: 'success',
            timer: 1500,
            showConfirmButton: false,
            showCancelButton: false,
            closeOnClickOutside: false,
            closeOnEsc: false,
        });
    }
    if (resultado == "DeleteError") {
        swal({
            title: 'Error',
            text: 'No se pudo Eliminar el registro',
            type: 'error',
            timer: 1500,
            showConfirmButton: false,
            showCancelButton: false,
            closeOnClickOutside: false,
            closeOnEsc: false,
        });
    }
    if (resultado == "RolRepetido") {
        swal({
            title: 'Invalido',
            text: 'No pueden existir dos roles con el mismo nombre',
            type: 'warning',
            timer: 2500,
            showConfirmButton: false,
            showCancelButton: false,
            closeOnClickOutside: false,
            closeOnEsc: false,
        });
    }
    if (resultado == "UsoRol") {
        swal({
            title: 'Error',
            text: 'Este rol esta en uso',
            type: 'error',
            timer: 2500,
            showConfirmButton: false,
            showCancelButton: false,
            closeOnClickOutside: false,
            closeOnEsc: false,
        });
    }



    setTimeout(addClass, 100);
    setTimeout(addClass, 200);
    setTimeout(addClass, 300);
    setTimeout(addClass, 400);
    setTimeout(addClass, 500);
    setTimeout(addClass, 600);
    setTimeout(addClass, 700);
    setTimeout(addClass, 800);
    setTimeout(addClass, 900);
    setTimeout(addClass, 1000);


});


function addClass() {
    console.log(1);
    $('#acce').addClass('active');
    $('#MenuAcceso').attr('aria-expanded', true);
    $('#SubMenuAcceso').attr('aria-expanded', true);
    $('#SubMenuAcceso').addClass('in');
    $('#RolesItem').addClass('active');
}



function OpenModalDelete(id) {
    $("#role_Id").val(id);
    $('#ModalDeleteClass').removeClass('bounce');
    $('#ModalDeleteClass').removeClass('flipInY');
    $('#ModalDeleteClass').addClass('flipInY');
    $("#ModalDelete").appendTo('body').modal('show');
}

function PostModalDelete() {
    if ($("#role_Id").val() != "") {
        $("#formDelete").submit();
    }
}



function PostCreate() {
    var role_Nombre = $("#role_Nombre").val();

    $("#lblrole_Nombre").attr('hidden', true);

    if (role_Nombre != "" ) {
        $("#formCreate").submit();
    } else {
        toastr.warning("Completa todos los campos para continuar", "Campos vacios")
        if (role_Nombre == "") {
            $("#lblrole_Nombre").attr('hidden', false);
        }
    }


}

function PostEdit() {
    var role_Nombre = $("#role_Nombre").val();

    $("#lblrole_Nombre").attr('hidden', true);

    if (role_Nombre != "" ) {
        $("#formEdit").submit();
    } else {
        toastr.warning("Completa todos los campos para continuar", "Campos vacios")
        if (role_Nombre == "") {
            $("#lblrole_Nombre").attr('hidden', false);
        }
    }


}
