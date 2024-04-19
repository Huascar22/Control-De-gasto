const AVerGraficos = document.getElementById("analisisGastos");
const CategoriasGraficas = "https://localhost:7002/VerCategorias";
const containerGrafico = document.getElementById("chartContainer");
const UrlVerLimiteGasto = "https://localhost:7002/VerLimiteGasto";
const UrlEnviarCorreoLimite = "https://localhost:7002/EnviarLimiteCorreo";
//const cardsContainer = document.getElementById('cards-container');

AVerGraficos.addEventListener("click", ()=>{
    menuCuenta.style.display = "none";
    cardsContainer.innerText = "";
    containerGrafico.style.display = "flex";
    BuscarTodasCategorias();
    
})
function BuscarTodasCategorias(){
    fetch(CategoriasGraficas+"/"+Usuario.id)
    .then(categorias => categorias.json())
    .then(categorias => CrearGraficosVelas(categorias));
}
function CrearGraficosVelas(categorias){
    let dataPoints = [];
    let gastoTotal = 0;
    categorias.forEach(elemento =>{
        gastoTotal += elemento.cantidadGasto;
    });

    categorias.forEach(element => {      
        var grupo = { label: element.nombreCategoria, y: (element.cantidadGasto / gastoTotal) * 100 };   
        dataPoints.push(grupo);     
    });
    CrearGraficos(dataPoints);
}
function CrearGraficos(dataPoints){
    var options = {
        title: {
            text: "Gráfico de Barras"
        },
        axisY: {
            title: "Porcentaje",
            suffix: "%"
        },
        axisX: {
            title: "Grupos"
        },
        data: [{
            type: "column",
            dataPoints: dataPoints
        }]
    };
    var chart = new CanvasJS.Chart("chartContainer", options);
    chart.render();
}
function VerLimiteGasto(){
    let gastosTotal = 0;
    let limiteNumerico;
    fetch(UrlVerLimiteGasto+"/"+Usuario.id)
    .then(limite => limite.text())
    .then(limite => {
        limiteNumerico = parseInt(limite);
        fetch(UrlVerGastos+"/"+Usuario.id)
        .then(gastos => gastos.json())
        .then(gastos => {
            gastos.forEach(elemento =>{
                gastosTotal += elemento.cantidadGasto;
            });
            console.log("seguimos proooo")
            console.log(gastosTotal);
            console.log(limiteNumerico);
            CompararGastos(gastosTotal, limiteNumerico)
        });
    })   
}

function CompararGastos(gasto, limiteGasto){
    if(gasto > limiteGasto){
        console.log("Ha superado su limite")
        EnvioDeCorreoLimite()
    }else{
        console.log("Aun esta dentro de su limite")
    }
}

function EnvioDeCorreoLimite(){
    fetch(UrlEnviarCorreoLimite+"/"+Usuario.email)
}