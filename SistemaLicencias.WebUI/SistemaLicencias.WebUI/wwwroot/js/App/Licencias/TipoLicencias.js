$(document).ready(function () {

    var resultado = $("#resultado").val();
    if (resultado == "CreateSuccess") {
        swal({
            title: 'Guardado',
            text: 'El registro se creo con exito',
            type: 'success',
            icon: '../../gif/36108-driver-licence-scan.gif',
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
});

function OpenModalDelete(id) {
    $("#tili_IdD").val(id);
    $('#ModalDeleteClass').removeClass('bounce');
    $('#ModalDeleteClass').removeClass('flipInY');
    $('#ModalDeleteClass').addClass('flipInY');
    $("#ModalDelete").appendTo('body').modal('show');
}

function PostModalDelete() {
    if ($("#tili_IdD").val() != "") {
        $("#formDelete").submit();
    }
}

function OpenModalCreate() {
    $("#lbltili_Descripcion").attr('hidden', true);
    $('#ModalCreateClass').removeClass('bounce');
    $('#ModalCreateClass').removeClass('flipInY');
    $('#ModalCreateClass').addClass('flipInY');
    $("#ModalCreate").appendTo('body').modal('show');
}

function PostModalCreate() {
    var tili_Descripcion = $("#tili_DescripcionDD").val();

    $("#lbltili_Descripcion").attr('hidden', true);
    $('#ModalCreateClass').removeClass('bounce');
    $('#ModalCreateClass').removeClass('flipInY');

    if (tili_Descripcion != "") {
        $("#FormCreate").submit();
    } else {
        toastr.warning("Completa todos los campos para continuar", "Campos vacios")
        $('#ModalCreateClass').addClass('bounce');
        $("#lbltili_Descripcion").attr('hidden', false);
    }
}

$("#OpenModalEdit").on('click', function () {
    $("#tili_IdE").val($(this).data("id"));
    $("#tili_DescripcionE").val($(this).data("descripcion"));


    $("#lbltili_DescripcionE").attr('hidden', true);
    $('#ModalEditClass').removeClass('bounce');
    $('#ModalEditClass').removeClass('flipInY');
    $('#ModalEditClass').addClass('flipInY');
    $("#ModalEdit").appendTo('body').modal('show');
});

function PostModalEdit() {
    var tili_Descripcion = $("#tili_DescripcionE").val();

    $("#lbltili_DescripcionE").attr('hidden', true);
    $('#ModalEditClass').removeClass('bounce');
    $('#ModalEditClass').removeClass('flipInY');

    if (tili_Descripcion != "") {
        $("#FormEdit").submit();
    } else {
        toastr.warning("Completa todos los campos para continuar", "Campos vacios")
        $('#ModalEditClass').addClass('bounce');
        $("#lbltili_DescripcionE").attr('hidden', false);
    }
}
