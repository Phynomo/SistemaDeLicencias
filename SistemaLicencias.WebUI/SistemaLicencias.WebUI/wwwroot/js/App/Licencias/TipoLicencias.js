function AbrirModalDelete(id) {
    $("#tili_IdD").val(id);
    $("#ModalDelete").appendTo('body').modal('show');
}

function EnviarModalDelete() {
    if ($("#tili_IdD").val() != "") {
        $("#formDelete").submit();
    }
}