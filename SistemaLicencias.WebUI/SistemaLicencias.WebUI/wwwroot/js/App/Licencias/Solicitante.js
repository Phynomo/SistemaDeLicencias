﻿$(document).ready(function () {


    var resultado = $("#resultado").val();
    if (resultado == "CreateSuccess") {
        swal({
            title: 'Guardado',
            text: 'El registro se creo con exito',
            type: 'success',
            timer: 2000,
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
    if (resultado == "Camposvacios") {
        toastr.warning("Completa todos los campos para continuar", "Campos vacios")
    }







    if ($("#muni_Id").val() == "") {

        $.getJSON('/Solicitante/MunicipiosDropDownList', { id: $("#depa_Id").val() })

            .done(function (municipios) {

                console.log(municipios)

                $("#muni_Id").prop("disabled", false);
                var municipiosSelect = $('#muni_Id');
                municipiosSelect.empty();

                municipiosSelect.append($('<option>', {
                    value: '',
                    text: '--Selecciona un municipio--'
                }));

                $.each(municipios, function (index, item) {
                    municipiosSelect.append($('<option>', {
                        value: item.value,
                        text: item.text
                    }));

                });




            })

            .fail(function (jqXHR, textStatus, errorThrown) {
                console.error('Error al cargar los municipios: ' + textStatus + ', ' + errorThrown);
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
    $('#SolicitanteItem').delay(1000).addClass('active');
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


$("#depa_Id").change(function () {
    var departamentoId = $("#depa_Id").val();

    $.getJSON('/Solicitante/MunicipiosDropDownList', { id: departamentoId })

        .done(function (municipios) {

            console.log(municipios)

            $("#muni_Id").prop("disabled", false);
            var municipiosSelect = $('#muni_Id');
            municipiosSelect.empty();

            municipiosSelect.append($('<option>', {
                value: '',
                text: '--Selecciona un municipio--'
            }));

            $.each(municipios, function (index, item) {
                municipiosSelect.append($('<option>', {
                    value: item.value,
                    text: item.text
                }));

            });

        })

        .fail(function (jqXHR, textStatus, errorThrown) {
            console.error('Error al cargar los municipios: ' + textStatus + ', ' + errorThrown);
        });

});