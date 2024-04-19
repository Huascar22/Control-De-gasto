const UrlVerGastos ="https://localhost:7002/VerGastos";
const UrlEliminarGasto = "https://localhost:7002/EliminarGasto";
urlGastoCategorizado = "https://localhost:7002/CrearGastoCategorizado";


function VerGastos(catero){
    fetch(UrlVerGastos+"/"+Usuario.id)
    .then(gastos => gastos.json())
    .then(gastos => {
        FiltrarGastoPorCategoria(gastos, catero)      
    }); 
}

function FiltrarGastoPorCategoria(gasto, categoria){
    console.log(gasto)
    let gastosCategorizados = gasto.filter(C => C.idCategoria == categoria);
    gastosCategorizados.forEach(element =>{
        crearTarjeta(element);
    });
}

function crearTarjeta(element) {
    const cardsContainer = document.getElementById('cards-container');
    const card = document.createElement('div');
    card.classList.add('card');
   
    const cardTitle = document.createElement('h2');
    cardTitle.textContent = "Gastos";  
    const cardContent = document.createElement('p');
    cardContent.innerHTML = `<strong>Cantidad:</strong> ${element.cantidadGasto}<br>
                                <strong>Nombre:</strong> ${element.nombreGasto}<br>
                                <strong>Categoría:</strong> ${element.idCategoria}`;

    const deleteButton = document.createElement('button');
    deleteButton.textContent = 'X';
    deleteButton.classList.add('delete-button');

    deleteButton.addEventListener('click', function() {
        console.log(element.idGasto)
        EliminarGasto(element.idGasto)
        card.remove();
    });

    card.appendChild(cardTitle);
    card.appendChild(cardContent);
    card.appendChild(deleteButton); 
    cardsContainer.appendChild(card);         
}

function EliminarGasto(idGasto){
    fetch(UrlEliminarGasto+"/"+idGasto, {
        method: "Delete",
        headers: {'Content-Type': 'application/json'}
    })
}

