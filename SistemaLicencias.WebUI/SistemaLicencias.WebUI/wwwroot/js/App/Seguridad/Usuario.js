
$(document).ready(function () {


    var resultado = $("#resultado").val();

    if (resultado == "CreateSuccess") {
        swal({
            title: 'Guardado',
            text: 'El registro se creo con exito',
            type: 'success',
            timer: 2500,
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
            timer: 2500,
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
            timer: 2500,
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
            timer: 2500,
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
            timer: 2500,
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
            timer: 2500,
            showConfirmButton: false,
            showCancelButton: false,
            closeOnClickOutside: false,
            closeOnEsc: false,
        });
    }
    if (resultado == "Repetido") {
        swal({
            title: 'Invalido',
            text: 'No pueden existir dos usuarios con el mismo nombre',
            type: 'warning',
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
    $('#UsuarioItem').addClass('active');
}








function OpenModalCreate() {

    $("#lbuser_NombreUsuarioInsert").attr('hidden', true);
    $("#lbuser_ContrasenaInsert").attr('hidden', true);
    $("#lbrole_IdInsert").attr('hidden', true);
    $("#lbempe_IdInsert").attr('hidden', true);


   $("#user_NombreUsuarioInsert").val("");
   $("#user_ContrasenaInsert").val("");
   $("#role_IdInsert").val("0");
   $("#empe_IdInsert").val("0");

    $('#ModalCreateClass').removeClass('bounce');
    $('#ModalCreateClass').removeClass('flipInY');
    $('#ModalCreateClass').addClass('flipInY');
    $("#ModalCreate").appendTo('body').modal('show');
}

function PostModalCreate() {
    var canInsert = true;

    var NombreUsuario = $("#user_NombreUsuarioInsert").val();
    var contrasenia  = $("#user_ContrasenaInsert").val();
    var rol_Id  = $("#role_IdInsert").val();
    var empe_Id = $("#empe_IdInsert").val();
  
    $("#lbuser_NombreUsuarioInsert").attr('hidden', true);
    $("#lbuser_ContrasenaInsert").attr('hidden', true);
    $("#lbrole_IdInsert").attr('hidden', true);
    $("#lbempe_IdInsert").attr('hidden', true);

    $('#ModalCreateClass').removeClass('bounce');
    $('#ModalCreateClass').removeClass('flipInY');


    if (NombreUsuario == "" || NombreUsuario == null) {
        canInsert = false;
        $("#lbuser_NombreUsuarioInsert").attr('hidden', false);
    }

    if (contrasenia == "" || contrasenia == null) {
        canInsert = false;
        $("#lbuser_ContrasenaInsert").attr('hidden', false);
    }

    if (rol_Id == "0") {
        canInsert = false;
        $("#lbrole_IdInsert").attr('hidden', false);
    }

    if (empe_Id == "0") {
        canInsert = false;
        $("#lbempe_IdInsert").attr('hidden', false);
    }

    if (canInsert == false) {
        toastr.warning("Completa todos los campos para continuar", "Campos vacios")
        $('#ModalCreateClass').addClass('bounce');
        $("#lbltili_Descripcion").attr('hidden', false);
    }

    if (canInsert) {
        $("#FormCreate").submit();
    }

}



function Editar(cadena) {

    var datastring = cadena;
    var data = datastring.split(',$$,');
    console.log(cadena);
    $("#user_IdEdit").val(data[0]);
    $("#role_IdEdit").val(data[2]);
    $("#empe_IdEdit").val(data[3]);


    if (data[1] == 'True') {
        $("#user_EsAdminEdit").attr('checked', true);
    }
    else {
        $("#user_EsAdminEdit").attr('checked', false);
    }

    $("#lbrole_IdEdit").attr('hidden', true);
    $("#lbempe_IdEdit").attr('hidden', true);


    $('#ModalEditClass').removeClass('bounce');
    $('#ModalEditClass').removeClass('flipInY');
    $('#ModalEditClass').addClass('flipInY');

    $("#ModalEdit").appendTo('body').modal('show');
};

function PostModalEdit() {
    var canInsert = true;

    var rol_Id  = $("#role_IdEdit").val();
    var empe_Id = $("#empe_IdEdit").val();

    $("#lbrole_IdEdit").attr('hidden', true);
    $("#lbempe_IdEdit").attr('hidden', true);

    $('#ModalEditClass').removeClass('bounce');
    $('#ModalEditClass').removeClass('flipInY');


    if (rol_Id == "0") {
        canInsert = false;
        $("#lbrole_IdEdit").attr('hidden', false);
    }

    if (empe_Id == "0") {
        canInsert = false;
        $("#lbempe_IdEdit").attr('hidden', false);
    }

    if (canInsert == false) {
        toastr.warning("Completa todos los campos para continuar", "Campos vacios")
        $('#ModalEditClass').addClass('bounce');
    }

    if (canInsert) {
        $("#FormEdit").submit();
    }
}



function OpenModalDelete(id) {
    $("#user_IdDelete").val(id);
    $('#ModalDeleteClass').removeClass('bounce');
    $('#ModalDeleteClass').removeClass('flipInY');
    $('#ModalDeleteClass').addClass('flipInY');
    $("#ModalDelete").appendTo('body').modal('show');
}

function PostModalDelete() {
    if ($("#user_IdDelete").val() != "") {
        $("#formDelete").submit();
    }
}