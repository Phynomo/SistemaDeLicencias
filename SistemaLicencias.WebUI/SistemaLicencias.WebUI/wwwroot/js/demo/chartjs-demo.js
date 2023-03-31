$(function () {


    var hombre  = $("#CantidadHombres").val();
    var mujer   = $("#CantidadMujeres").val();


    var max = parseInt(hombre) + parseInt(mujer);
    var proHombre = (hombre / parseInt(max)) * 100;
    var proMujer = (mujer / parseInt(max)) * 100;


    proHombre = proHombre.toFixed(2);
    proMujer = proMujer.toFixed(2);


    var doughnutData = {
        labels: ["Hombre Aprobados " + proHombre + "%"  ,"Mujeres Aprobadas " + proMujer +"%"],
        datasets: [{
            data: [hombre, mujer],
            backgroundColor: ["#00BFA5", "#DD2C00"]
        }]
    } ;
    var doughnutOptions = {
        responsive: true
    };
    var ctx4 = document.getElementById("doughnutChart").getContext("2d");
    new Chart(ctx4, {type: 'doughnut', data: doughnutData, options:doughnutOptions});


});