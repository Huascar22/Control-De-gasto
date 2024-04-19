const btnCrearGasto = document.getElementById("A-CrearLimiteGasto");
const formularioGasto = document.getElementById("FormularioGastoLimite");
const btnFormularioGasto = document.getElementById("Btn-ActualizarGasto");
const urlGastoLimite = "https://localhost:7002/CrearLimiteGasto";
let usuarioActual = JSON.parse(localStorage.getItem("usuario"));

btnCrearGasto.addEventListener("click", ()=>{
    formularioNombre.style.display = "none";
    formulario.style.display = "none";
    formularioEmail.style.display = "none";
    formularioPhone.style.display  = "none";
    formularioUsername.style.display = "none";
    formularioGasto.style.display ="flex";
});

btnFormularioGasto.addEventListener("click", ()=>{
    const inputGasto = document.getElementById("inputGastoLimite");
    event.preventDefault();
    if(inputGasto.value == ""){
        alert("El campo es requerido")
    }else{
        if(!isNaN(inputGasto.value)){
            let gasto = new GastoUsuario(usuarioActual.id, inputGasto.value );
            CrearGasto(gasto);
        }else{
            alert("No es un numero..")
        }        
    }
});

function CrearGasto(GastoUser){
    fetch(urlGastoLimite, {
        method: 'POST', 
        headers: {
          'Content-Type': 'application/json' 
        },
        body: JSON.stringify({
            IdUsuario: GastoUser.id,
            LimiteGasto: GastoUser.gasto
        })
    })
    ActualizarVista();
}

class GastoUsuario {
    constructor(id, gasto){
        this.id = id,
        this.gasto = gasto
    }
};

