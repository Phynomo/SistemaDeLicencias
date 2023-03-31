$(document).ready(function () {


    $.getJSON('/Home/PantallasMenu', {})
        .done(function (pantallas) {


            console.log(pantallas);

            var LicenciaIterador    = 1;
            var AccesoIterador      = 1;
            var ReporteIterador     = 1;
            $.each(pantallas, function (index, item) {

                //Licencias
                if (item.pant_Menu == "Licencia" && LicenciaIterador == 1) {

                    $("#lice").append($('<a>', {
                        href: '#',
                        id: 'MenuLicencia',
                      }).append($('<i>', {
                          class: 'fa fa-vcard-o',
                      })).append($('<span>', {
                          class: 'nav-label',
                          text: 'Licencias',
                      })).append($('<span>', {
                          class:'fa arrow',
                      }))
                    )

                    $("#lice").append($('<ul>', {
                        class: 'nav nav-second-level collapse',
                        id: 'subMenuLicencia'
                    }));

                    LicenciaIterador = 0;
                }

                //Acceso
                if (item.pant_Menu == "Acceso" && AccesoIterador == 1) {

                    $("#acce").append($('<a>', {
                        href: '#',
                        id: 'MenuAcceso',
                    }).append($('<i>', {
                        class: 'fa fa-user-o',
                    })).append($('<span>', {
                        class: 'nav-label',
                        text: 'Seguridad',
                    })).append($('<span>', {
                        class: 'fa arrow',
                    }))
                    )

                    $("#acce").append($('<ul>', {
                        class: 'nav nav-second-level collapse',
                        id: 'SubMenuAcceso'
                    }));

                    AccesoIterador = 0;
                }

                //Reportes
                if (item.pant_Menu == "Reporte" && ReporteIterador == 1) {

                    $("#repo").append($('<a>', {
                        href: '#',
                        id: 'MenuReporte',
                    }).append($('<i>', {
                        class: 'fa fa-newspaper-o',
                    })).append($('<span>', {
                        class: 'nav-label',
                        text: 'Reportes',
                    })).append($('<span>', {
                        class: 'fa arrow',
                    }))
                    )

                    $("#repo").append($('<ul>', {
                        class: 'nav nav-second-level collapse',
                        id: 'SubMenuReporte'
                    }));

                    ReporteIterador = 0;
                }

            });



            $.each(pantallas, function (index, item) {

                if (item.pant_Menu == "Licencia") {
                    $("#subMenuLicencia").append($('<li>', {
                        class: 'nav-item',
                        id: item.pant_HtmlId
                    }).append($('<a>', {
                        href: item.pant_Url,
                        class: 'nav-link',
                        text: item.pant_Nombre,   
                    })));
                }


                if (item.pant_Menu == "Acceso") {
                    
                    $("#SubMenuAcceso").append($('<li>', {
                        class: 'nav-item',
                        id: item.pant_HtmlId
                    }).append($('<a>', {
                        href: item.pant_Url,
                        class: 'nav-link',
                        text: item.pant_Nombre,   
                    })));

                }


                if (item.pant_Menu == "Reporte") {
                   
                    $("#SubMenuReporte").append($('<li>', {
                        class: 'nav-item',
                        id: item.pant_HtmlId
                    }).append($('<a>', {
                        href: item.pant_Url,
                        class: 'nav-link',
                        text: item.pant_Nombre,
                    })));

                }

            });


        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            console.error('Error al cargar los municipios: ' + textStatus + ', ' + errorThrown);
        });


});


$("#lice").click(function () {
    var entro = $("#entrolice").val();

    if (entro == "") {

        console.log("hola");
        $('#lice').addClass('active');
        $('#MenuLicencia').attr('aria-expanded', true);
        $('#subMenuLicencia').attr('aria-expanded', true);
        $('#subMenuLicencia').addClass('in');
        $("#entrolice").val("1");
    } else {
        $('#lice').removeClass('active');
        $('#MenuLicencia').attr('aria-expanded', false);
        $('#subMenuLicencia').attr('aria-expanded', false);
        $('#subMenuLicencia').removeClass('in');
        $("#entrolice").val("");
    }
});



$("#acce").click(function () {
    var entro = $("#entroacce").val();

    if (entro == "") {

        $('#acce').addClass('active');
        $('#MenuAcceso').attr('aria-expanded', true);
        $('#SubMenuAcceso').attr('aria-expanded', true);
        $('#SubMenuAcceso').addClass('in');
        $("#entroacce").val("1");
    } else {
        $('#acce').removeClass('active');
        $('#MenuAcceso').attr('aria-expanded', false);
        $('#SubMenuAcceso').attr('aria-expanded', false);
        $('#SubMenuAcceso').removeClass('in');
        $("#entroacce").val("");
    }
});




$("#repo").click(function () {
    var entro = $("#entroRepo").val();

    if (entro == "") {

        $('#repo').addClass('active');
        $('#MenuReporte').attr('aria-expanded', true);
        $('#SubMenuReporte').attr('aria-expanded', true);
        $('#SubMenuReporte').addClass('in');
        $("#entroRepo").val("1");
    } else {
        $('#repo').removeClass('active');
        $('#MenuReporte').attr('aria-expanded', false);
        $('#SubMenuReporte').attr('aria-expanded', false);
        $('#SubMenuReporte').removeClass('in');
        $("#entroRepo").val("");
    }
});
