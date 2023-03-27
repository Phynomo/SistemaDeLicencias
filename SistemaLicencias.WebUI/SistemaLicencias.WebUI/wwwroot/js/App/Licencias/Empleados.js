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
});





function PostCreate()
{
    var empe_Nombres = $("#empe_Nombres").val();
    var empe_Apellidos = $("#empe_Apellidos").val();
    var empe_Identidad = $("#empe_Identidad").val();
    var empe_FechaNacimiento = $("#empe_FechaNacimiento").val();
    var empe_Sexo = "";
    var eciv_Id = $("#eciv_Id").val();
    var depa_Id = $("#depa_Id").val();
    var muni_Id = $("#muni_Id").val();
    var empe_Telefono = $("#empe_Telefono").val();
    var empe_CorreoElectronico = $("#empe_CorreoElectronico").val();
    var sucu_Id = $("#sucu_Id").val();
    var carg_Id = $("#carg_Id").val();
    var empe_DireccionExacta = $("#empe_DireccionExacta").val();
    

    $("#lblempe_Nombres").attr('hidden', true);
    $("#lblempe_Apellidos").attr('hidden', true);
    $("#lblempe_Identidad").attr('hidden', true);
    $("#lblempe_FechaNacimiento").attr('hidden', true);
    $("#lblempe_Sexo").attr('hidden', true);
    $("#lbleciv_Id").attr('hidden', true);
    $("#lbldepa_Id").attr('hidden', true);
    $("#lblmuni_Id").attr('hidden', true);
    $("#lblempe_Telefono").attr('hidden', true);
    $("#lblempe_CorreoElectronico").attr('hidden', true);
    $("#lblsucu_Id").attr('hidden', true);
    $("#lblcarg_Id").attr('hidden', true);
    $("#lblempe_DireccionExacta").attr('hidden', true);


    if ($("#M").is(":checked")) {
        empe_Sexo = 'M';
    } else if ($("#F").is(":checked")) {
        empe_Sexo = 'F';
    }

    if (empe_Nombres != "" && empe_Apellidos != "" && empe_Identidad != "" && empe_FechaNacimiento != "" &&
        empe_Sexo != "" && muni_Id != "" && empe_Telefono != "" && empe_CorreoElectronico != "" &&
        sucu_Id != "" && carg_Id != "" && empe_DireccionExacta != "" && eciv_Id != "" &&
        depa_Id != "") {
        $("#formCreate").submit();
    } else {
    toastr.warning("Completa todos los campos para continuar", "Campos vacios")
        if (empe_Nombres == "") {
            $("#lblempe_Nombres").attr('hidden', false);
        }
        if (empe_Apellidos == "") {
            $("#lblempe_Apellidos").attr('hidden', false);
        }
        if (empe_Identidad == "") {
            $("#lblempe_Identidad").attr('hidden', false);
        }
        if (empe_FechaNacimiento == "") {
            $("#lblempe_FechaNacimiento").attr('hidden', false);
        }
        if (empe_Sexo == "") {
            $("#lblempe_Sexo").attr('hidden', false);
        }
        if (eciv_Id == "") {
            $("#lbleciv_Id").attr('hidden', false);
        }
        if (depa_Id == "") {
            $("#lbldepa_Id").attr('hidden', false);
        }
        if (muni_Id == "") {
            $("#lblmuni_Id").attr('hidden', false);
        }
        if (empe_Telefono == "") {
            $("#lblempe_Telefono").attr('hidden', false);
        }
        if (empe_CorreoElectronico == "") {
            $("#lblempe_CorreoElectronico").attr('hidden', false);
        }
        if (sucu_Id == "") {
            $("#lblsucu_Id").attr('hidden', false);
        }
        if (carg_Id == "") {
            $("#lblcarg_Id").attr('hidden', false);
        }
        if (empe_DireccionExacta == "") {
            $("#lblempe_DireccionExacta").attr('hidden', false);
        }
    }


}



function PostEdit() {
    var empe_Nombres = $("#empe_Nombres").val();
    var empe_Apellidos = $("#empe_Apellidos").val();
    var empe_Identidad = $("#empe_Identidad").val();
    var empe_FechaNacimiento = $("#empe_FechaNacimiento").val();
    var empe_Sexo = "";
    var eciv_Id = $("#eciv_Id").val();
    var depa_Id = $("#depa_Id").val();
    var muni_Id = $("#muni_Id").val();
    var empe_Telefono = $("#empe_Telefono").val();
    var empe_CorreoElectronico = $("#empe_CorreoElectronico").val();
    var sucu_Id = $("#sucu_Id").val();
    var carg_Id = $("#carg_Id").val();
    var empe_DireccionExacta = $("#empe_DireccionExacta").val();


    $("#lblempe_Nombres").attr('hidden', true);
    $("#lblempe_Apellidos").attr('hidden', true);
    $("#lblempe_Identidad").attr('hidden', true);
    $("#lblempe_FechaNacimiento").attr('hidden', true);
    $("#lblempe_Sexo").attr('hidden', true);
    $("#lbleciv_Id").attr('hidden', true);
    $("#lbldepa_Id").attr('hidden', true);
    $("#lblmuni_Id").attr('hidden', true);
    $("#lblempe_Telefono").attr('hidden', true);
    $("#lblempe_CorreoElectronico").attr('hidden', true);
    $("#lblsucu_Id").attr('hidden', true);
    $("#lblcarg_Id").attr('hidden', true);
    $("#lblempe_DireccionExacta").attr('hidden', true);


    if ($("#M").is(":checked")) {
        empe_Sexo = 'M';
    } else if ($("#F").is(":checked")) {
        empe_Sexo = 'F';
    }

    if (empe_Nombres != "" && empe_Apellidos != "" && empe_Identidad != "" && empe_FechaNacimiento != "" &&
        empe_Sexo != "" && muni_Id != "" && empe_Telefono != "" && empe_CorreoElectronico != "" &&
        sucu_Id != "" && carg_Id != "" && empe_DireccionExacta != "" && eciv_Id != "" &&
        depa_Id != "") {
        $("#formEdit").submit();
    } else {
        toastr.warning("Completa todos los campos para continuar", "Campos vacios")
        if (empe_Nombres == "") {
            $("#lblempe_Nombres").attr('hidden', false);
        }
        if (empe_Apellidos == "") {
            $("#lblempe_Apellidos").attr('hidden', false);
        }
        if (empe_Identidad == "") {
            $("#lblempe_Identidad").attr('hidden', false);
        }
        if (empe_FechaNacimiento == "") {
            $("#lblempe_FechaNacimiento").attr('hidden', false);
        }
        if (empe_Sexo == "") {
            $("#lblempe_Sexo").attr('hidden', false);
        }
        if (eciv_Id == "") {
            $("#lbleciv_Id").attr('hidden', false);
        }
        if (depa_Id == "") {
            $("#lbldepa_Id").attr('hidden', false);
        }
        if (muni_Id == "") {
            $("#lblmuni_Id").attr('hidden', false);
        }
        if (empe_Telefono == "") {
            $("#lblempe_Telefono").attr('hidden', false);
        }
        if (empe_CorreoElectronico == "") {
            $("#lblempe_CorreoElectronico").attr('hidden', false);
        }
        if (sucu_Id == "") {
            $("#lblsucu_Id").attr('hidden', false);
        }
        if (carg_Id == "") {
            $("#lblcarg_Id").attr('hidden', false);
        }
        if (empe_DireccionExacta == "") {
            $("#lblempe_DireccionExacta").attr('hidden', false);
        }
    }


}




function OpenModalDelete(id) {
    $("#empe_IdD").val(id);
    $('#ModalDeleteClass').removeClass('bounce');
    $('#ModalDeleteClass').removeClass('flipInY');
    $('#ModalDeleteClass').addClass('flipInY');
    $("#ModalDelete").appendTo('body').modal('show');
}

function PostModalDelete() {
    if ($("#empe_IdD").val() != "") {
        $("#formDelete").submit();
    }
}
