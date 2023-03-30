$(document).ready(function () {

    var resultado = $("#resultado").val();
    
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
    $('#AprobadosItem').delay(1000).addClass('active');

}




function OpenModalDelete(id) {
    $("#apro_IdD").val(id);
    $('#ModalDeleteClass').removeClass('bounce');
    $('#ModalDeleteClass').removeClass('flipInY');
    $('#ModalDeleteClass').addClass('flipInY');
    $("#ModalDelete").appendTo('body').modal('show');
}

function PostModalDelete() {
    if ($("#apro_IdD").val() != "") {
        $("#formDelete").submit();
    }
}