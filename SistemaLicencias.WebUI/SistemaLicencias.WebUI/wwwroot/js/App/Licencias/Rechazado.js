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
    $('#lice').delay(1000).addClass('active');
    $('#MenuLicencia').delay(1000).attr('aria-expanded', true);
    $('#subMenuLicencia').delay(1000).attr('aria-expanded', true);
    $('#subMenuLicencia').delay(1000).addClass('in');
    $('#RechazosItem').delay(1000).addClass('active');
}