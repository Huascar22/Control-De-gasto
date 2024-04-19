const gestionCategorias = document.getElementById("AdministrarCategorias");
const menuCategoria = document.getElementById("MenuCategoria");
const ACrearCategoria = document.getElementById("A-CrearCategoria");
const btnCrearCategoria = document.getElementById("btn-CrearCategoria");
const formulacioCrearCategoria = document.getElementById("FormularioCrearCategoria");
const inputCrearCategoria = document.getElementById("InputCrearCategoria");
const urlCrearCategoria = "https://localhost:7002/CrearCategoria";
const AVerCategorias = document.getElementById("A-VerCategorias");
const urlVerCategoria = "https://localhost:7002/VerCategorias";
const UrlEliminarCategoria = "https://localhost:7002/EliminarCategoria";
const Usuario = JSON.parse(localStorage.getItem("usuario"));
const SignoDeMas = document.getElementById("Signo+");
const formularioGastooo = document.getElementById("FormularioCrearGasto");
const inputNombreGasto = document.getElementById("InputCrearGastoNombre");
const inputCantidadGasto = document.getElementById("InputCrearGastoCantidad");
const btnCrearGastoo =  document.getElementById("btn-CrearGasto");


SignoDeMas.addEventListener("click", ()=>{
    formulacioCrearCategoria.style.display = "flex";
});

localStorage.setItem("menuCategoria", JSON.stringify(menuCategoria));

gestionCategorias.addEventListener("click", ()=>{
    containerGrafico.style.display = "none";
    formularioGastooo.style.display = "none"
    cardsContainer.innerText = "";
    menuCategoria.style.display = "flex";
    menuCuenta.style.display = "none";
    VerTodasLasCategorias();
});

btnCrearCategoria.addEventListener("click", ()=>{
    event.preventDefault();
    if(inputCrearCategoria.value.trim() === ""){
        alert("Campo requerido")
    }else{
        formulacioCrearCategoria.style.display = "none";
        CrearCategoria();
    }
});

btnCrearGastoo.addEventListener("click", ()=>{
    event.preventDefault();
    if(inputCantidadGasto.value.trim() ==="" || inputNombreGasto.value.trim() ===""){
        alert("Campo requerido")
    }else{
        let nuevogasto = new GastoCategorizado(Usuario.id, idcategor, inputCantidadGasto.value,inputNombreGasto.value);
        CrearGastoBD(nuevogasto);
        formularioGastooo.style.display = "none";      
    }
});


function AsignarIdCategoria(id){
    idcategor = id
    console.log(`desde la funcion ${idcategor}`)
}
class GastoCategorizado {
    constructor(idUsuario, idCategoria, CantidadGasto, NombreGasto){
        this.idUsuario = idUsuario,
        this.idCategoria = idCategoria,
        this.cantidadGasto = CantidadGasto,
        this.NombreGasto = NombreGasto
    }
}
function CrearGastoBD(nuevogasto){
    console.log(nuevogasto)
    fetch(urlGastoCategorizado,{
        method: "Post",
        headers: {
            'Content-Type': 'application/json' 
          },
        body: JSON.stringify({
            idUsuario: nuevogasto.idUsuario,
            idCategoria: nuevogasto.idCategoria,
            cantidadGasto: nuevogasto.cantidadGasto,
            nombreGasto: nuevogasto.NombreGasto
        })
    });
    AlertaActualizar();
    setTimeout(()=>{
        VerTodasLasCategorias();
        VerLimiteGasto();
    }, 2000)
}

function CrearCategoria(){
    fetch(urlCrearCategoria, {
        method: "Post",
        headers: {
            'Content-Type': 'application/json' 
          },
        body: JSON.stringify({
            idUsuario: Usuario.id,
            nombreCategoria: inputCrearCategoria.value,
            cantidadGasto: 0
        })
    });
    AlertaActualizar();
    setTimeout(()=>{
        VerTodasLasCategorias();
    }, 2000)
}

function VerTodasLasCategorias(){
    menuCategoria.style.display = "flex";
    fetch(urlVerCategoria +"/"+ Usuario.id)
    .then(categorias => categorias.json())
    .then(categorias => {
        console.log(categorias.nombreCategoria)
        if(categorias.length == 0){
            alert("Este usuario aun no tiene Categoria")
        }else{
            CrearTargetasCategoria(categorias)       
        }      
    })
}


class Categoria{
    constructor(idUsuario, nombre, cantidadGasto, idCategoria){
        this.idUsuario = idUsuario,
        this.nombre = nombre,
        this.cantidadGasto = cantidadGasto,
        this.idCategoria = idCategoria
    }
}
const cardsContainer = document.getElementById('cards-container');
function CrearTargetasCategoria(categories){
    cardsContainer.innerText = "";
  
    categories.forEach(category => {
        const card = document.createElement('div');
        card.classList.add('card');
    
        const image = document.createElement('img');
        image.src = "../img/images.png";
        image.style.height = "100px";
        image.style.width = "100px";
    
        const title = document.createElement('h2');
        title.textContent = category.nombreCategoria;
    
        const expense = document.createElement('p');
        expense.textContent = "Gasto: " + category.cantidadGasto;

        const idtargeta = document.createElement("h6");
        idtargeta.textContent = category.id;

        const deleteButton = document.createElement('div');
        deleteButton.classList.add('delete-button');
        deleteButton.textContent = "X";

        deleteButton.addEventListener('click', () => {
            let ids = event.target.parentNode;
            let catero = parseInt(ids.querySelector("h6").innerText);
            EliminarCategoria(catero, categories);
        });

        const addButton = document.createElement('div');
        addButton.classList.add('add-button');
        addButton.innerHTML = "&#43;"; // Usamos el código HTML para el signo de más (+)

        addButton.addEventListener('click', () => {
            inputCantidadGasto.value =0;
            inputNombreGasto.value = "";
            cardsContainer.innerText ="";
            inputCrearCategoria.value ="";
            formulacioCrearCategoria.style.display = "flex";
        });

        const createExpenseButton = document.createElement('div');
        createExpenseButton.classList.add('create-expense-button');
        createExpenseButton.textContent = "Crear Gasto";

        createExpenseButton.addEventListener('click', () => {
            let eventoPadre = event.target.parentNode;
            let categoriaPadre = eventoPadre.querySelector("h6").innerText
            AsignarIdCategoria(categoriaPadre);
            cardsContainer.innerText ="";
            inputNombreGasto.value = "";
            formularioGastooo.style.display = "flex";
        });

        const viewExpenseButton = document.createElement('div');
        viewExpenseButton.classList.add('create-expense-button');
        viewExpenseButton.textContent = "Ver Gasto";

        viewExpenseButton.addEventListener('click', () => {
            cardsContainer.innerText = "";
            let idsVer = event.target.parentNode;
            let catero = parseInt(idsVer.querySelector("h6").innerText);
            VerGastos(catero);           
        });
         
        card.appendChild(image);
        card.appendChild(title);
        card.appendChild(expense);
        card.appendChild(deleteButton);
        card.appendChild(addButton);
        card.appendChild(createExpenseButton);
        card.appendChild(viewExpenseButton);
        card.appendChild(idtargeta)
    
        cardsContainer.appendChild(card);
  });
}
function EliminarCategoria(indiceCategoria, categories){
    const catego = categories.filter(C => C.id === indiceCategoria);
    console.log(indiceCategoria);
    if(catego[0].cantidadGasto === 0){
        fetch(UrlEliminarCategoria +"/"+indiceCategoria, {
            method: "Delete",
            headers: {'Content-Type': 'application/json'}
        })
        AlertaActualizar();
        menuCategoria.style.display = "none";
        setTimeout(()=>{
            VerTodasLasCategorias()
        }, 2000)
    }else{alert("Esta Categoria contiene gastos, no puede ser borrada...")}
    
}





  
  