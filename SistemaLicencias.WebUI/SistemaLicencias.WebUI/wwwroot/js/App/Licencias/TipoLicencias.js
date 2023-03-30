$(document).ready(function () {

    var resultado = $("#resultado").val();
    if (resultado == "CreateSuccess") {
        swal({
            title: 'Guardado',
            text: 'El registro se creo con exito',
            type: 'success',
            icon: '../../gif/36108-driver-licence-scan.gif',
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
    $('#lice').delay(1000).addClass('active');
    $('#MenuLicencia').delay(1000).attr('aria-expanded', true);
    $('#subMenuLicencia').delay(1000).attr('aria-expanded', true);
    $('#subMenuLicencia').delay(1000).addClass('in');
    $('#TipoLicenciassItem').delay(1000).addClass('active');

}


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

function OpenModalEdit(Cadena) {
    var datos = Cadena.split(",$$,");
    $("#tili_IdE").val(datos[0]);
    $("#tili_DescripcionE").val(datos[1]);


    $("#lbltili_DescripcionE").attr('hidden', true);
    $('#ModalEditClass').removeClass('bounce');
    $('#ModalEditClass').removeClass('flipInY');
    $('#ModalEditClass').addClass('flipInY');
    $("#ModalEdit").appendTo('body').modal('show');
}

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
