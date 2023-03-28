$(document).ready(function () {


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

});



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