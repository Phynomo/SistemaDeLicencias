
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
    if (resultado == "RejectSuccess") {
        swal({
            title: 'Rechazado',
            text: 'La Solicitud fue rechazada exitosamente',
            type: 'success',
            timer: 2500,
            showConfirmButton: false,
            showCancelButton: false,
            closeOnClickOutside: false,
            closeOnEsc: false,
        });
    }
    if (resultado == "RejectError") {
        swal({
            title: 'Error',
            text: 'La Solicitud no se pudo eliminar',
            type: 'error',
            timer: 2500,
            showConfirmButton: false,
            showCancelButton: false,
            closeOnClickOutside: false,
            closeOnEsc: false,
        });
    }

    if (resultado == "AcceptSuccess") {
        swal({
            title: 'Aceptado',
            text: 'La Solicitud fue aceptada',
            type: 'success',
            timer: 2500,
            showConfirmButton: false,
            showCancelButton: false,
            closeOnClickOutside: false,
            closeOnEsc: false,
        });
    }
    if (resultado == "AcceptError") {
        swal({
            title: 'Error',
            text: 'La Solicitud no pudo ser Aceptada',
            type: 'error',
            timer: 2500,
            showConfirmButton: false,
            showCancelButton: false,
            closeOnClickOutside: false,
            closeOnEsc: false,
        });
    }
});



function OpenModalCreate() {
    $("#lbltili_Descripcion").attr('hidden', true);
    $('#ModalCreateClass').removeClass('bounce');
    $('#ModalCreateClass').removeClass('flipInY');
    $('#ModalCreateClass').addClass('flipInY');
    $("#ModalCreate").appendTo('body').modal('show');
}

function PostModalCreate() {
    var canInsert = true;
    var soli_Id = $("#soli_Id").val();
    var sucu_Id = $("#sucu_Id").val();
    var tili_Id = $("#tili_Id").val();


    $("#lbSoli_Id").attr('hidden', true);
    $("#lbSucu_Id").attr('hidden', true);
    $("#lbtili_Id").attr('hidden', true);

    $('#ModalCreateClass').removeClass('bounce');
    $('#ModalCreateClass').removeClass('flipInY');


    if(soli_Id == "0") {
        canInsert = false;
        $("#lbSoli_Id").attr('hidden', false);
    }

    if (sucu_Id == "0") {
        canInsert = false;
        $("#lbSucu_Id").attr('hidden', false);
    }

    if (tili_Id == "0") {
        canInsert = false;
        $("#lbtili_Id").attr('hidden', false);
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
    $("#stud_IdEdit").val(data[0]);
    $("#soli_IdEdit").val(data[1]);
    $("#sucu_IdEdit").val(data[2]);
    $("#tili_IdEdit").val(data[3]);

    if (data[4] == 'True') {
        $("#stud_pagoEdit").attr('checked', true);
    }
    else {
        $("#stud_pagoEdit").attr('checked', false);
    }

    $('#ModalEditClass').removeClass('bounce');
    $('#ModalEditClass').removeClass('flipInY');
    $('#ModalEditClass').addClass('flipInY');

    $("#ModalEdit").appendTo('body').modal('show');
};



function PostModalEdit() {
    var canInsert = true;
    var soli_Id = $("#soli_IdEdit").val();
    var sucu_Id = $("#sucu_IdEdit").val();
    var tili_Id = $("#tili_IdEdit").val();


    $("#lbSoli_IdEdit").attr('hidden', true);
    $("#lbSucu_IdEdit").attr('hidden', true);
    $("#lbtili_IdEdit").attr('hidden', true);

    $('#ModalCreateClass').removeClass('bounce');
    $('#ModalCreateClass').removeClass('flipInY');


    if (soli_Id == "0") {
        canInsert = false;
        $("#lbSoli_IdEdit").attr('hidden', false);
    }

    if (sucu_Id == "0") {
        canInsert = false;
        $("#lbSucu_IdEdit").attr('hidden', false);
    }

    if (tili_Id == "0") {
        canInsert = false;
        $("#lbtili_IdEdit").attr('hidden', false);
    }

    if (canInsert == false) {
        toastr.warning("Completa todos los campos para continuar", "Campos vacios")
        $('#ModalEditClass').addClass('bounce');
        $("#lbltili_DescripcionE").attr('hidden', false);
    }

    if (canInsert) {
        $("#FormEdit").submit();
    }
}



function OpenModalDelete(id) {
    $("#stud_IdDelete").val(id);
    $('#ModalDeleteClass').removeClass('bounce');
    $('#ModalDeleteClass').removeClass('flipInY');
    $('#ModalDeleteClass').addClass('flipInY');
    $("#ModalDelete").appendTo('body').modal('show');
}

function PostModalDelete() {
    if ($("#stud_Id").val() != "") {
        $("#formDelete").submit();
    }
}




function Rejeact(id) {

    console.log(id);

    $("#stud_IdReject").val(id);

    $('#ModalRejeactClass').removeClass('bounce');
    $('#ModalRejeactClass').removeClass('flipInY');
    $('#ModalRejeactClass').addClass('flipInY');

    $("#ModalReject").appendTo('body').modal('show');
};




function PostModalRejeact() {
    var canInsert = true;
    var rech_Observacion = $("#rech_ObservacionReject").val();

    $("#lbRech_ObservacionReject").attr('hidden', true);
 

    $('#ModalCreateClass').removeClass('bounce');
    $('#ModalCreateClass').removeClass('flipInY');

    if (rech_Observacion == "" || rech_Observacion == null) {
        canInsert = false
        $("#lbRech_ObservacionReject").attr('hidden', false);
    }

    if (canInsert) {
        $("#FormReject").submit();
    }
}


function Accept(id) {

    console.log(id);

    $("#stud_IdAccept").val(id);

    $('#ModalAcceptClass').removeClass('bounce');
    $('#ModalAcceptClass').removeClass('flipInY');
    $('#ModalAcceptClass').addClass('flipInY');

    $("#ModalAccept").appendTo('body').modal('show');
};




function PostModalAccept() {
    var canInsert = true;
    var apro_Observacion = $("#apro_ObservacionAccept").val();

    $("#lbapro_ObservacionAccept").attr('hidden', true);


    $('#ModalCreateClass').removeClass('bounce');
    $('#ModalCreateClass').removeClass('flipInY');

    if (apro_Observacion == "" || apro_Observacion == null) {
        canInsert = false
        $("#lbapro_ObservacionAccept").attr('hidden', false);
    }

    if (canInsert) {
        $("#FormAccept").submit();
    }
}