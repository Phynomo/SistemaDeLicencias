$(document).ready(function () {

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
    $('#repo').addClass('active');
    $('#MenuReporte').attr('aria-expanded', true);
    $('#SubMenuReporte').attr('aria-expanded', true);
    $('#SubMenuReporte').addClass('in');
    $('#ReportesItem').addClass('active');
}