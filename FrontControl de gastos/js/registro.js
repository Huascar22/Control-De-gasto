const ClickRegistro = document.getElementById("RegistrarUsuario");
const UrlEnviarCodigo = "https://localhost:7002/Usuarios/EnviarCodigo";
const urlConfirmarUsername = "https://localhost:7002/Usuarios/ConfirmarUsername";


const FormularioRegistro = document.getElementById("formularioRegistro");
const BtnRegistro = document.getElementById("Btn-Registro");
const FormularioValidar = document.getElementById("formularioValidar");
const validandoEmail = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
const btnValidar = document.getElementById("Btn-Validar");
const FormularioLogin = document.getElementById("formularioLogin");


ClickRegistro.addEventListener("click", ()=>{
    FormularioRegistro.style.display = "flex";
    FormularioLogin.style.display = "none";
});

BtnRegistro.addEventListener("click", ()=>{
    const name = document.getElementById("name").value;
    const username = document.getElementById("username").value;
    const email = document.getElementById("emailRegistro").value;
    const password = document.getElementById("passwordRegistro").value;
    const phone = document.getElementById("phone").value;
    const usuario = new UsuarioRegistro(name, username, email, password, phone);

    if(name.trim() === "" || username.trim() === "" || email.trim() === "" ||  password.trim() === "" || phone.trim() === "" ){
        alert("Campos vacios")
        event.preventDefault();
    }else if(validandoEmail.test(email)){ 
        event.preventDefault();     
        ConfirmarUsername(username, email, usuario)    
    }else{alert("El correo no es valido..")  } 
})

function EnviarDestinatario(email, usuario){
    Cargando();
        fetch(UrlEnviarCodigo, {
            method: 'POST', 
            headers: {
              'Content-Type': 'application/json' 
            },
            body: JSON.stringify(email)       
        });   
        btnValidar.addEventListener("click", ()=>{
            Cargando();
            setTimeout(function(){
                FormularioValidar.style.display = "none";
                FormularioLogin.style.display = "flex";
                location.reload();
            }, 5000) 
            event.preventDefault();
            FormularioValidar.style.display = "none";                    
            ConfirmarCodigo(usuario)
        })                  
}

function ConfirmarUsername(username, email, usuario){
    fetch(urlConfirmarUsername, {
        method: 'POST', 
        headers: {
          'Content-Type': 'application/json' 
        },
        body: JSON.stringify(username)           
    })
    .then(respuesta => respuesta.text())
    .then(respuesta => {
        if(respuesta == "Existe"){
            alert("Este username Ya existe...")  
            location.reload();       
        }else{
            EnviarDestinatario(email, usuario);                      
        }
    })
}



/* */