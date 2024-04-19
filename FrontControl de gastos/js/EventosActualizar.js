const btnActualizarNombre = document.getElementById("Btn-ActualizarNombre");
const btnActualizarUsername = document.getElementById("Btn-ActualizarUsername");
const btnActualizarPhone = document.getElementById("Btn-ActualizarPhone");
const btnActualizarEmail = document.getElementById("Btn-ActualizarEmail");

const inputNombreNuevo = document.getElementById("NombreNuevo");
const inputUsernameNuevo = document.getElementById("UsernameNuevo");
const inputPhoneNuevo = document.getElementById("PhoneNuevo");
const inputEmailNuevo = document.getElementById("EmailNuevo");

let UsuarioActual = JSON.parse(localStorage.getItem("usuario"));
const urlActualizar = "https://localhost:7002/Usuarios/actualizar";
const objetoCargando = document.getElementById("Cargando");

btnActualizarNombre.addEventListener("click", ()=>{
    event.preventDefault();
    if(inputNombreNuevo.value == ""){
        alert("El Campo es requerido");
    }else{
        UsuarioActual.name = inputNombreNuevo.value;
        ActualizarLocarStorage();
    }
});

btnActualizarEmail.addEventListener("click", ()=>{
    event.preventDefault();
    if(inputEmailNuevo.value == ""){
        alert("El Campo es requerido");
    }else{
        UsuarioActual.email = inputEmailNuevo.value;
        ActualizarLocarStorage();
    }
});

btnActualizarPhone.addEventListener("click", ()=>{
    event.preventDefault();
    if(inputPhoneNuevo.value == ""){
        alert("El Campo es requerido");
    }else{
        UsuarioActual.phone = inputPhoneNuevo.value;
        ActualizarLocarStorage(); 
    }
});

btnActualizarUsername.addEventListener("click", ()=>{
    event.preventDefault();
    if(inputUsernameNuevo.value == ""){
        alert("El Campo es requerido");
    }else{
        UsuarioActual.username = inputUsernameNuevo.value;
        ActualizarLocarStorage();       
    }
});



function ActualizarLocarStorage(){  
    UsuarioActual = JSON.stringify(UsuarioActual);
    localStorage.setItem("usuario", UsuarioActual);
    UsuarioActual = JSON.parse(UsuarioActual);
    ActualizarUsuario();
}

function ActualizarUsuario(){
    fetch(urlActualizar, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(UsuarioActual)
        })
    .then(usuario => usuario.json())
    .then(usuario => console.log(usuario))
    ActualizarVista();
}

window.addEventListener('beforeunload', function() {
    localStorage.clear();
});


function ActualizarVista(){
    formularioNombre.style.display = "none";
    formulario.style.display = "none";
    formularioEmail.style.display = "none";
    formularioPhone.style.display  = "none";
    formularioUsername.style.display = "none";
    formularioGasto.style.display ="none";
    AlertaActualizar();
}


 function  AlertaActualizar() {
    var alertBox = document.getElementById('alert');
    alertBox.style.display = 'block';

    setTimeout(function() {
      alertBox.style.display = 'none';
    }, 2000);
}
  