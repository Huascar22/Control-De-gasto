const urlRegistro = "https://localhost:7002/Usuarios/GuardarUsuario";
const urlRecibirCodigo = "https://localhost:7002/Usuarios/codigo";
const objetoCargando = document.getElementById("Cargando");


function ConfirmarCodigo(usuario){
    const codigUsuario = document.getElementById("codigoformulario").value;
    fetch(urlRecibirCodigo)
    .then(codigo => codigo.text())
    .then(codigo => {    
        if(codigUsuario == codigo){          
            GuardarUsuario(usuario)     
        }else{alert("Codigo Incorrecto")}
    })
}


function GuardarUsuario(Usuario){
    fetch(urlRegistro, {
        method: 'POST', 
        headers: {
          'Content-Type': 'application/json' 
        },
        body: JSON.stringify({
            name: Usuario.name,
            username: Usuario.username,
            password: Usuario.password,
            email: Usuario.email,
            phone: Usuario.phone
        })           
    })    
}

function Cargando(){
    const imagen = document.getElementById("imagen");
    objetoCargando.style.display = "flex";

    FormularioValidar.style.display = "none";
    FormularioRegistro.style.display = "none";
    FormularioLogin.style.display = "none";

    setTimeout(function(){
        objetoCargando.style.display = "none";
        imagen.style.display = "block"
    }, 3000);
    
    setTimeout(function(){
        FormularioValidar.style.display = "flex"
        imagen.style.display = "none"
    }, 5000);
}